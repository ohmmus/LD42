using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterPiece : MonoBehaviour
{
    private Rigidbody _RigidbodyComp = null;

    public void Start()
    {
        _RigidbodyComp = GetComponent<Rigidbody>();
    }

    public void Explode(Vector3 dir, float force)
    {
        if (_RigidbodyComp == null)
        {
            _RigidbodyComp = GetComponent<Rigidbody>();
        }

        if (dir == Vector3.zero)
        {
            dir = new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), 0);
        }

        if (_RigidbodyComp != null)
        {
            _RigidbodyComp.angularVelocity = Vector3.zero;
            _RigidbodyComp.velocity = Vector3.zero;

            _RigidbodyComp.AddForce(dir * force);
        }
    }

    private void Update()
    {
        _RigidbodyComp.isKinematic = TimeAuthority.DeltaTime == 0;
    }
}
