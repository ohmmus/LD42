using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _LifeTimer = 0;
    private float _LifeTimeDuration = 1.15f;
    private ObstacleSpawner _ObstacleSpawner = null;
    private GrowthController _GrowthComponent = null;

    [SerializeField]
    private GameObject _NormalCubesContainer = null;

    [SerializeField]
    private Exploder _ExplosionCubesContainer = null;

    private Transform _TransformComp = null;

    private float _RotationSpeed = 720.0f;

    private bool _Exploding = false;
    private float _ExplodeDuration = 4.0f;
    private float _ExplodeTimer = 0.0f;

    public ObstacleSpawner obstacleSpawner
    {
        set
        {
            _ObstacleSpawner = value;
        }
    }

    public void Start()
    {
        _TransformComp = transform;
        _GrowthComponent = GetComponent<GrowthController>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _LifeTimer -= TimeAuthority.DeltaTime;

        if (!_Exploding && _LifeTimer <= 0)
        {
            Explode();
        }
        
        if (_Exploding)
        {
            _ExplodeTimer -= TimeAuthority.DeltaTime;

            if (_ExplodeTimer <= 0)
            {
                BlipShatterPieces();
                _ObstacleSpawner.RecycleObstacle(gameObject);
            }
        }

        _TransformComp.Rotate(Vector3.forward, _RotationSpeed * TimeAuthority.DeltaTime);
    }

    private void BlipShatterPieces()
    {
        _ExplosionCubesContainer.CleanUpShatterPieces();
        _NormalCubesContainer.SetActive(true);
        _ExplosionCubesContainer.gameObject.SetActive(false);
    }

    private void Explode()
    {
        _NormalCubesContainer.SetActive(false);
        _ExplosionCubesContainer.gameObject.SetActive(true);

        _ExplosionCubesContainer.Explode();

        _Exploding = true;
    }

    public void Randomize()
    {
        _Exploding = false;
        _ExplodeTimer = _ExplodeDuration;

        _GrowthComponent.RandomizeGrowthParams();
        _LifeTimer = _LifeTimeDuration;
        _RotationSpeed = Random.Range(-45, 45);
    }
}
