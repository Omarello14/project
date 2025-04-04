using Pathfinding;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private MoveType _moveType;
    [SerializeField] private ScriptableObject _moverConfig;

    private IEnemyMover _mover;

    protected void Init(Transform movingObject)
    {
        if (_moveType == MoveType.AirFollow)
        {

        }
        else if (_moveType == MoveType.GroundFollow)
        {

        }
        else if (_moveType == MoveType.AirRadiusFloating)
        {
            if (_moverConfig is AirRadiusFloatingConfig == false)
            {
                Debug.LogError("Wrong confog");
                return;
            }

            _mover = new AirRadiusFloating(movingObject, _moverConfig as AirRadiusFloatingConfig);
        }
        else if (_moveType == MoveType.AirRandomPoint)
        {
            if (_moverConfig is AirRandomPointConfig == false)
            {
                Debug.LogError("Wrong confog");
                return;
            }

            _mover = new AirRandomPoint(movingObject, _moverConfig as AirRandomPointConfig);
        }
    }

    private void Start()
    {
        if (_mover == null)
            throw new NullReferenceException("MOVER IS NOT INITIALIZED CALL INIT FUNC IN AWAKE METHOD OF CHILD CLASS YOU DUMBASS");
    }

    protected void Update()
    {
        _mover.MoveTick();
    }
}