using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk: MonoBehaviour
{
    private ChunkSpawner _ChunkSpawner = null;

    public ChunkSpawner chunkSpawner
    {
        set
        {
            _ChunkSpawner = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("MORE HI: " + other.name);
        _ChunkSpawner.RecycleChunk(gameObject);
    }
}
