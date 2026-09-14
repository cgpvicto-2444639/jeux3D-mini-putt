using UnityEngine;

public class SuiviPositionBalle : MonoBehaviour
{
    [SerializeField, Tooltip("Référence au Transform de la balle à suivre")]
    private Transform cibleBalle;

    private void LateUpdate()
    {
        if (cibleBalle != null)
        {
            transform.position = cibleBalle.position;
        }
    }
}