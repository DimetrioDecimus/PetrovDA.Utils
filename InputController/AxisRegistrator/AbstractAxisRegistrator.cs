using PetrovDA.Utils.Interface;
using UnityEngine;

namespace PetrovDA.Utils.InputController.AxisRegistrator
{
    public abstract class AbstractAxisRegistrator : IMonoBehaviourUpdate
    {
        public delegate void DirectionAxis(Vector3 direction);

        public event DirectionAxis DirectionChangeEvent;

        public abstract void Update();
        protected void TriggerDirectionChangeEvent(Vector3 direction) => DirectionChangeEvent?.Invoke(direction);
        
    }
}