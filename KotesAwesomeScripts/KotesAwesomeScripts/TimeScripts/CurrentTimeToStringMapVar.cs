using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KotesAwesomeScripts.TimeScripts
{
    public class CurrentTimeToStringMapVar : MonoBehaviour
    {
        private MapVarManager mvm;

        public bool setOnEnable;
        public bool setEveryFrame;

        [Space]
        public string variableName;

        [Space]
        public bool setUTC;
        public void SetVariable()
        {
            if (setUTC) mvm.SetString(variableName, DateTime.UtcNow.ToString());
            else mvm.SetString(variableName, DateTime.Now.ToString());
        }
        private void OnEnable() { if (setOnEnable) { SetVariable(); } }
        private void Update() { if (setEveryFrame) { SetVariable(); } }
        private void Start() => mvm = MonoSingleton<MapVarManager>.Instance;
    }
}
