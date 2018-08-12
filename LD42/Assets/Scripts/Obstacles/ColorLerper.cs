using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    [SerializeField]
    private Color _BaseColor;

    private Renderer _Renderer = null;

    public void Start()
    {
        _Renderer = GetComponent<Renderer>();

        _Renderer.material.color = _BaseColor;
    }

    private void OnEnable()
    {
    }

    private void Update()
    {
        _Renderer.material.color = Color.Lerp(_Renderer.material.color, _BaseColor, TimeAuthority.RawDeltaTime);
    }
}
