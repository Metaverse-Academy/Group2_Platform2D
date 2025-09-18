using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int trapAmount = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void SpawnObject()
    {
        if (spawnPoints.Length == 0 || trapPrefab == null) return;

        for (int i = 0; i <= trapAmount; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            Instantiate(trapPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
