using UnityEngine;
using UnityEngine.InputSystem;
// Référence: https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html et https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
public class BouncyScript : MonoBehaviour
{
    public float bounceForce = 0.3f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            if(ballRb != null)
            {
                ballRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
