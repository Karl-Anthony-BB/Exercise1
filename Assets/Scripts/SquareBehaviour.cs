using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    private int rotationDirection;

    private void Start()
    {
        rotationDirection = Random.Range(0, 2);
    }

    private void Update()
    {
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
