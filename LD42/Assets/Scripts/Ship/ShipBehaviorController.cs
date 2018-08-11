using UnityEngine;

public class ShipBehaviorController : MonoBehaviour
{
    private Rigidbody _ShipRB = null;
    private Transform _TransformComponent = null;
    private float _ThrustForce = 5.5f;
    private float _PitchAngle = 0.0f; // 0 is horizontal.

    private float _PitchRate = 100.0f;

    private bool _PitchingUp = false;
    private bool _PitchingDown = false;

    private void Start()
    {
        _ShipRB = GetComponent<Rigidbody>();
        _TransformComponent = transform;
    }

    private void Update()
    {
        Vector3 shipPos = _TransformComponent.position;

        shipPos += _TransformComponent.right * _ThrustForce * TimeAuthority.DeltaTime;

        _TransformComponent.position = shipPos;

        _TransformComponent.localEulerAngles = new Vector3(_TransformComponent.localEulerAngles.x, _TransformComponent.localEulerAngles.y, _PitchAngle);

        _PitchingUp = false;
        _PitchingDown = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _PitchingUp = true;   
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _PitchingDown = true;
        }

        if (_PitchingDown)
        {
            _PitchAngle -= _PitchRate * TimeAuthority.DeltaTime;
        }
        if (_PitchingUp)
        {
            _PitchAngle += _PitchRate * TimeAuthority.DeltaTime;
        }
    }
}
