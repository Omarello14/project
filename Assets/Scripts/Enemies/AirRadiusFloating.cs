using System.Collections.Generic;
using UnityEngine;

public partial class AirRadiusFloating : IEnemyMover
{
    private MoverConfig _config;

    private Transform _transform;
    private Rigidbody _rb;

    private Vector3 _target;

    private List<Transform> _pushingObjects = new();
    private Vector3 _temp;

    private Vector3 _movingForce;
    private Vector3 _pushingForce;

    public AirRadiusFloating(Transform transform, Rigidbody rb,MoverConfig config)
    {
        _transform = transform;
        _rb = rb;
        _config = config;
        _target = new Vector3(_config.Radius, 0, 0);
    }

    public void FixedUpdate()
    {
        _movingForce = Vector3.ClampMagnitude(
            (_target + PlayerGiver.Instance.PlayerPos - _transform.position) * _config.LerpFactor,
            _config.MaxLerpSpeed);

        _movingForce = new Vector3(
            _movingForce.x,
            0,
            _movingForce.z);


        for (int i = 0; i < _pushingObjects.Count; i++)
        {
            _temp = _pushingObjects[i].position - _transform.position;

            _pushingForce += new Vector3(_temp.x, 0, _temp.z).normalized
                * (_config.PushingRadius.magnitude - _temp.magnitude)
                * _config.PushingForce;
        }

        _rb.linearVelocity = _movingForce + _pushingForce;

        Debug.Log(_rb.linearVelocity);
    }

    public void MoveTick()
    {
        _target = Quaternion.AngleAxis(_config.RotationSpeed * Time.deltaTime, Vector3.up) * _target;
        Debug.DrawLine(_transform.position, _target);

        _transform.position = new(_transform.position.x,
            PlayerGiver.Instance.PlayerPos.y + _config.Height + Mathf.Sin(Time.time * _config.SwingSpeed) * _config.SwingFactor,
            _transform.position.z);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushing"))
            _pushingObjects.Add(other.transform);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushing"))
            _pushingObjects.Remove(other.transform);
    }
}
