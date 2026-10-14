using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    private bool isGameActive = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Estado inicial: Mostrar Menú Principal
        Time.timeScale = 0f; // Pausar el juego al inicio
        if (menuPanel) menuPanel.SetActive(true);
        if (gameplayUI) gameplayUI.SetActive(false);
        if (gameOverPanel) gameOverPanel.SetActive(false);
        if (victoryPanel) victoryPanel.SetActive(false);
    }

    // Llamado desde el botón PLAY del menú principal
    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1f; // Reanudar el tiempo

        if (menuPanel) menuPanel.SetActive(false);
        if (gameplayUI) gameplayUI.SetActive(true);
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0f; // Pausar juego

        if (gameOverPanel) gameOverPanel.SetActive(true);
    }

    public void Victory()
    {
        isGameActive = false;
        Time.timeScale = 0f; // Pausar juego

        if (victoryPanel) victoryPanel.SetActive(true);
    }

    // Llamado desde los botones REPLAY / EXIT
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
