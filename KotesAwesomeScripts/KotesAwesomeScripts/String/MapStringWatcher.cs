using Logic;
using System;
using UnityEngine;

namespace KotesAwesomeScripts.String
{
    [DefaultExecutionOrder(10)]
    public class MapStringWatcher : MapVarWatcher<string?>
    {
        [SerializeField]
        private StringWatchMode watchMode;

        [SerializeField]
        private bool caseSensitive = true;

        [Tooltip("If bellow 0, this variable is ignored.")]
        [SerializeField]
        private int indexToWatch = -1;

        [SerializeField]
        private UnityEventString onConditionMetWithValue;

        [SerializeField]
        private string targetValue = "Hello BREAK";

        private string? lastValue;
        private bool oldCaseSensCheck;
        private void OnEnable()
        {
            if (!registered)
            {
                if (MonoSingleton<MapVarManager>.Instance == null)
                {
                    Debug.LogError("Unable to register MapStringWatcher. Missing map variable manager.");
                    return;
                }
                MonoSingleton<MapVarManager>.Instance.RegisterStringWatcher(variableName, delegate (string val)
                {
                    ProcessEvent(val);
                });
                registered = true;
            }
            if (evaluateOnEnable)
            {
                ProcessEvent(MonoSingleton<MapVarManager>.Instance.GetString(variableName));
            }
        }
        private void Update()
        {
            if (continuouslyActivateOnSuccess && lastState)
            {
                CallEvents();
            }
            if (caseSensitive != oldCaseSensCheck)
            {
                oldCaseSensCheck = caseSensitive;
                lastValue = string.Empty;
                ProcessEvent(MonoSingleton<MapVarManager>.Instance.GetString(variableName));
            }
        }
        protected override void ProcessEvent(string? value)
        {
            base.ProcessEvent(value);
            if (lastValue != value)
            {
                lastValue = value;
                bool flag = EvaluateState(value);
                if (watchMode == StringWatchMode.AnyChange || flag != lastState)
                {
                    lastState = flag;
                    CallEvents();
                }
            }
        }
        protected override bool EvaluateState(string? newValue)
        {
            switch (watchMode)
            {
                case StringWatchMode.Matches:
                    {
                        if (indexToWatch < 0)
                        {
                            return newValue.Equals(targetValue, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
                        }
                        else
                        {
                            char[] targetChars = targetValue.ToCharArray();
                            foreach (char value in targetChars)
                            {
                                if (newValue[indexToWatch].ToString().Equals(value.ToString(),
                                    caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
                                {
                                    return true;
                                }
                                else continue;
                            }
                        }
                        return false;
                    }


                case StringWatchMode.Contains:
                    // if (newValue("aBC") contains targetValue("B") in 1) return true, else return false
                    {
                        if (indexToWatch < 0)
                        {
                            return newValue.Contains(targetValue, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
                        }
                        else
                        {
                            char[] targetChars = targetValue.ToCharArray();
                            foreach (char value in targetChars)
                            {
                                if (newValue[indexToWatch].ToString().Equals(value.ToString(),
                                    caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
                                {
                                    return true;
                                }
                                else continue;
                            }
                        }
                        return false;
                    }
                case StringWatchMode.AnyChange:
                    return newValue != string.Empty;
                default:
                    return false;
            }
        }
        protected override void CallEvents()
        {
            base.CallEvents();
            onConditionMetWithValue.Invoke(lastValue);
        }
    }
}
public enum StringWatchMode
{
    Matches = 0,
    Contains = 1,
    AnyChange = 2,
}

