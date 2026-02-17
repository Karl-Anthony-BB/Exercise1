using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GridBrushBase;

public class HexagonBehaviour : MonoBehaviour
{
    // Mieux, car elle conserve la protection des variables en meme temps d'etre visible dans l'inspecteur.

    // ===== Variables de modification
    private float translateSpeed;
    [SerializeField] private float maxTranslateSpeed = 0.008f;
    [SerializeField] private float minTranslateSpeed = 0.001f;

    private float rotationSpeed;
    [SerializeField] private float maxRotationSpeed = 0.007f;
    [SerializeField] private float minRotationSpeed = 0.005f;

    private float scaleAmount;
    [SerializeField] private float maxScaleAmount = 0.002f;
    [SerializeField] private float minScaleAmount = 0.001f;

    // ===== Variable de limite de taille
    [SerializeField] private float maxDesiredScale = 2.25f;
    [SerializeField] private float minDesiredScale = 0.7f;

    // ===== Variables de restriction
    private bool scalingUp = true;

    // ===== Variable de direction
    private int rotationDirection;

    // ===== Variables de fenetre
    private float distanceForTeleport = 10f;

    private void Start()
    {
        translateSpeed = Random.Range(minTranslateSpeed, maxTranslateSpeed);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationDirection = Random.Range(0, 2);
        scaleAmount = Random.Range(minScaleAmount, maxScaleAmount);
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
        Vector3 currentScale = transform.localScale;
        if (scalingUp)
        {
            float newXScale = transform.localScale.x + scaleAmount;
            float newYScale = transform.localScale.y + scaleAmount;
            transform.localScale = new Vector2(newXScale, newYScale);

            // Le scale augmente egalement du x et du y, donc utilise le x comme conditions marche
            if (currentScale.x >= maxDesiredScale)
            {
                scalingUp = false;
            }
        }
        else if (!scalingUp)
        {
            float newXScale = transform.localScale.x - scaleAmount;
            float newYScale = transform.localScale.y - scaleAmount;
            transform.localScale = new Vector2(newXScale, newYScale);

            if (currentScale.x <= minDesiredScale)
            {
                scalingUp = true;
            }
        }
    }
}
