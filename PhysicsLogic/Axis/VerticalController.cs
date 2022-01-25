using UnityEngine;
using PetrovDA.Utils.Interface;

namespace PetrovDA.Utils.PhysicsLogic.Axis
{
    public class VerticalController : IMonoBehaviourFixedUpdate
    {
        int layerMask;
        float springStrength;
        float modelMaxHeight;
        float rayCastMaxDistance;
        float dampferStrength;

        Transform transform;
        Rigidbody rigidBody;

        public VerticalController(
            Transform transformToSet, 
            Rigidbody rigidBodyToSet,
            float springStrengthToSet,
            float modelMaxHeightToSet,
            float dampferStrengthToSet,
            int layerMaskToSet
            )
        {
            transform = transformToSet;
            rigidBody = rigidBodyToSet;
            layerMask = layerMaskToSet;
            springStrength = springStrengthToSet;
            modelMaxHeight = modelMaxHeightToSet;
            dampferStrength = dampferStrengthToSet;
            rayCastMaxDistance = modelMaxHeightToSet * 50;
        }

        public void FixedUpdate()
        {
#if UNITY_EDITOR
            Debug.DrawRay(transform.position, Vector3.down * rayCastMaxDistance, Color.red);
#endif

            RaycastHit rayHit;
            if (!Physics.Raycast(transform.position, Vector3.down, out rayHit, rayCastMaxDistance, layerMask)) {
                return;
            }

            float height = rayHit.distance - modelMaxHeight;
            //Debug.Log("distance " + rayHit.distance);
            //Debug.Log("modelMaxHeight " + modelMaxHeight);
            (float force, Vector3 directionOfReaction) = CountForce(height);

            rigidBody.AddForce(directionOfReaction * force);
            
        }

        private (float, Vector3) CountForce(float heightDiff)
        {
            Vector3 forceDirection = heightDiff > 0 ? Vector3.down : Vector3.up;
            float downVelocity = Vector3.Dot(forceDirection, rigidBody.velocity);
            float force = Mathf.Abs(heightDiff * springStrength) - downVelocity * dampferStrength;
            //Debug.Log("downVelocity " + downVelocity);
            //Debug.Log("heightDiff " + heightDiff);
            //Debug.Log("force " + (heightDiff * springStrength - downVelocity));
            return (
                force,
                forceDirection
                );
        }
    }
}

