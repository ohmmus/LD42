using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTimeController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particleSystem = null;

    private void Update()
    {

        _particleSystem.Play(true);

        if (TimeAuthority.DeltaTime == 0.0f)
        {
            _particleSystem.Pause(true);
        }
    }
}
