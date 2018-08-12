using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _ChunkPrefab = null;

    private Transform _ChunkSpawnTransform = null;

    private float _CurrentSeparationDistance = 70.0f; 

    [SerializeField]
    private float _SpawnRate = 3.0f;

    private float _SpawnTimer = 0.0f;

    private Stack<GameObject> _InstantiatedChunks = null;

    private float _MinimumSeparationDistance = 80;
    private float _MaximumSeparationDistance = 90;

    private float _CurrentMaxSepDistance = 0;

    protected void Start()
    {
        _InstantiatedChunks = new Stack<GameObject>();
        _ChunkSpawnTransform = transform;

        for (int i = 0; i < 50; i++)
        {
            GameObject newChunk = Instantiate(_ChunkPrefab);
            newChunk.GetComponent<Chunk>().chunkSpawner = this;
            _InstantiatedChunks.Push(newChunk);
        }

        _CurrentSeparationDistance = Random.Range(_MinimumSeparationDistance, _MaximumSeparationDistance);
        _CurrentMaxSepDistance = _MaximumSeparationDistance;
    }

    protected void Update()
    {
        _SpawnTimer += TimeAuthority.DeltaTime;

        if (_SpawnTimer >= _SpawnRate)
        {
            _SpawnRate = Mathf.Clamp(_SpawnRate, 0.3f, 10.0f);

            _SpawnTimer = 0;
            SpawnChunk();
            _CurrentSeparationDistance = Random.Range(_MinimumSeparationDistance, _CurrentMaxSepDistance -= TimeAuthority.DeltaTime);
            _CurrentMaxSepDistance = Mathf.Clamp(_CurrentMaxSepDistance, _MinimumSeparationDistance + 10, _CurrentMaxSepDistance);
        }
    }

    public void SpawnChunk()
    {
        GameObject spawnedChunk = _InstantiatedChunks.Pop();
        spawnedChunk.transform.position = new Vector3(_ChunkSpawnTransform.position.x, 0, 0);
        spawnedChunk.SetActive(true);

        Chunk chunkCompo = spawnedChunk.GetComponent<Chunk>();
        chunkCompo.Randomize(_CurrentSeparationDistance);
    }

    public void RecycleChunk(GameObject instantiatedObject)
    {
        instantiatedObject.SetActive(false);
        _InstantiatedChunks.Push(instantiatedObject);
    }
}
