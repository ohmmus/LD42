using UnityEngine;

public class ShipBehaviorController : MonoBehaviour
{
    private Rigidbody _ShipRB = null;
    private Transform _TransformComponent = null;
    private float _ThrustForce = 90.5f;
    private float _PitchAngle = 0.0f; // 0 is horizontal.

    private float _PitchRate = 85.0f;

    private bool _PitchingUp = false;
    private bool _PitchingDown = false;

    private void Start()
    {
        _ShipRB = GetComponent<Rigidbody>();
        _TransformComponent = transform;
    }

    private void Update()
    {
        // Mechanic test: Hold down Space to freeze time. 
        TimeAuthority.timeFrozen = Input.GetKey(KeyCode.Space);

        Vector3 shipPos = _TransformComponent.position;

        shipPos += _TransformComponent.right * _ThrustForce * TimeAuthority.DeltaTime;

        _TransformComponent.position = shipPos;

        _TransformComponent.localEulerAngles = new Vector3(_TransformComponent.localEulerAngles.x, _TransformComponent.localEulerAngles.y, _PitchAngle);

        _PitchingUp = false;
        _PitchingDown = false;

      

        if (Input.GetKey(KeyCode.UpArrow) && TimeAuthority.DeltaTime == 0)
        {
            _PitchingUp = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) && TimeAuthority.DeltaTime == 0)
        {
            _PitchingDown = true;
        }

        if (_PitchingDown)
        {
            _PitchAngle -= _PitchRate * TimeAuthority.RawDeltaTime;
        }

        if (_PitchingUp)
        {
            _PitchAngle += _PitchRate * TimeAuthority.RawDeltaTime;
        }

        _PitchAngle = Mathf.Clamp(_PitchAngle, -45.0f, 45.0f);
    }
}
