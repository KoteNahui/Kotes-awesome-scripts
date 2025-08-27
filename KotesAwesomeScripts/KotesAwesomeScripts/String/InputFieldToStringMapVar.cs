using Logic;
using TMPro;
using UnityEngine;

namespace KotesAwesomeScripts.String
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputFieldToStringMapVar : MonoBehaviour
    {
        private TMP_InputField curInputField;

        [SerializeField]
        private string variableName;

        [SerializeField]
        private VariableType variableType;

        [SerializeField]
        private bool setOnEndEdit = true;
        [SerializeField]
        private bool setOnValueChanged;
        private void OnEnable()
        {
            if (curInputField == null) curInputField = GetComponent<TMP_InputField>();

            if (setOnEndEdit)
            {
                curInputField.onEndEdit.AddListener(SetMapVar);
            }
            else if (setOnValueChanged) 
            {
                curInputField.onValueChanged.AddListener(SetMapVar);
            }
        }
        private void OnDisable()
        {
            if (setOnEndEdit)
            {
                curInputField.onEndEdit.RemoveListener(SetMapVar);
            }
            else if (setOnValueChanged)
            {
                curInputField.onValueChanged.RemoveListener(SetMapVar);
            }
        }
        public void SetMapVar(string hi)
        {
            MonoSingleton<MapVarManager>.Instance.SetString(variableName, curInputField.text);
        }
    }
}
