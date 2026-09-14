using UnityEngine;

/// <summary>
/// Masque automatiquement le drapeau quand la balle entre dans la zone autour du trou.
/// </summary>
public class ZoneDrapeau : MonoBehaviour
{
    [SerializeField] private GameObject visuelDrapeau;

    private void OnTriggerEnter(Collider autre)
    {
        if (autre.CompareTag("Player") || autre.GetComponent<Rigidbody>() != null)
        {
            if (visuelDrapeau != null) visuelDrapeau.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider autre)
    {
        if (autre.CompareTag("Player") || autre.GetComponent<Rigidbody>() != null)
        {
            if (visuelDrapeau != null) visuelDrapeau.SetActive(true);
        }
    }
}