using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.Inputs
{
    public class MovementInputHooks : MonoBehaviour
    {
        private InputManager im;

        [Header("Move"), Tooltip("Activate event when WASD was interacted with. sorry, couldnt seperate keys individually")]
        [SerializeField]
        private UnityEvent onMoveInputPressed;
        [SerializeField]
        private UnityEvent onMoveInputReleased;

        [Header("Dash")]
        [SerializeField]
        private UnityEvent onDashPressed;
        [SerializeField]
        private UnityEvent onDashReleased;

        [Space]
        [Header("Slide")]
        [SerializeField]
        private UnityEvent onSlidePressed;
        [SerializeField]
        private UnityEvent onSlideReleased;

        [Space]
        [Header("Jump")]
        [SerializeField]
        private UnityEvent onJumpPressed;
        [SerializeField]
        private UnityEvent onJumpReleased;

        private void Start() { im = MonoSingleton<InputManager>.Instance; }
        private void Update()
        {
            if (!MonoSingleton<OptionsManager>.Instance ||
                !MonoSingleton<OptionsManager>.Instance.paused ||
                !im.PerformingCheatMenuCombo())
            {
               //Movement
                if (im.InputSource.Move.WasPerformedThisFrame) { onMoveInputPressed.Invoke(); }
                else if (im.InputSource.Move.WasCanceledThisFrame) { onMoveInputReleased.Invoke(); }
               //Dodge
                else if (im.InputSource.Dodge.WasPerformedThisFrame) { onDashPressed.Invoke(); }
                else if (im.InputSource.Dodge.WasCanceledThisFrame) { onDashReleased.Invoke(); }
               //Slide
                else if (im.InputSource.Slide.WasPerformedThisFrame) { onSlidePressed.Invoke(); }
                else if (im.InputSource.Slide.WasCanceledThisFrame) { onSlideReleased.Invoke(); }
                //Jump
                else if (im.InputSource.Jump.WasPerformedThisFrame) { onJumpPressed.Invoke(); }
                else if (im.InputSource.Jump.WasCanceledThisFrame) { onJumpReleased.Invoke(); }
            }
        }
    }
}
