using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField]
    private float _StartingSeparationDistance = 1.0f;

    [SerializeField]
    private GameObject _ChunkPrefab = null;

    private Transform _ChunkSpawnTransform = null;

    private float _CurrentSeparationDistance = 50.0f;

    [SerializeField]
    private float _SpawnRate = 1.0f;

    private float _SpawnTimer = 0.0f;

    private Stack<GameObject> _InstantiatedChunks = null;

    private float _MinimumSeparationDistance = 20;

    protected void Start()
    {
        _InstantiatedChunks = new Stack<GameObject>();
        _ChunkSpawnTransform = transform;

        for (int i = 0; i < 50; i++)
        {
            GameObject newChunk = Instantiate(_ChunkPrefab); ;
            newChunk.SetActive(false);
            newChunk.GetComponent<Chunk>().chunkSpawner = this;
            _InstantiatedChunks.Push(newChunk);
        }
    }

    protected void Update()
    {
        _SpawnTimer += TimeAuthority.DeltaTime;

        if (_SpawnTimer >= _SpawnRate)
        {
            _SpawnTimer = 0;
            SpawnChunk();
            _CurrentSeparationDistance = Mathf.Clamp(--_CurrentSeparationDistance, _MinimumSeparationDistance, _CurrentSeparationDistance);
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
