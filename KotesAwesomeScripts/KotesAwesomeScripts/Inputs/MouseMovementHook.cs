using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace KotesAwesomeScripts.Inputs
{
    public class MouseMovementHook
    {
        public UnityEventFloat OnLeftDrag, OnRightDrag, OnUpDrag, OnDownDrag;

        private void Update()
        {
            if (Input.GetAxisRaw("Mouse X") < 0)
            {
                OnLeftDrag?.Invoke(Input.GetAxisRaw("Mouse X"));
            }
            else if (Input.GetAxisRaw("Mouse X") > 0)
            {
                OnRightDrag?.Invoke(Input.GetAxisRaw("Mouse X"));
            }
            if (Input.GetAxisRaw("Mouse Y") < 0)
            {
                OnDownDrag?.Invoke(Input.GetAxisRaw("Mouse Y"));
            }
            else if (Input.GetAxisRaw("Mouse Y") > 0)
            {
                OnUpDrag?.Invoke(Input.GetAxisRaw("Mouse Y"));
            }
        }
    }
}
