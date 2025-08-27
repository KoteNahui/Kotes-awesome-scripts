using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.Inputs
{
    public class FistInputHooks : MonoBehaviour
    {
        private InputManager im;

        [Header("Punch"), Tooltip("Activate event when punch key is interacted with. regarding FB/KB punch: hakita evil and didnt leave keybind for that(perhaps im just stupid)")]
        [SerializeField]
        private UnityEvent onPunchPressed;
        [SerializeField]
        private UnityEvent onPunchReleased;

        [Space]
        [Header("Change fist")]
        [SerializeField]
        private UnityEvent onChangeFistPressed;
        [SerializeField]
        private UnityEvent onChangeFistReleased;

        [Space]
        [Header("Whiplash")]
        [SerializeField]
        private UnityEvent onWhiplashPressed;
        [SerializeField]
        private UnityEvent onWhiplashReleased;

        private void Start() { im = MonoSingleton<InputManager>.Instance; }
        private void Update()
        {
            if (!MonoSingleton<OptionsManager>.Instance ||
                !MonoSingleton<OptionsManager>.Instance.paused || 
                !im.PerformingCheatMenuCombo())
            {
                //Punch
                if (im.InputSource.Punch.WasPerformedThisFrame) { onPunchPressed.Invoke(); }
                else if (im.InputSource.Punch.WasCanceledThisFrame) { onPunchReleased.Invoke(); }
                //Change fist
                else if (im.InputSource.ChangeFist.WasPerformedThisFrame) { onChangeFistPressed.Invoke(); }
                else if (im.InputSource.ChangeFist.WasCanceledThisFrame) { onChangeFistReleased.Invoke(); }
                //Hook
                else if (im.InputSource.Hook.WasPerformedThisFrame) { onWhiplashPressed.Invoke(); }
                else if (im.InputSource.Hook.WasCanceledThisFrame) { onWhiplashReleased.Invoke(); }
            }
        }
    }
}
