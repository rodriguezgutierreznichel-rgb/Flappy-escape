using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTime = 2.5f;
    [SerializeField] float xSpawnPosition = 12f;
    [SerializeField] float minYPosition = -2f;
    [SerializeField] float maxYPosition = 3f;

    
    private float timeElapsed;
    private int obstacleCount;
    private GameObject[] obstacles;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacles = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);
            obstacles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > spawnTime)
        {
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        timeElapsed = 0f;

        float ySpawnRandom = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnRandom);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if (!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);
        }

        
        obstacleCount++;

        if (obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
