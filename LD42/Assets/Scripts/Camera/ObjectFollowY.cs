using UnityEngine;

public class ObjectFollowY : MonoBehaviour
{
    private Transform _TransformComponent = null;

    [SerializeField]
    private Transform _TargetObject = null;

    [SerializeField]
    private float _HorizontalAttractStrength = 1.0f;

    [SerializeField]
    private float _VerticalAttractStrength = 1.0f;

    [SerializeField]
    private float _HorizontalOffset = 10.0f;

    public void Start()
    {
        _TransformComponent = transform;
    }

    void Update ()
	{
        Vector3 posFollow = _TransformComponent.position;

        posFollow.y = Mathf.Lerp(posFollow.y, _TargetObject.position.y, _VerticalAttractStrength * TimeAuthority.DeltaTime);
        posFollow.x = Mathf.Lerp(posFollow.x, _TargetObject.position.x - _HorizontalOffset, _HorizontalAttractStrength * TimeAuthority.DeltaTime);

        _TransformComponent.position = posFollow;
	}
}
