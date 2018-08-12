using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private ShatterPiece[] _ShatterPieces = null;

    [SerializeField]
    private Transform _ExplosionOrigin = null;
    private float _ExplodeForce = 950.0f;

    private void Start()
    {
        // Find all shatterpirces
        _ShatterPieces = GetComponentsInChildren<ShatterPiece>();

        gameObject.SetActive(false);
    }

    public void Explode()
    {
        if (_ShatterPieces == null || _ShatterPieces.Length == 0)
        {
            _ShatterPieces = GetComponentsInChildren<ShatterPiece>();
        }

        for (int i = 0; i < _ShatterPieces.Length; i++)
        {
            Vector3 direction = _ShatterPieces[i].transform.position - _ExplosionOrigin.position;
            _ShatterPieces[i].GetComponent<Rigidbody>().isKinematic = false;
            _ShatterPieces[i].transform.localPosition = Vector3.zero;

            direction.z = 0;
            _ShatterPieces[i].Explode(direction.normalized, _ExplodeForce);
        }
    }

    public void CleanUpShatterPieces()
    {
        for (int i = 0; i < _ShatterPieces.Length; i++)
        {
        }
    }
}
