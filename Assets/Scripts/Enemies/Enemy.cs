using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private MoveType _moveType;
    [SerializeField] private MoverConfig _moverConfig;

    private Health _health;
    private IEnemyMover _mover;

    protected void Awake()
    {
        GetComponent<SphereCollider>().radius = _moverConfig.PushingRadius.x;

        if (_moveType == MoveType.AirFollow)
        {

        }
        else if (_moveType == MoveType.GroundFollow)
        {

        }
        else if (_moveType == MoveType.AirRadiusFloating)
        {
            _mover = new AirRadiusFloating(transform, GetComponent<Rigidbody>(), _moverConfig);
        }
    }

    protected void Update()
    {
        _mover.MoveTick();
    }

    protected void FixedUpdate()
    {
        _mover.FixedUpdate();
    }

    protected void OnTriggerEnter(Collider other)
    {
        _mover.OnTriggerEnter(other);
    }

    protected void OnTriggerExit(Collider other)
    {
        _mover.OnTriggerExit(other);
    }
}
