using Logic;
using System;
using UnityEngine;

namespace KotesAwesomeScripts.Miscellaneous
{
    public class DebugLogPrinter : MonoBehaviour
    {
        public bool printOnEnable;
        public bool printEveryFrame;

        [Space]
        public string message;

        [Space]
        public bool includeVariable;
        public string variableName;
        public VariableType type = VariableType.Bool;

        [Space]
        public MessageSendType messageSendType = MessageSendType.Warning;
        public bool includeObjectName = true;

        private MapVarManager mvm;
        public void PrintString()
        {
            if (variableName == string.Empty) variableName = "null_var";

            string finalString = message;
            finalString += includeVariable ? ("   :   " + variableName + " = " + StringifyVariable(variableName)) : string.Empty;
            finalString += includeObjectName ? ("   From: '" + gameObject.name + "'") : string.Empty;

            switch (messageSendType)
            {
                case MessageSendType.Log:
                    Debug.Log(finalString);
                    break;
                case MessageSendType.Warning:
                    Debug.LogWarning(finalString);
                    break;
                case MessageSendType.Exception:
                    Debug.LogError(finalString);
                    break;
            }
        }
        private string StringifyVariable(string varName)
        {
            string varValue = "null";

            switch (type)
            {
                case VariableType.Bool:
                    varValue = mvm.GetBool(varName).ToString();
                    break;
                case VariableType.Int:
                    varValue = mvm.GetInt(varName).ToString();
                    break;
                case VariableType.Float:
                    varValue = mvm.GetFloat(varName).ToString();
                    break;
                case VariableType.String:
                    varValue = mvm.GetString(varName);
                    break;
            }

            return varValue;
        }
        private void Start() => mvm = MonoSingleton<MapVarManager>.Instance;
        private void OnEnable() { if (printOnEnable) { PrintString(); } }
        private void Update() { if (printEveryFrame) { PrintString(); } }
    }
    [Serializable]
    public enum MessageSendType
    {
        Log, Warning, Exception
    }

}
