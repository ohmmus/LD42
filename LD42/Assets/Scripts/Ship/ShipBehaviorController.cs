using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBehaviorController : MonoBehaviour
{
    public LayerMask LineTraceLayerMask = -1;

    [SerializeField]
    private Transform _LineTraceEnding =  null;
    private Transform _TransformComponent = null;
    private float _ThrustForce = 70.0f;
    private float _PitchAngle = 0.0f; // 0 is horizontal.

    private float _PitchRate = 85.0f;

    private bool _PitchingUp = false;
    private bool _PitchingDown = false;

    private Collider _ColliderComp = null;

    private bool _TimeFrozenLastFrame = false;
    private bool _IsDying = false;

    public AudioSource _ShipAudioSource = null;


    public AudioSource _MusicAudioSource = null;

    public AudioClip TimeSpeedUp = null;
    public AudioClip TimeSlowDown = null;
    public AudioClip ShipExplode = null;

    private void Start()
    {
        _TransformComponent = transform;
        _ColliderComp = GetComponent<Collider>();
        _ShipAudioSource = GetComponent<AudioSource>();
        _IsDying = false;
    }

    private void Update()
    {
        if (_IsDying)
        {
            return;
        }

        TimeAuthority.timeFrozen = Input.GetKey(KeyCode.Space);

        if (_TimeFrozenLastFrame && !TimeAuthority.timeFrozen)
        {
            // UNFREEZING
            _ShipAudioSource.PlayOneShot(TimeSpeedUp);
            _MusicAudioSource.pitch = 1.0f;
        }
        else if (!_TimeFrozenLastFrame && TimeAuthority.timeFrozen)
        {
            _ShipAudioSource.PlayOneShot(TimeSlowDown);
            _MusicAudioSource.pitch = 0.45f;
        }

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

        _TimeFrozenLastFrame = TimeAuthority.timeFrozen;
    }

    private void FixedUpdate()
    {
        Ray directionForSphereCast = new Ray(transform.position, (_LineTraceEnding.position - transform.position));
        RaycastHit hitInfo;

        if (Physics.SphereCast(directionForSphereCast, 1, out hitInfo, 32, LineTraceLayerMask))
        {
            if (hitInfo.transform.name.Contains("Chunk"))
            {
                hitInfo.transform.GetComponent<Chunk>().OnCollided();
            }
            else if (hitInfo.transform.name.Contains("Cube"))
            {
                hitInfo.transform.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _ShipAudioSource.PlayOneShot(ShipExplode);
        _IsDying = true;
        Invoke("GameOver", 0.2f);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}
