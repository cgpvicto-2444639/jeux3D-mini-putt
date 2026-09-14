using System.Collections;
using UnityEngine;

/// <summary>
/// Gère la détection de la balle dans le trou, attend qu'elle tombe, puis la téléporte.
/// </summary>
public class Trou : MonoBehaviour
{
    [Header("Points de réapparition")]
    [SerializeField, Tooltip("Le Transform représentant le point de départ du parcours")]
    private Transform pointDeDepart;

    [Header("Drapeau")]
    [SerializeField, Tooltip("Le GameObject du drapeau à masquer lorsque la balle s'approche")]
    private GameObject drapeau;

    [Header("Paramètres d'attente")]
    [SerializeField, Tooltip("Temps d'attente en secondes avant de téléporter la balle")]
    private float delaiAvantTeleportation = 1.5f;

    private bool estEnTrainDeTeleporter = false;

    private void OnTriggerEnter(Collider autreObjet)
    {
        if (!estEnTrainDeTeleporter && (autreObjet.CompareTag("Player") || autreObjet.GetComponent<Rigidbody>() != null))
        {
            StartCoroutine(SequenceTeleportation(autreObjet.gameObject));
        }
    }

    /// <summary>
    /// Séquence qui laisse la balle tomber dans le trou avant de réinitialiser le jeu.
    /// </summary>
    private IEnumerator SequenceTeleportation(GameObject balle)
    {
        estEnTrainDeTeleporter = true;

        if (drapeau != null)
        {
            drapeau.SetActive(false);
        }

        yield return new WaitForSeconds(delaiAvantTeleportation);

        Rigidbody rb = balle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (pointDeDepart != null)
        {
            balle.transform.position = pointDeDepart.position + Vector3.up * 0.1f;
            balle.transform.rotation = pointDeDepart.rotation;
        }
        else
        {
            Debug.LogWarning("Le point de départ n'est pas assigné sur le trou !");
        }

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        if (drapeau != null)
        {
            drapeau.SetActive(true);
        }

        if (GestionnaireCamera.Instance != null)
        {
            GestionnaireCamera.Instance.ActiverCameraCible();
        }

        estEnTrainDeTeleporter = false;
    }
}