using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GridBrushBase;

public class HexagonBehaviour : MonoBehaviour
{
    // Mieux, car elle conserve la protection des variables en meme temps d'etre visible dans l'inspecteur.

    // ===== Variables de modification
    [Header("Movement Stats")]
    [SerializeField] private float maxTranslateSpeed = 0.008f;
    [SerializeField] private float minTranslateSpeed = 0.001f;
    [SerializeField] private float maxRotationSpeed = 0.007f;
    [SerializeField] private float minRotationSpeed = 0.005f;
    [SerializeField] private float maxScaleAmount = 0.002f;
    [SerializeField] private float minScaleAmount = 0.001f;

    private float scaleAmount;
    private float translateSpeed;
    private float rotationSpeed;

    // ===== Variable de limite de taille
    [Header("Scale Stats")]
    [SerializeField] private float maxDesiredScale = 2.25f;
    [SerializeField] private float minDesiredScale = 0.7f;

    // ===== Variables de restriction
    private bool scalingUp = true;

    // ===== Variable de direction
    private int rotationDirection;

    // ===== Variables de teleportation
    [Header("Warp Stats")]
    [SerializeField] private float distanceForWarp = -10f;
    [SerializeField] private float warpYPos = 10f;

    // ===== Variables position de spawn
    [Header("Spawn Location")]
    [SerializeField] private float spawnXPos;
    private float spawnYPos;



    private void Start()
    {
        Spawn();

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
        Warp();
    }

    // ===== Position de spawn =====
    private void Spawn()
    {
        // Rend le y de spawn egal a celle du warp
        spawnYPos = warpYPos;

        transform.position = new Vector2(spawnXPos, spawnYPos);
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

    // ===== Teleportation de l'autre cote de la fenetre
    private void Warp()
    {
        if (transform.position.y <= distanceForWarp)
        {
            transform.position = new Vector2(transform.position.x, warpYPos);
        }
    }
}
