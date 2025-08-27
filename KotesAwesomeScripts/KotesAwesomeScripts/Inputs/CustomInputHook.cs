using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.Inputs
{
    public class CustomInputHook : MonoBehaviour
    {
        [SerializeField, Tooltip("You can set any key you want here. The key you choose will be static, meaning player cant change it in any way.")]
        private KeyCode CustomKey;

        public UnityEvent onKeyPressed;

        [Tooltip("How often event gets executed while holding the key. Thnaks floofimations for the idea.")] 
        public float holdInvokeDelay;
        private bool canInvokeHold;
        public UnityEvent onKeyHold;

        public UnityEvent onKeyReleased;

        private void Start()
        {
            canInvokeHold = true;
        }
        private void Update()
        {
            if (!MonoSingleton<OptionsManager>.Instance || !MonoSingleton<OptionsManager>.Instance.paused)
            {
                if (Input.GetKeyDown(CustomKey))
                {
                    onKeyPressed.Invoke();
                    canInvokeHold = false;
                    Invoke(nameof(resetCanInvokeHold), holdInvokeDelay);
                }

                else if (Input.GetKey(CustomKey) && canInvokeHold)
                {
                    onKeyHold.Invoke();
                    canInvokeHold = false;
                    Invoke(nameof(resetCanInvokeHold), holdInvokeDelay);
                }

                else if (Input.GetKeyUp(CustomKey))
                {
                    onKeyReleased.Invoke();
                }
            }
        }
        private void resetCanInvokeHold() => canInvokeHold = true;
    }
}
