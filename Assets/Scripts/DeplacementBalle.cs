using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementBalle : MonoBehaviour
{
    private Rigidbody rb;
    public float forceMagnitude = 20f;
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

        if(GestionnaireCamera.Instance != null)
        {
            GestionnaireCamera.Instance.ActiverCameraBalle();
        }

    }
}
