using System.Collections.Generic;
using UnityEngine;

public partial class AirRadiusFloating : IEnemyMover
{
    private AirRadiusFloatingConfig _config;

    private Transform _transform;

    private Vector3 _target;
    private Vector3 _temp;

    public AirRadiusFloating(Transform transform, AirRadiusFloatingConfig config)
    {
        _transform = transform;
        _config = config;
        _target = new Vector3(_config.Radius, 0, 0);
    }

    public void MoveTick()
    {
        _target = Quaternion.AngleAxis(_config.RotationSpeed * Time.deltaTime, Vector3.up) * _target;
        
        _temp = _transform.position + Vector3.ClampMagnitude(
            (_target + PlayerGiver.Instance.PlayerPos - _transform.position) * _config.LerpFactor,
            _config.MaxLerpSpeed);

        _transform.position = new(_temp.x,
            PlayerGiver.Instance.PlayerPos.y + _config.Height + Mathf.Sin(Time.time * _config.SwingSpeed) * _config.SwingFactor,
            _temp.z);
    }
}
