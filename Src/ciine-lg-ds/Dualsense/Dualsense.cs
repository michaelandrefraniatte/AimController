using Device.Net;
using DualSenseAPI.State;
using DualSenseAPI.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DualSenseAPI
{
    public class DualSense
    {
        private readonly IDevice underlyingDevice;
        private readonly int? readBufferSize;
        private readonly int? writeBufferSize;
        private IDisposable pollerSubscription;
        public event ButtonStateChangedHandler OnButtonStateChanged;
        public DualSenseInputState InputState { get; private set; } = new DualSenseInputState();
        private DualSense(IDevice underlyingDevice, int? readBufferSize, int? writeBufferSize)
        {
            this.underlyingDevice = underlyingDevice;
            this.readBufferSize = readBufferSize;
            this.writeBufferSize = writeBufferSize;
        }
        public void Acquire()
        {
            if (!underlyingDevice.IsInitialized)
            {
                underlyingDevice.InitializeAsync().Wait();
            }
        }
        public void Release()
        {
            if (underlyingDevice.IsInitialized)
            {
                underlyingDevice.Close();
            }
        }
        private async Task<DualSenseInputState> ReadWriteOnceAsync()
        {
            TransferResult result = await underlyingDevice.WriteAndReadAsync(GetOutputDataBytes());
            if (result.BytesTransferred == readBufferSize)
            {
                return new DualSenseInputState(result.Data.Skip(1).ToArray(), 0f);
            }
            else
            {
                throw new IOException("Failed to read data - buffer size mismatch");
            }
        }
        public DualSenseInputState ReadWriteOnce()
        {
            Task<DualSenseInputState> stateTask = ReadWriteOnceAsync();
            stateTask.Wait();
            InputState = stateTask.Result;
            return InputState;
        }
        public void BeginPolling()
        {
            DualSenseInputState nextState = ReadWriteOnce();
            DualSenseInputState prevState = InputState;
            InputState = nextState;
            if (OnButtonStateChanged != null)
            {
                DualSenseInputStateButtonDelta delta = new DualSenseInputStateButtonDelta(prevState, nextState);
                if (delta.HasChanges)
                {
                    OnButtonStateChanged.Invoke(this, delta);
                }
            }
        }
        public void EndPolling()
        {
            if (pollerSubscription == null)
            {
                throw new InvalidOperationException("Can't end polling without starting polling first");
            }
            pollerSubscription.Dispose();
            pollerSubscription = null;
        }
        private byte[] GetOutputDataBytes()
        {
            byte[] bytes = new byte[writeBufferSize ?? 0];
            bytes[0] = 0x02;
            return bytes;
        }
        public static IEnumerable<DualSense> EnumerateControllers()
        {
            foreach (ConnectedDeviceDefinition deviceDefinition in HidScanner.ListDevices())
            {
                IDevice device = HidScanner.GetConnectedDevice(deviceDefinition);
                yield return new DualSense(device, deviceDefinition.ReadBufferSize, deviceDefinition.WriteBufferSize);
            }
        }
        public delegate void StatePolledHandler(DualSense sender);
        public delegate void ButtonStateChangedHandler(DualSense sender, DualSenseInputStateButtonDelta changes);
    }
}
