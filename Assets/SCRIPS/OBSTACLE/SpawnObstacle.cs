using UnityEngine;
using UnityEngine.Rendering;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float heightRange = 0.5f;
    public float maxTime = 1.75f;
    public float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObstacleSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            ObstacleSpawn();
            timer = 0;
        }
    }

    public void ObstacleSpawn()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));

        GameObject newObstacle;

        newObstacle = Instantiate(obstacle, spawnPosition, Quaternion.identity);
        Destroy(newObstacle, 5.5f);
    }
}
