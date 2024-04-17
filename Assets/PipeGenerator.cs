using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipeUpperPrefab;
    public GameObject pipeLowerPrefab;
    public float spawnRate = 1.5f; // Temps en secondes entre chaque génération de tuyaux
    public float pipeVerticalMoveRange = 2.5f; // Amplitude de déplacement vertical pour la position des tuyaux
    public float gapSize = 11.6f; // Taille de l'espace vertical entre les deux tuyaux
    private float screenWidthInWorldUnits;
    private float timeSinceLastSpawned;
    public BirdMovement bm;

    void Start()
    {
        timeSinceLastSpawned = 0f;
        // Calcule la largeur de l'écran en unités du monde
        float halfCameraWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenWidthInWorldUnits = halfCameraWidth * 2;
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate && bm.isStart)
        {
            timeSinceLastSpawned = 0f;

            float centerPositionY = Random.Range(-pipeVerticalMoveRange, pipeVerticalMoveRange);
            float lowerPipeSpawnYPosition = centerPositionY - gapSize / 2;
            float upperPipeSpawnYPosition = centerPositionY + gapSize / 2;

            // Spawn les tuyaux en dehors de l'écran sur le côté droit
            Vector3 spawnPosition = new Vector3(screenWidthInWorldUnits / 2 + 1f, 0f, 0f);

            GameObject lowerPipe = Instantiate(pipeLowerPrefab, spawnPosition + new Vector3(0, lowerPipeSpawnYPosition, 0f), Quaternion.identity);
            GameObject upperPipe = Instantiate(pipeUpperPrefab, spawnPosition + new Vector3(0, upperPipeSpawnYPosition, 0f), Quaternion.Euler(0, 0, 180));

            // Optionnel: Détruit les tuyaux après un certain temps pour libérer de la mémoire
            Destroy(lowerPipe, 10f);
            Destroy(upperPipe, 10f);
        }
    }
}
