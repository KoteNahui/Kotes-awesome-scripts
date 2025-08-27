using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KotesAwesomeScripts.MapVarValueToComponentValue
{
    public class MapVarValueToComponentValue : MonoBehaviour
    {
        public ComponentPart[] componentParts;

        [SerializeField] private bool setOnEnable;
        [SerializeField] private bool setOnUpdate;

        private void OnEnable() { if (setOnEnable) { SetValues(); } }
        private void Update() { if (setOnUpdate) { SetValues(); } }
        public void SetValues()
        {
            foreach (ComponentPart part in componentParts)
            {
                Debug.Log("1 " + part.component.GetType());
                Debug.Log("2 " + part.component.GetType().GetProperty(part.componentVariable1));
                Debug.Log("3 " + part.componentVariable1);
                Debug.Log("4 " + part.component.GetType().GetProperty(part.componentVariable1).GetValue(part));
                Debug.Log("5 " + part.component.GetType().GetProperty(part.componentVariable1));
            }
        }
    }
}
[Serializable]
public struct ComponentPart
{
    [Header("Component")]
    public Component component;
    public string componentVariable1;
    public string componentVariable2;
    [Header("Variable")]
    public string variableName;
    public VariableType variableType;
}
