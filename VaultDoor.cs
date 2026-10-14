using UnityEngine;

public class VaultDoor : MonoBehaviour
{
    public static VaultDoor Instance;

    [Header("Vault Animation Settings")]
    [SerializeField] private Transform doorLeftPanel;
    [SerializeField] private Transform doorRightPanel;
    [SerializeField] private ParticleSystem orangeSparkParticles;
    [SerializeField] private GameObject victoryCanvas;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void OpenVault()
    {
        // Activar partículas naranjas de apertura
        if (orangeSparkParticles != null)
        {
            orangeSparkParticles.Play();
        }

        // Animación elegante de apertura con LeanTween
        if (doorLeftPanel != null)
        {
            LeanTween.moveLocalX(doorLeftPanel.gameObject, doorLeftPanel.localPosition.x - 4f, 1.5f)
                .setEase(LeanTweenType.easeInOutQuad);
        }

        if (doorRightPanel != null)
        {
            LeanTween.moveLocalX(doorRightPanel.gameObject, doorRightPanel.localPosition.x + 4f, 1.5f)
                .setEase(LeanTweenType.easeInOutQuad)
                .setOnComplete(ShowVictoryScreen);
        }
    }

    void ShowVictoryScreen()
    {
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
            // Animación de aparición de la UI de victoria estilo premium
            victoryCanvas.transform.localScale = Vector3.zero;
            LeanTween.scale(victoryCanvas, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutBack);
        }
    }
}
