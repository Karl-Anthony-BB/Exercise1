using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    // ===== Vitesse
    [SerializeField] private float rotationSpeed = 2f;

    // ===== Direction
    private int rotationDirection;

    private void Start()
    {
        rotationDirection = Random.Range(0, 2);
    }

    private void Update()
    {
        // ===== Rotation =====
        if (rotationDirection == 0)
        {
            transform.Rotate(0f, 0f, rotationSpeed);
        }
        else if (rotationDirection == 1)
        {
            transform.Rotate(0f, 0f, -rotationSpeed);
        }
    }
}
