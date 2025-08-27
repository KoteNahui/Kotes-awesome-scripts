using System;
using UnityEngine;

namespace KotesAwesomeScripts.LineRendererScripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class SetLrIndexPosToTransform : MonoBehaviour
    {
        private LineRenderer lr;

        public bool setOnEnable;
        public bool setEveryFrame;

        [Space]
        public Entries[] entries;
        
        public void SetPositions()
        {
            foreach (var entry in entries)
            {
                if (entry.transformPos == null) { throw new Exception("TransformPos has not been set on one of entries"); }
                lr.SetPosition(entry.index, entry.transformPos.position);
            }
        }
        private void Start()
        {
            lr = GetComponent<LineRenderer>();
            lr.useWorldSpace = true;
        }
        private void Update() { if (setEveryFrame) { SetPositions(); } }
        private void OnEnable() { if (setOnEnable) { SetPositions(); } }
    }
    [Serializable]
    public struct Entries
    {
        public int index;
        public Transform transformPos;
    }
}
