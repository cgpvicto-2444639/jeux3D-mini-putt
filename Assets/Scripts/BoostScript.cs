using UnityEngine;

public class BoostScript : MonoBehaviour
{
    public float boostForce = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.GetComponent<Rigidbody>() != null)
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            if(ballRb != null)
            {
                ballRb.AddForce(Vector3.right * boostForce, ForceMode.Impulse);
            }
        }
    }
}
