using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GridBrushBase;

public class HexagonBehaviour : MonoBehaviour
{
    [SerializeField] private float translateSpeed = 0.08f;
    [SerializeField] private float rotationSpeed = 0.03f;
    [SerializeField] private float scaleModifier = 0.1f;
    [SerializeField] private float maxScaleLimit = 2.25f;
    [SerializeField] private float minScaleLimit = 0.7f;
    private int rotationDirection;

    private void Start()
    {
        rotationDirection = Random.Range(0, 2);
    }

    private void Update()
    {
        Translate();
        Rotate();
        Scale();
    }

    private void Translate()
    {
        transform.Translate(0f, -translateSpeed, 0f, Space.World);
    }

    private void Rotate()
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

    private void Scale()
    {
        if (transform.localScale.x <= maxScaleLimit)
        {
            float newXScale = transform.localScale.x + scaleModifier;
            float newYScale = transform.localScale.y + scaleModifier;
            transform.localScale = new Vector2(newXScale, newYScale);
        }
        else if (transform.localScale.x >= minScaleLimit)
        {
            float newXScale = transform.localScale.x - scaleModifier;
            float newYScale = transform.localScale.y - scaleModifier;
            transform.localScale = new Vector2(newXScale, newYScale);
        }
    }
}
