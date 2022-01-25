using System.Collections;
using UnityEngine;

namespace PetrovDA.Utils.InputController.AxisRegistrator
{
    public class KeyboardAxisRegistrator : AbstractAxisRegistrator
    {
        private const string DIRECTION_HORIZONTAL = "Horizontal";
        private const string DIRECTION_VERTICAL = "Vertical";

        public override void Update()
        {
            Vector3 newDirection = new Vector3(Input.GetAxis(DIRECTION_HORIZONTAL), 0, Input.GetAxis(DIRECTION_VERTICAL));
            if (newDirection != Vector3.zero) TriggerDirectionChangeEvent(newDirection);
        }
    }
}