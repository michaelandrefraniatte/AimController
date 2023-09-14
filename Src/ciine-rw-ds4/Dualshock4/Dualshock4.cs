using DualShock4API.State;
using DualShock4API.Util;
using Device.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DualShock4API
{
    public class DualShock4
    {
        private readonly IDevice underlyingDevice;
        private readonly int? readBufferSize;
        private readonly int? writeBufferSize;
        private IDisposable pollerSubscription;
        public event StatePolledHandler OnStatePolled;
        public event ButtonStateChangedHandler OnButtonStateChanged;
        public DualShock4InputState InputState { get; private set; } = new DualShock4InputState();
        private DualShock4(IDevice underlyingDevice, int? readBufferSize, int? writeBufferSize)
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
        private async Task<DualShock4InputState> ReadWriteOnceAsync()
        {
            TransferResult result = await underlyingDevice.WriteAndReadAsync(GetOutputDataBytes());
            if (result.BytesTransferred == readBufferSize)
            {
                return new DualShock4InputState(result.Data.Skip(1).ToArray(), 0f);
            }
            else
            {
                throw new IOException("Failed to read data - buffer size mismatch");
            }
        }
        public DualShock4InputState ReadWriteOnce()
        {
            Task<DualShock4InputState> stateTask = ReadWriteOnceAsync();
            stateTask.Wait();
            InputState = stateTask.Result;
            return InputState;
        }
        public void BeginPolling()
        {
            DualShock4InputState nextState = ReadWriteOnce();
            DualShock4InputState prevState = InputState;
            InputState = nextState;
            if (OnButtonStateChanged != null)
            {
                DualShock4InputStateButtonDelta delta = new DualShock4InputStateButtonDelta(prevState, nextState);
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
            bytes[0] = 0x05;
            return bytes;
        }
        public static IEnumerable<DualShock4> EnumerateControllers()
        {
            foreach (ConnectedDeviceDefinition deviceDefinition in DualShock4HidScanner.ListDevices())
            {
                IDevice device = DualShock4HidScanner.GetConnectedDevice(deviceDefinition);
                yield return new DualShock4(device, deviceDefinition.ReadBufferSize, deviceDefinition.WriteBufferSize);
            }
        }
        public delegate void StatePolledHandler(DualShock4 sender);
        public delegate void ButtonStateChangedHandler(DualShock4 sender, DualShock4InputStateButtonDelta changes);
    }
}