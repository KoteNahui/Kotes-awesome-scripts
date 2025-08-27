using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Reflection;

namespace KotesAwesomeScripts.String
{
    public class ProceduralMapVarNamer : MonoBehaviour
    {
        [SerializeField]
        private MapVarSetter[] setters;
        [SerializeField]
        private MapIntWatcher[] intWatchers;
        [SerializeField]
        private MapFloatWatcher[] floatWatchers;
        [SerializeField]
        private MapBoolWatcher[] boolWatchers;
        [SerializeField]
        private MapStringWatcher[] stringWatchers;

        [SerializeField]
        private string prefix = "Thing_";

        [SerializeField]
        private GameObject namingObject;

        [SerializeField]
        private string suffix = "_Procedural";

        [SerializeField]
        private bool oneTime = true;
        private bool setAlready;
        
        [SerializeField]
        private bool setOnEnable = true;

        [SerializeField]
        private bool setEveryFrame;

        public void SetVariableNames()
        {
            if (oneTime && setAlready) return;

            setAlready = true;

            if (namingObject == null) namingObject = gameObject;

            string newVarName = prefix + namingObject.name + suffix;
            foreach (MapVarSetter setter in setters)
            {
                setter.variableName = newVarName;
            }
            foreach (MapIntWatcher watcher in intWatchers)
            {
                FieldInfo varName = watcher.GetType().BaseType.GetField("variableName", BindingFlags.NonPublic | BindingFlags.Instance);
                varName.SetValue(watcher, newVarName);
            }
            foreach (MapFloatWatcher watcher in floatWatchers)
            {
                FieldInfo varName = watcher.GetType().BaseType.GetField("variableName", BindingFlags.NonPublic | BindingFlags.Instance);
                varName.SetValue(watcher, newVarName);
            }
            foreach (MapBoolWatcher watcher in boolWatchers)
            {
                FieldInfo varName = watcher.GetType().BaseType.GetField("variableName", BindingFlags.NonPublic | BindingFlags.Instance);
                varName.SetValue(watcher, newVarName);
            }
            foreach (MapStringWatcher watcher in stringWatchers)
            {
                FieldInfo varName = watcher.GetType().BaseType.GetField("variableName", BindingFlags.NonPublic | BindingFlags.Instance);
                varName.SetValue(watcher, newVarName);
            }
        }
        private void OnEnable()
        {
            if (setOnEnable) SetVariableNames();
        }
        private void Update()
        {
            if (setEveryFrame) SetVariableNames();
        }
    }
}
