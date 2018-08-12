using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This goes on the camera. 
public class ObstacleSpawner : MonoBehaviour
{
    private float _SpawnXPos = 150.0f;
    private float _SpawnRate = 0.35f;

    private float _SpawnTimer = 0;

    [SerializeField]
    private GameObject _ObstaclePrefab = null;

    private const float _MinYRange = -25.0f;
    private const float _MaxYRange = 25.0f;

    private Stack<GameObject> _InstantiatedObstacles = null;
    private bool _AllowObstacleSpawns = false;
    private float _ObstacleSpawnDelay = 3.5f; // Seconds between game start and first obstacles start to spawn.

    protected void Start()
    {
        _InstantiatedObstacles = new Stack<GameObject>();
        _SpawnXPos = transform.position.x;

        for (int i = 0; i < 50; i++)
        {
            GameObject newObstacle = Instantiate(_ObstaclePrefab);
            newObstacle.GetComponent<Obstacle>().obstacleSpawner = this;
            _InstantiatedObstacles.Push(newObstacle);
        }
    }

    private void Update()
    {
        if (!_AllowObstacleSpawns)
        {
            _ObstacleSpawnDelay -= TimeAuthority.DeltaTime;

            if (_ObstacleSpawnDelay <= 0.0f)
            {
                _AllowObstacleSpawns = true;
            }
        }

        _SpawnTimer += TimeAuthority.DeltaTime;

        if (_SpawnTimer >= _SpawnRate)
        {
            _SpawnTimer = 0;
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        GameObject spawnedObstacle = _InstantiatedObstacles.Pop();

        float yPos = Random.Range(_MinYRange, _MaxYRange);

        _SpawnXPos = transform.position.x;
        spawnedObstacle.transform.position = new Vector3(_SpawnXPos, yPos, 0);
        spawnedObstacle.SetActive(true);

        Obstacle obstacleCompo = spawnedObstacle.GetComponent<Obstacle>();
        obstacleCompo.Randomize();
    }

    public void RecycleObstacle(GameObject instantiatedObject)
    {
        instantiatedObject.SetActive(false);
        _InstantiatedObstacles.Push(instantiatedObject);
    }
}
