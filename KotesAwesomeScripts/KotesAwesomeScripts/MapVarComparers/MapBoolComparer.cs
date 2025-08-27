using Logic;
using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.MapVarComparers
{
    public class MapBoolComparer : MonoBehaviour
    {
        [SerializeField, Tooltip("Compare variables once when object gets activated")] 
        private bool compareOnEnable;
        [SerializeField, Tooltip("Compare variables every frame, while object is enabled")] 
        private bool compareEveryFrame;

        [SerializeField, Tooltip("Object that is being compared with other")] 
        private string variableName1;
        [SerializeField] private string variableName2;

        [SerializeField] private BoolComparingTypes comparingMode;

        [SerializeField] private UnityEvent onSuccess;
        [SerializeField] private UnityEvent onFailure;

        private void OnEnable() { if (compareOnEnable) { CompareVariables(); } }
        private void Update() { if (compareEveryFrame) { CompareVariables(); } }
        public void CompareVariables()
        {
            switch (comparingMode)
            {
                case BoolComparingTypes.EqualTo:
                    if (MonoSingleton<MapVarManager>.Instance.GetBool(variableName1) == MonoSingleton<MapVarManager>.Instance.GetBool(variableName2)) { onSuccess.Invoke(); }
                    else { onFailure.Invoke(); }
                    break;
                case BoolComparingTypes.NotEqualTo:
                    if (MonoSingleton<MapVarManager>.Instance.GetBool(variableName1) != MonoSingleton<MapVarManager>.Instance.GetBool(variableName2)) { onSuccess.Invoke(); }
                    else { onFailure.Invoke(); }
                    break;
            }
        }
        private enum BoolComparingTypes
        {
            EqualTo = 0,
            NotEqualTo = 1,
        }
    }
}
