using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _LifeTimer = 0;
    private float _LifeTimeDuration = 5.0f;
    private ObstacleSpawner _ObstacleSpawner = null;
    private GrowthController _GrowthComponent = null;

    [SerializeField]
    private GameObject _NormalCubesContainer = null;

    [SerializeField]
    private GameObject _ExplosionCubesContainer = null;

    public ObstacleSpawner obstacleSpawner
    {
        set
        {
            _ObstacleSpawner = value;
        }
    }

    public void Start()
    {
        _GrowthComponent = GetComponent<GrowthController>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _LifeTimer -= TimeAuthority.DeltaTime;

        if (_LifeTimer <= 0)
        {
            _ObstacleSpawner.RecycleObstacle(gameObject);
        }
    }

    public void Randomize()
    {
        _GrowthComponent.RandomizeGrowthParams();
        _LifeTimer = _LifeTimeDuration;
    }
}
