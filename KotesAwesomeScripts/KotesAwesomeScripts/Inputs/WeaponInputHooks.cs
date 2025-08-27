using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.Inputs
{
    public class WeaponInputHooks : MonoBehaviour
    {
        private InputManager im;
#region Variables
        [Header("Primary fire")]
        [SerializeField]
        private UnityEvent onFire1Pressed;
        [SerializeField]
        private UnityEvent onFire1Released;

        [Space]
        [Header("Secondary fire")]
        [SerializeField]
        private UnityEvent onFire2Pressed;
        [SerializeField]
        private UnityEvent onFire2Released;

        [Space]
        [Header("Next variation")]
        [SerializeField]
        private UnityEvent onNextVariationPressed;
        [SerializeField]
        private UnityEvent onNextVariationReleased;

        [Header("Previous variation")]
        [SerializeField]
        private UnityEvent onPreviousVariationPressed;
        [SerializeField]
        private UnityEvent onPreviousVariationReleased;

        [Header("Revolver")]
        [SerializeField]
        private UnityEvent on1Pressed;
        [SerializeField]
        private UnityEvent on1Released;

        [Header("Shotgun")]
        [SerializeField]
        private UnityEvent on2Pressed;
        [SerializeField]
        private UnityEvent on2Released;

        [Header("Nailgun")]
        [SerializeField]
        private UnityEvent on3Pressed;
        [SerializeField]
        private UnityEvent on3Released;

        [Header("Railcannon")]
        [SerializeField]
        private UnityEvent on4Pressed;
        [SerializeField]
        private UnityEvent on4Released;

        [Header("Rocket launcher")]
        [SerializeField]
        private UnityEvent on5Pressed;
        [SerializeField]
        private UnityEvent on5Released;

        [Header("Spawner arm")]
        [SerializeField]
        private UnityEvent on6Pressed;
        [SerializeField]
        private UnityEvent on6Released;

        [Header("Next weapon")]
        [SerializeField]
        private UnityEvent onNextWeaponPressed;
        [SerializeField]
        private UnityEvent onNextWeaponReleased;

        [Header("Previous weapon")]
        [SerializeField]
        private UnityEvent onPreviousWeaponPressed;
        [SerializeField]
        private UnityEvent onPreviousWeaponReleased;

        [Header("Last used weapon")]
        [SerializeField]
        private UnityEvent onLastWeaponPressed;
        [SerializeField]
        private UnityEvent onLastWeaponReleased;

        [Header("Variation slot 1")]
        [SerializeField]
        private UnityEvent onVar1Pressed;
        [SerializeField]
        private UnityEvent onVar1Released;

        [Header("Variation slot 2")]
        [SerializeField]
        private UnityEvent onVar2Pressed;
        [SerializeField]
        private UnityEvent onVar2Released;

        [Header("Variation slot 3")]
        [SerializeField]
        private UnityEvent onVar3Pressed;
        [SerializeField]
        private UnityEvent onVar3Released;
#endregion

        private void Start() { im = MonoSingleton<InputManager>.Instance; }
        private void Update()
        {
            if (!MonoSingleton<OptionsManager>.Instance || 
                !MonoSingleton<OptionsManager>.Instance.paused || 
                !im.PerformingCheatMenuCombo())
            {
                //Primary fire
                if (im.InputSource.Fire1.WasPerformedThisFrame) { onFire1Pressed.Invoke(); }
                else if (im.InputSource.Fire1.WasCanceledThisFrame) { onFire1Released.Invoke(); }
                //Secondary fire
                else if (im.InputSource.Fire2.WasPerformedThisFrame) { onFire2Pressed.Invoke(); }
                else if (im.InputSource.Fire2.WasCanceledThisFrame) { onFire2Released.Invoke(); }
                //Next variation
                else if (im.InputSource.NextVariation.WasPerformedThisFrame) { onNextVariationPressed.Invoke(); }
                else if (im.InputSource.NextVariation.WasCanceledThisFrame) { onNextVariationReleased.Invoke(); }
                //Previous variation
                else if (im.InputSource.PreviousVariation.WasPerformedThisFrame) { onPreviousVariationPressed.Invoke(); }
                else if (im.InputSource.PreviousVariation.WasCanceledThisFrame) { onPreviousVariationReleased.Invoke(); }
                //Revolver
                else if (im.InputSource.Slot1.WasPerformedThisFrame) { on1Pressed.Invoke(); }
                else if (im.InputSource.Slot1.WasCanceledThisFrame) { on1Released.Invoke(); }
                //Shotgun
                else if (im.InputSource.Slot2.WasPerformedThisFrame) { on2Pressed.Invoke(); }
                else if (im.InputSource.Slot2.WasCanceledThisFrame) { on2Released.Invoke(); }
                //Nailgun
                else if (im.InputSource.Slot3.WasPerformedThisFrame) { on3Pressed.Invoke(); }
                else if (im.InputSource.Slot3.WasCanceledThisFrame) { on3Released.Invoke(); }
                //Railcannon
                else if (im.InputSource.Slot4.WasPerformedThisFrame) { on4Pressed.Invoke(); }
                else if (im.InputSource.Slot4.WasCanceledThisFrame) { on4Released.Invoke(); }
                //Rocket launcher
                else if (im.InputSource.Slot5.WasPerformedThisFrame) { on5Pressed.Invoke(); }
                else if (im.InputSource.Slot5.WasCanceledThisFrame) { on5Released.Invoke(); }
                //Spawner arm
                else if (im.InputSource.Slot6.WasPerformedThisFrame) { on6Pressed.Invoke(); }
                else if (im.InputSource.Slot6.WasCanceledThisFrame) { on6Released.Invoke(); }
                //Next weapon
                else if (im.InputSource.NextWeapon.WasPerformedThisFrame) { onNextWeaponPressed.Invoke(); }
                else if (im.InputSource.NextWeapon.WasCanceledThisFrame) { onNextWeaponReleased.Invoke(); }
                //Previous weapon
                else if (im.InputSource.PrevWeapon.WasPerformedThisFrame) { onPreviousWeaponPressed.Invoke(); }
                else if (im.InputSource.PrevWeapon.WasCanceledThisFrame) { onPreviousWeaponReleased.Invoke(); }
                //Last used weapon
                else if (im.InputSource.LastWeapon.WasPerformedThisFrame) { onLastWeaponPressed.Invoke(); }
                else if (im.InputSource.LastWeapon.WasCanceledThisFrame) { onLastWeaponReleased.Invoke(); }
                //Variation slot 1
                else if (im.InputSource.SelectVariant1.WasPerformedThisFrame) { onVar1Pressed.Invoke(); }
                else if (im.InputSource.SelectVariant1.WasCanceledThisFrame) { onVar1Released.Invoke(); }
                //Variation slot 2
                else if (im.InputSource.SelectVariant2.WasPerformedThisFrame) { onVar2Pressed.Invoke(); }
                else if (im.InputSource.SelectVariant2.WasCanceledThisFrame) { onVar2Released.Invoke(); }
                //Variation slot 3
                else if (im.InputSource.SelectVariant3.WasPerformedThisFrame) { onVar3Pressed.Invoke(); }
                else if (im.InputSource.SelectVariant3.WasCanceledThisFrame) { onVar3Released.Invoke(); }
            }
        }
    }
}
