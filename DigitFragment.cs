using UnityEngine;

public class DigitFragment : MonoBehaviour
{
    public int digitValue; // Valor numérico (0-9)
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        // Rotación elegante del número gigante de neón
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Envía el dígito al colector central
            CodeCollector.Instance.AddDigit(digitValue);
            
            // Efecto visual de recolección con LeanTween antes de destruir
            LeanTween.scale(gameObject, Vector3.zero, 0.2f).setOnComplete(() => {
                Destroy(gameObject);
            });
        }
    }
}
