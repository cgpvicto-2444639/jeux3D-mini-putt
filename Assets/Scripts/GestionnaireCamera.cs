using Unity.Cinemachine;
using UnityEngine;

public class GestionnaireCamera : MonoBehaviour
{
    public static GestionnaireCamera Instance { get; private set; }

    [Header("Caméras Cinemachine")]
    [SerializeField, Tooltip("La caméra Cinemachine qui suit la Balle")]
    private CinemachineCamera cameraBalle;

    [SerializeField, Tooltip("La caméra Cinemachine qui suit la Cible Camera")]
    private CinemachineCamera cameraCible;

    [Header("Priorités")]
    [SerializeField] private int prioriteActive = 10;
    [SerializeField] private int prioriteInactive = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // On commence par cibler la Cible Camera (vue libre)
        ActiverCameraCible();
    }

    /// <summary>
    /// Bascule la vue sur la Cible Camera (navigation du joueur)
    /// </summary>
    public void ActiverCameraCible()
    {
        cameraCible.Priority = prioriteActive;
        cameraBalle.Priority = prioriteInactive;
    }

    /// <summary>
    /// Bascule la vue sur la Balle lorsque celle-ci est lancée
    /// </summary>
    public void ActiverCameraBalle()
    {
        cameraBalle.Priority = prioriteActive;
        cameraCible.Priority = prioriteInactive;
    }
}