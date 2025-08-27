using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.Inputs
{
    public class HudInputHooks : MonoBehaviour
    {
        private InputManager im;

        [Tooltip("Activate event when stats key is interacted with. why does this script exist lmao, SURELY HUD tab will get more uses later :copium:")]
        [SerializeField]
        private UnityEvent onStatsPressed;
        [SerializeField]
        private UnityEvent onStatsReleased;
        [SerializeField, Tooltip("Ignores pause check")]
        private UnityEvent onPausePressed;
        [SerializeField, Tooltip("Ignores pause check")]
        private UnityEvent onPauseReleased;

        private void Start() { im = MonoSingleton<InputManager>.Instance; }
        private void Update()
        {
            if (!MonoSingleton<OptionsManager>.Instance ||
                !MonoSingleton<OptionsManager>.Instance.paused ||
                !im.PerformingCheatMenuCombo())
            {
                //Hud
                if (im.InputSource.Stats.WasPerformedThisFrame) { onStatsPressed.Invoke(); }
                else if (im.InputSource.Stats.WasCanceledThisFrame) { onStatsReleased.Invoke(); }
            }
            if (!im.PerformingCheatMenuCombo())
            {
                if (im.InputSource.Pause.WasPerformedThisFrame) { onPausePressed.Invoke(); }
                else if (im.InputSource.Pause.WasCanceledThisFrame) { onPauseReleased.Invoke(); }
            }
                    
        }
    }
}
