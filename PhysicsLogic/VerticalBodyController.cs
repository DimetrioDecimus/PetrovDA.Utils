using UnityEngine;
using PetrovDA.Utils.PhysicsLogic.Axis;
using PetrovDA.Utils.Interface;

namespace PetrovDA.Utils.PhysicsLogic
{
    public class VerticalBodyController : IMonoBehaviourFixedUpdate
    {
        VerticalController verticalController;

        public VerticalBodyController(
            Transform transformToSet, 
            Rigidbody rigidbodyToSet, 
            float springStrength, 
            float dampferStrength
            )
        {
            var transform = transformToSet;
            var rigidBody = rigidbodyToSet;

            //TODO: replace to config
            var layerMask = 1;
            var modelMaxHeight = transform.position.y;

            verticalController = new VerticalController(
                transform,
                rigidBody,
                springStrength,
                modelMaxHeight,
                dampferStrength,
                layerMask
                );
        }

        public void FixedUpdate()
        {
            verticalController.FixedUpdate();
        }

        
    }
}

