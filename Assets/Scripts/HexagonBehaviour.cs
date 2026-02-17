using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GridBrushBase;

public class HexagonBehaviour : MonoBehaviour
{
    // Mieux, car elle conserve la protection des variables en meme temps d'etre visible dans l'inspecteur.

    // ===== Variables de vitesse
    [SerializeField] private float translateSpeed = 0.08f;
    [SerializeField] private float rotationSpeed = 0.03f;
    [SerializeField] private float scaleSpeed = 0.1f;

    // ===== Variable de limite d'ecran
    [SerializeField] private float maxScaleLimit = 2.25f;
    [SerializeField] private float minScaleLimit = 0.7f;

    // ===== Variable de direction
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

    // ===== Mouvement haut en bas =====
    private void Translate()
    {
        transform.Translate(0f, -translateSpeed, 0f, Space.World);
    }

    // ===== Rotation =====
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

    // ===== Changement de scale =====
    private void Scale()
    {
        if (transform.localScale.x <= maxScaleLimit)
        {
            float newXScale = transform.localScale.x + scaleSpeed;
            float newYScale = transform.localScale.y + scaleSpeed;
            transform.localScale = new Vector2(newXScale, newYScale);
        }

        if (transform.localScale.x >= minScaleLimit)
        {
            float newXScale = transform.localScale.x - scaleSpeed;
            float newYScale = transform.localScale.y - scaleSpeed;
            transform.localScale = new Vector2(newXScale, newYScale);
        }
    }
}
