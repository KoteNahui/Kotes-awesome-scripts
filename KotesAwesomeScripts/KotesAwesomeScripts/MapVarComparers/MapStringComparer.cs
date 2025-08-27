using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Events;
using UnityEngine;

namespace KotesAwesomeScripts.MapVarComparers
{
    public class MapStringComparer : MonoBehaviour
    {
        [SerializeField, Tooltip("Compare variables once when object gets activated")] private bool compareOnEnable;
        [SerializeField, Tooltip("Compare variables every frame, while object is enabled")] private bool compareEveryFrame;

        [SerializeField, Tooltip("Object that is being compared with other")] private string variableName1;
        [SerializeField] private string variableName2;

        [SerializeField] private StringComparingTypes comparingMode;

        [SerializeField] private UnityEvent onSuccess;
        [SerializeField] private UnityEvent onFailure;

        private void OnEnable() { if (compareOnEnable) { CompareVariables(); } }
        private void Update() { if (compareEveryFrame) { CompareVariables(); } }
        public void CompareVariables()
        {
            switch (comparingMode)
            {
                case StringComparingTypes.Matches:
                    if (MonoSingleton<MapVarManager>.Instance.GetString(variableName1) == MonoSingleton<MapVarManager>.Instance.GetString(variableName2))
                        onSuccess.Invoke();
                    else
                        onFailure.Invoke(); 
                    break;
                case StringComparingTypes.NotMatches:
                    if (MonoSingleton<MapVarManager>.Instance.GetString(variableName1) != MonoSingleton<MapVarManager>.Instance.GetString(variableName2))
                        onSuccess.Invoke();
                    else
                        onFailure.Invoke();
                    break;
                case StringComparingTypes.Contains:
                    if (MonoSingleton<MapVarManager>.Instance.GetString(variableName1).Contains(MonoSingleton<MapVarManager>.Instance.GetString(variableName2)))
                        onSuccess.Invoke();
                    else
                        onFailure.Invoke();
                    break;
            }
        }
        private enum StringComparingTypes
        {
            Matches = 0,
            NotMatches = 1,
            Contains = 2
        }
    }
}
