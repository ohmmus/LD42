using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk: MonoBehaviour
{
    private ChunkSpawner _ChunkSpawner = null;

    [SerializeField]
    private Transform _TopWall = null;

    [SerializeField]
    private Transform _BottomWall = null;
    
    private float _LifeTimer = 0;
    private float _LifeTimeDuration = 5.0f;

    public ChunkSpawner chunkSpawner
    {
        set
        {
            _ChunkSpawner = value;
        }
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Randomize(float currentSeparation)
    {
        _TopWall.position = new Vector3(_TopWall.position.x, currentSeparation, _TopWall.position.z);
        _BottomWall.position = new Vector3(_BottomWall.position.x, -currentSeparation, _BottomWall.position.z);
        _LifeTimer = _LifeTimeDuration;
    }

    private void Update()
    {
        _LifeTimer -= TimeAuthority.DeltaTime;

        if (_LifeTimer <= 0)
        {
            _ChunkSpawner.RecycleChunk(gameObject);
        }
    }
}
