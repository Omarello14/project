using Pathfinding;
using UnityEngine;

public class Mite : Enemy
{
    [SerializeField] private float _distanceToJump = 3;
    [SerializeField] private float _jumpDuration = 1;
    [SerializeField] private float _jumpHeight = 2;
    [SerializeField] private float _explodeRadius = 4;
    [SerializeField] private float _explodeDamage = 40;

    private Transform _transform;
    private Health _health;

    private Vector3 _jumpTarget;
    private Vector3 _jumpStart;
    private float _moveDelta;
    private float _jumpingTime = 0;
    private bool _isJumping = false;

    private void Start()
    {
        base.Init(null);
        _transform = transform;
        _health = GetComponent<Health>();
        _health.Died += Explode;
    }

    private new void Update()
    {
        base.Update();

        if (_isJumping == false && Vector3.Distance(_transform.position, PlayerGiver.Instance.PlayerPos) < _distanceToJump)
        {
            GetComponent<AIDestinationSetter>().target = _transform;
            _jumpTarget = PlayerGiver.Instance.PlayerPos;
            _jumpStart = _transform.position;
            _moveDelta = Vector3.Distance(_transform.position, _jumpTarget) / _jumpDuration * Time.deltaTime;
            _isJumping = true;
        }
        else if (_isJumping)
        {
            if (_jumpingTime >= _jumpDuration)
            {
                _health.AddHealth(-_health.Value);
                return;
            }

            Vector3 XZpos = Vector3.MoveTowards(_transform.position, _jumpTarget, _moveDelta);
            _transform.position = new(XZpos.x, _jumpStart.y + _jumpHeight * (_jumpingTime / _jumpDuration), XZpos.z);

            _jumpingTime += Time.deltaTime;
        }
    }

    private void Explode(Health health)
    {
        health.Died -= Explode;

        Collider[] objects = Physics.OverlapSphere(_transform.position, _explodeRadius);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].TryGetComponent(out Health damagedObject))
                damagedObject.AddHealth(-_explodeDamage);
        }

        Destroy(gameObject);
    }
}
