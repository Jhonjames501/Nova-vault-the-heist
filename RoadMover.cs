using UnityEngine;

public class RoadMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float resetZPosition = -50f;
    [SerializeField] private float startZPosition = 100f;

    void Update()
    {
        // Mueve el segmento de pista hacia atrás
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Bucle infinito de la pista
        if (transform.position.z < resetZPosition)
        {
            Vector3 pos = transform.position;
            pos.z = startZPosition;
            transform.position = pos;
        }
    }
}
