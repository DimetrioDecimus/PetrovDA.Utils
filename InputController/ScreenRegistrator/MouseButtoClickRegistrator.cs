using PetrovDA.Utils.Interface;
using UnityEngine;

namespace PetrovDA.Utils.InputController.ScreenRegistrator
{
    public class MouseButtoClickRegistrator : AbstractScreenRegistrator
    {
        public override void Update()
        {
            if (Input.GetMouseButtonDown(index)) TriggerTouchBegin(index, Input.mousePosition);

            if (Input.GetMouseButtonUp(index)) TriggerTouchEnd(index, Input.mousePosition);
        }

    }
}