using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Alerta! Láser tocado. Game Over.");
            // Aquí puedes activar la pantalla de Game Over o reiniciar la escena
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
