using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Gère les déplacement de la cible de caméra. La caméra est une Cinemachine qui a comme cible ce gameObject.
/// </summary>
public class CibleCamera : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    [SerializeField, Tooltip("Vitesse de déplacement en m/s")]
    private float vitesseDeplacement;

    [Header("Références aux objets de jeu")]
    [SerializeField, Tooltip("Le PlayerInput qui gère les actions de la personne qui joue")]
    private PlayerInput controles;

    [SerializeField, Tooltip("Zone de confinement de la caméra")]
    private BoxCollider volumeCamera;

    [SerializeField, Tooltip("La caméra qui suit la cible")]
    private CinemachineCamera cameraGeree;

    // Variables privées pour la gestion du déplacement
    /// <summary>
    /// Le deplacement actuel de la caméra
    /// </summary>
    private Vector2 deplacement;


    private void Start()
    {
        // Action de déplacement
        InputAction actionDeplacement = controles.actions.FindAction("player/DeplacerCamera");
        actionDeplacement.performed += CommencerDeplacement;
        actionDeplacement.canceled += TerminerDeplacement;
    }

    private void Update()
    {
        DeplacerCamera();
    }

    private void OnDestroy()
    {
        if (controles == null || controles.actions == null) { return; }

        // Retire les callbacks des actions pour éviter les fuites de mémoire
        InputAction actionDeplacement = controles.actions.FindAction("player/DeplacerCamera");
        actionDeplacement.performed -= CommencerDeplacement;
        actionDeplacement.canceled -= TerminerDeplacement;
    }

    #region Déplacement
    /// <summary>
    /// Commence le déplacement de la caméra
    /// </summary>
    /// <param name="contexte">Information du callback de l'action</param>
    private void CommencerDeplacement(InputAction.CallbackContext contexte)
    {
        deplacement = vitesseDeplacement * contexte.ReadValue<Vector2>();
    }

    /// <summary>
    /// Termine le déplacement de la caméra
    /// </summary>
    /// <param name="contexte">Information du callback de l'action</param>
    private void TerminerDeplacement(InputAction.CallbackContext contexte)
    {
        deplacement = Vector2.zero;
    }

    /// <summary>
    /// Gère le déplacement de la caméra en fonction de l'input du joueur et des limites du volume de la caméra
    /// </summary>
    private void DeplacerCamera()
    {
        if (deplacement.sqrMagnitude > 0.0f)
        {
            Vector3 prochainePosition = transform.position +
                transform.right * deplacement.x * Time.deltaTime +
                transform.forward * deplacement.y * Time.deltaTime;

            prochainePosition = Vector3.Scale(prochainePosition, new Vector3(1.0f, 0.0f, 1.0f));


            if (volumeCamera.bounds.Contains(prochainePosition))
            {
                transform.position = prochainePosition;
            }
        }
    }
}
    #endregion