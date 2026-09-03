using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementBalle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    public float forceMagnitude = 20f;
    private bool doitLancer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            LancerBalle();
    }

    void LancerBalle()
    {
        if (rb != null)
            rb.AddForce(Vector3.right * forceMagnitude);

    }
}
