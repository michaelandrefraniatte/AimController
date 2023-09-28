using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace DualShock4API.State
{
    public class DualShock4InputStateButtonDelta
    {
        /// <summary>
        /// The change status of the square button.
        /// </summary>
        public DualShock4ButtonDeltaState SquareButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the cross button.
        /// </summary>
        public DualShock4ButtonDeltaState CrossButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the circle button.
        /// </summary>
        public DualShock4ButtonDeltaState CircleButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the triangle button.
        /// </summary>
        public DualShock4ButtonDeltaState TriangleButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the D-pad up button.
        /// </summary>
        public DualShock4ButtonDeltaState DPadUpButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the D-pad right button.
        /// </summary>
        public DualShock4ButtonDeltaState DPadRightButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the D-pad down button.
        /// </summary>
        public DualShock4ButtonDeltaState DPadDownButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the D-pad left button.
        /// </summary>
        public DualShock4ButtonDeltaState DPadLeftButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the L1 button.
        /// </summary>
        public DualShock4ButtonDeltaState L1Button { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the R1 button.
        /// </summary>
        public DualShock4ButtonDeltaState R1Button { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the L2 button.
        /// </summary>
        public DualShock4ButtonDeltaState L2Button { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the R2 button.
        /// </summary>
        public DualShock4ButtonDeltaState R2Button { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the create button.
        /// </summary>
        public DualShock4ButtonDeltaState CreateButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the menu button.
        /// </summary>
        public DualShock4ButtonDeltaState MenuButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the L3 button.
        /// </summary>
        public DualShock4ButtonDeltaState L3Button { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the R2 button.
        /// </summary>
        public DualShock4ButtonDeltaState R3Button { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the PlayStation logo button.
        /// </summary>
        public DualShock4ButtonDeltaState LogoButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the touchpad button.
        /// </summary>
        public DualShock4ButtonDeltaState TouchpadButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// The change status of the mic button.
        /// </summary>
        public DualShock4ButtonDeltaState MicButton { get; private set; } = DualShock4ButtonDeltaState.NoChange;

        /// <summary>
        /// Whether the delta has any changes.
        /// </summary>
        public bool HasChanges { get; private set; } = false;

        private static readonly List<(PropertyInfo delta, PropertyInfo state)> propertyPairData;

        static DualShock4InputStateButtonDelta()
        {
            // we know some key things here:
            // - on the input state, all the types of button properties are boolean.
            // - on the delta, all the types of the button properties are ButtonDeltaState.
            // - all the properties of button delta are named the same as the properties on input state - it's a subset.

            // since reflection can be a bit heavy, we'll incur this burden only once at startup so we can get the necessary property info for comparison

            PropertyInfo[] deltaProperties = typeof(DualShock4InputStateButtonDelta).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            propertyPairData = deltaProperties
                .Where(x => x.PropertyType == typeof(DualShock4ButtonDeltaState))
                .Select(x => (x, typeof(DualShock4InputState).GetProperty(x.Name))).ToList();
        }

        /// <summary>
        /// Internal constructor for a button delta. Diffs previous and next state.
        /// </summary>
        /// <param name="prevState">The previous/old input state.</param>
        /// <param name="nextState">The next/new input state.</param>
        internal DualShock4InputStateButtonDelta(DualShock4InputState prevState, DualShock4InputState nextState)
        {
            foreach (var (delta, state) in propertyPairData)
            {
                if (state.GetValue(prevState) is bool oldVal && state.GetValue(nextState) is bool newVal)
                {
                    // otherwise leave at default NoChange
                    if (oldVal != newVal)
                    {
                        delta.SetValue(this, newVal ? DualShock4ButtonDeltaState.Pressed : DualShock4ButtonDeltaState.Released);
                        HasChanges = true;
                    }
                }
                else
                {
                    // we should never EVER get here. and if we do, we need to know about it to fix it,
                    // as a core assumption has been violated.
                    throw new InvalidOperationException();
                }
            }
        }
    }
}