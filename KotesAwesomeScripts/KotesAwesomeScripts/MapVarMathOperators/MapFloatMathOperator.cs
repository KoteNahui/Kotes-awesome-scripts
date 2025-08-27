using Logic;
using UnityEngine;

namespace KotesAwesomeScripts.MapVarMathOperators
{
    public class MapFloatMathOperator : MonoBehaviour
    {
        public bool setOnEnable = true;

        public bool setEveryFrame;

        [SerializeField, Tooltip("'C' in the 'A-B=C' equasion")] private string variableName;
        [SerializeField, Tooltip("'A' in the 'A-B=C' equasion")] private string variableName1;
        [SerializeField, Tooltip("'B' in the 'A-B=C' equasion")] private string variableName2;

        [SerializeField] private MathOperationType operationType;

        private MapVarManager mvm;
        public void SetVar()
        {
            if (mvm == null) mvm = MonoSingleton<MapVarManager>.Instance;
            switch (operationType)
            {
                case MathOperationType.Add:
                    mvm.SetFloat(variableName, (float)(mvm.GetFloat(variableName1) + mvm.GetFloat(variableName2)));
                    break;
                case MathOperationType.Subtract:
                    mvm.SetFloat(variableName, (float)(mvm.GetFloat(variableName1) - mvm.GetFloat(variableName2)));
                    break;
                case MathOperationType.Multiply:
                    mvm.SetFloat(variableName, (float)(mvm.GetFloat(variableName1) * mvm.GetFloat(variableName2)));
                    break;
                case MathOperationType.Divide:
                    mvm.SetFloat(variableName, (float)(mvm.GetFloat(variableName1) / mvm.GetFloat(variableName2)));
                    break;
            }
        }
        private void OnEnable()
        {
            if (setOnEnable)
            {
                SetVar();
            }
        }

        private void Update()
        {
            if (setEveryFrame)
            {
                SetVar();
            }
        }
    }
}
