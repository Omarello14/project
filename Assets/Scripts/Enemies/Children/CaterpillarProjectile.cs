using UnityEngine;

public class CaterpillarProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _maxTurnSpeed = 0.5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.forward = Vector3.Lerp(
            _transform.forward,
            (PlayerGiver.Instance.PlayerPos - _transform.position).normalized,
            _maxTurnSpeed * Time.fixedDeltaTime);

        _transform.position += _transform.forward * Time.fixedDeltaTime * _speed;
    }
}
