using UnityEngine;

public class SuiviPositionBalle : MonoBehaviour
{
    [SerializeField, Tooltip("Référence au Transform de la balle à suivre")]
    private Transform cibleBalle;

    private void LateUpdate()
    {
        if (cibleBalle != null)
        {
            // Copie uniquement la position, la rotation de cet objet reste fixe
            transform.position = cibleBalle.position;
        }
    }
}