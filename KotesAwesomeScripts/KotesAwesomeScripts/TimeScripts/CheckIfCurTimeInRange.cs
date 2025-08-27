using Logic;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.TimeScripts
{
    public class CheckIfCurTimeInRange : MonoBehaviour
    {
        public bool compareOnEnable;
        public bool compareEveryFrame;

        [Space]
        public string start = "MM/DD/YYYY HH:MM:SS";
        public string end = "MM/DD/YYYY HH:MM:SS";

        [Space]
        public UnityEvent onSuccess;
        public UnityEvent onFailure;

        public void CompareTime()
        {
            if ((DateTime.UtcNow >= DateTime.Parse(start))
                && (DateTime.UtcNow <= DateTime.Parse(end)))
            {
                onSuccess.Invoke();
            }
            else onFailure.Invoke();
        }

        private void OnEnable() { if (compareOnEnable) { CompareTime(); } }
        private void Update() { if (compareEveryFrame) { CompareTime(); } }
    }
}
