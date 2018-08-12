using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterPiece : MonoBehaviour
{
    private Rigidbody _RigidbodyComp = null;

    private bool _ColorCooldown = false;

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

    public void OnCollided()
    {
        if (!_ColorCooldown)
        {
            _ColorCooldown = true;
        }
    }

    private void Update()
    {
        _RigidbodyComp.isKinematic = TimeAuthority.DeltaTime == 0;
    }
}
