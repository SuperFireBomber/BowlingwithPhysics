using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {

        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
        

        if (ballRigidBody == null) return;


        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;


        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;


        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
}
