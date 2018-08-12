using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    private Vector3 _Scale = Vector3.one; // Transform.scale also scales the box collider.

    private float _ScaleFactor = 1.0f;

    private float _ScaleRate = 1.0f;

    private float _ScaleFactorMax = 5.0f;

    private void OnDisable()
    {
        _Scale = Vector3.one;
        _ScaleFactor = 1.0f;
        _ScaleFactorMax = 5.0f;
    }

    void Update()
    {
        if (_ScaleFactor < _ScaleFactorMax)
        {
            _ScaleFactor += TimeAuthority.DeltaTime * _ScaleRate;

            _Scale = new Vector3(_ScaleFactor, _ScaleFactor, _ScaleFactor);
            transform.localScale = _Scale;
        }
    }

    public void RandomizeGrowthParams()
    {
        _ScaleFactor = Random.Range(1, 4);
        _ScaleFactorMax = Random.Range(2, 8);
    }
}
