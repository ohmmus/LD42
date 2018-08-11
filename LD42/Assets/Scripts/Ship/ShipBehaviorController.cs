using UnityEngine;

public class ShipBehaviorController : MonoBehaviour
{
    private Rigidbody _ShipRB = null;
    private Transform _TransformComponent = null;
    private float _ThrustForce = 5.5f;
    private float _PitchAngle = 0.0f; // 0 is horizontal.

    private void Start()
    {
        _ShipRB = GetComponent<Rigidbody>();
        _TransformComponent = transform;
    }

    private void Update()
    {
        _TransformComponent.Rotate(Vector3.forward, _PitchAngle);

        Vector3 shipPos = _TransformComponent.position;

        shipPos += _TransformComponent.right * _ThrustForce * TimeAuthority.DeltaTime;

        _TransformComponent.position = shipPos;
    }

   
}
