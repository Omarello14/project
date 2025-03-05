using Pathfinding;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private const int TargetPointChildIndex = 0;

    [SerializeField] private MoveType _moveType;
    [SerializeField] private float _radius;

    private Transform _transform;
    private Health _health;
    private IEnemyMover _mover;

    private void Awake()
    {
        _transform = transform;
        AILerp finder = GetComponent<AILerp>();
        Seeker seeker = GetComponent<Seeker>();

        Transform targetPoint = _transform.GetChild(TargetPointChildIndex);
        targetPoint.parent = null;

        if (_moveType == MoveType.AirFollow)
        {

        }
        else if (_moveType == MoveType.GroundFollow)
        {

        }
        else if (_moveType == MoveType.AirRadiusFloating)
        {
            _mover = new AirRadiusFloating(finder, seeker, _radius, _transform);
        }
    }
}

public enum MoveType
{
    AirFollow,
    GroundFollow,
    AirRadiusFloating
}
