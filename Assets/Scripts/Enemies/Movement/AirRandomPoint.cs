using UnityEngine;

public class AirRandomPoint : IEnemyMover
{
    private AirRandomPointConfig _config;

    private Transform _transform;

    private Vector3 _target;

    public AirRandomPoint(Transform transform, AirRandomPointConfig config)
    {
        _transform = transform;
        _config = config;

        PickRandomPoint();
    }

    public void MoveTick()
    {
        _transform.forward = Vector3.Lerp(
            _transform.forward, 
            (_target - _transform.position).normalized, 
            _config.TurnSpeed * Time.deltaTime);

        _transform.position += _config.Speed * Time.deltaTime * _transform.forward;

        if (Vector3.Distance(_transform.position, _target) < _config.NextPointDistance)
        {
            PickRandomPoint();
        }
    }

    private void PickRandomPoint()
    {
        _target = PlayerGiver.Instance.PlayerPos + new Vector3(
                Random.Range(-_config.RandomRadius, _config.RandomRadius),
                Random.Range(_config.MinHeight, _config.RandomRadius),
                Random.Range(-_config.RandomRadius, _config.RandomRadius));
    }
}
