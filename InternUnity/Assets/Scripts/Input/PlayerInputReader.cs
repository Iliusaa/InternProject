using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Stackspire.Input
{
    [DisallowMultipleComponent]
    public sealed class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private VirtualJoystick movementJoystick;
        [SerializeField] private VirtualJoystick aimJoystick;
        [SerializeField] private bool enableEditorFallback = true;

        private Vector2 movementVector;
        private Vector2 aimVector;
        private bool attackHeld;

        /// <summary>
        /// Current movement input, clamped to a maximum magnitude of 1.
        /// </summary>
        public Vector2 MovementVector => movementVector;

        /// <summary>
        /// Current aim direction, clamped to a maximum magnitude of 1.
        /// </summary>
        public Vector2 AimVector => aimVector;

        /// <summary>
        /// Whether the player is currently holding attack input.
        /// </summary>
        public bool AttackHeld => attackHeld;

        private void Update()
        {
            ReadJoystickInput();
            ApplyEditorFallback();
        }

        private void ReadJoystickInput()
        {
            movementVector = ReadMovementJoystick();
            aimVector = ReadAimJoystick();
            attackHeld = aimJoystick != null && aimJoystick.IsHeld;
        }

        private Vector2 ReadMovementJoystick()
        {
            if (movementJoystick == null)
            {
                return Vector2.zero;
            }

            return Vector2.ClampMagnitude(movementJoystick.Direction * movementJoystick.Magnitude, 1f);
        }

        private Vector2 ReadAimJoystick()
        {
            if (aimJoystick == null || aimJoystick.Magnitude <= 0f)
            {
                return Vector2.zero;
            }

            return Vector2.ClampMagnitude(aimJoystick.Direction, 1f);
        }

        private void ApplyEditorFallback()
        {
#if UNITY_EDITOR && ENABLE_INPUT_SYSTEM
            if (!enableEditorFallback)
            {
                return;
            }

            Keyboard keyboard = Keyboard.current;
            if (keyboard != null)
            {
                Vector2 keyboardMovement = ReadKeyboardMovement(keyboard);
                if (keyboardMovement != Vector2.zero)
                {
                    movementVector = keyboardMovement;
                }

                Vector2 keyboardAim = ReadKeyboardAim(keyboard);
                if (keyboardAim != Vector2.zero)
                {
                    aimVector = keyboardAim;
                }

                attackHeld |= keyboard.spaceKey.isPressed || keyboard.leftCtrlKey.isPressed;
            }

            Mouse mouse = Mouse.current;
            if (mouse != null)
            {
                bool mouseAttackHeld = mouse.leftButton.isPressed || mouse.rightButton.isPressed;
                if (mouseAttackHeld)
                {
                    attackHeld = true;
                    Vector2 mouseAim = ReadMouseAim(mouse);
                    if (mouseAim != Vector2.zero)
                    {
                        aimVector = mouseAim;
                    }
                }
            }
#endif
        }

#if UNITY_EDITOR && ENABLE_INPUT_SYSTEM
        private static Vector2 ReadKeyboardMovement(Keyboard keyboard)
        {
            Vector2 value = Vector2.zero;

            if (keyboard.aKey.isPressed)
            {
                value.x -= 1f;
            }

            if (keyboard.dKey.isPressed)
            {
                value.x += 1f;
            }

            if (keyboard.sKey.isPressed)
            {
                value.y -= 1f;
            }

            if (keyboard.wKey.isPressed)
            {
                value.y += 1f;
            }

            return Vector2.ClampMagnitude(value, 1f);
        }

        private static Vector2 ReadKeyboardAim(Keyboard keyboard)
        {
            Vector2 value = Vector2.zero;

            if (keyboard.leftArrowKey.isPressed)
            {
                value.x -= 1f;
            }

            if (keyboard.rightArrowKey.isPressed)
            {
                value.x += 1f;
            }

            if (keyboard.downArrowKey.isPressed)
            {
                value.y -= 1f;
            }

            if (keyboard.upArrowKey.isPressed)
            {
                value.y += 1f;
            }

            return Vector2.ClampMagnitude(value, 1f);
        }

        private static Vector2 ReadMouseAim(Mouse mouse)
        {
            Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            Vector2 value = mouse.position.ReadValue() - screenCenter;

            if (value.sqrMagnitude <= Mathf.Epsilon)
            {
                return Vector2.zero;
            }

            return value.normalized;
        }
#endif
    }
}
