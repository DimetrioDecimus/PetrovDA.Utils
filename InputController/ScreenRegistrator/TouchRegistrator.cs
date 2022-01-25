using UnityEngine;

namespace PetrovDA.Utils.InputController.ScreenRegistrator
{
    public class TouchRegistrator : AbstractScreenRegistrator
    {
        public override void Update()
        {
            if (Input.touchCount <= 0)
            {
                return;
            }

            var touch = Input.GetTouch(index);

            if (touch.phase == TouchPhase.Began) TriggerTouchBegin(index, touch.position);

            if (touch.phase == TouchPhase.Ended) TriggerTouchEnd(index, touch.position);
        }
    }
}
