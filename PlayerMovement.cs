using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Lane Settings")]
    [SerializeField] private float[] lanePositions = { -2.5f, 0f, 2.5f }; // Izquierda, Centro, Derecha
    private int currentLaneIndex = 1; // Inicia en el centro
    [SerializeField] private float smoothTime = 0.15f;
    private float targetXPosition;
    private float currentVelocityX;

    [Header("Movement & Speed")]
    public float forwardSpeed = 40f; // Velocidad de avance (20-120 km/h mapeado)

    void Start()
    {
        targetXPosition = lanePositions[currentLaneIndex];
    }

    void Update()
    {
        HandleInput();
        MoveToTargetLane();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLaneIndex > 0)
            {
                currentLaneIndex--;
                UpdateTargetPosition();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLaneIndex < lanePositions.Length - 1)
            {
                currentLaneIndex++;
                UpdateTargetPosition();
            }
        }
    }

    void UpdateTargetPosition()
    {
        targetXPosition = lanePositions[currentLaneIndex];
    }

    void MoveToTargetLane()
    {
        float newX = Mathf.SmoothDamp(transform.position.x, targetXPosition, ref currentVelocityX, smoothTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
