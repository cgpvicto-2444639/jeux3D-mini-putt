using UnityEngine;

public class StickyScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Rigidbody ballRb = other.GetComponent<Rigidbody>();
        if(ballRb != null)
        {
            ballRb.linearDamping = 10f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody ballRb = other.GetComponent<Rigidbody>();
        if(ballRb != null)
        {
            ballRb.linearDamping = 0.05f;
        }
    }
}
