using PetrovDA.Utils.Interface;
using UnityEngine;

namespace PetrovDA.Utils.InputController.ScreenRegistrator
{
    public abstract class AbstractScreenRegistrator : IMonoBehaviourUpdate
    {
        public const int MOUSE_BUTTON_INDEX_LEFT  = 0;
        public const int MOUSE_BUTTON_INDEX_RIGHT = 1;

        protected int index;
        public int MouseButtonIndex { get => index; set => index = value; }

        public delegate void ScreenWork(int index, Vector3 position);

        public event ScreenWork ScreenTouchBeginEvent;
        public event ScreenWork ScreenTouchEndEvent;

        public abstract void Update();

        protected void TriggerTouchBegin(int index, Vector3 position) => ScreenTouchBeginEvent?.Invoke(index, position);

        protected void TriggerTouchEnd(int index, Vector3 position) => ScreenTouchEndEvent?.Invoke(index, position);
    }
}