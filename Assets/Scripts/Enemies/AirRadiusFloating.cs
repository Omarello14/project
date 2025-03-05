using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

public partial class AirRadiusFloating : IEnemyMover    
{
    private AILerp _finder;
    private Seeker _seeker;
    private Transform _transform;

    private float _radius;

    public AirRadiusFloating(AILerp finder, Seeker seeker, float radius, Transform transform)
    {
        _finder = finder;
        _radius = radius;
        _seeker = seeker;
        _transform = transform;

        

        OnPathComplete(null);
        _seeker.pathCallback = OnPathComplete;
    }

    public void Update() 
    { 
        //if (!_finder.pathPending && (_finder.reachedEndOfPath || _finder.hasPath == false))
        //{
        //    OnPathComplete(null);
        //}
    }

    private void OnPathComplete(Path path)
    {
        //if (path != null && path.error)
        //{
        //    Debug.Log("error");
        //    return;
        //}

        //Debug.Log("running");
        //_seeker.StartPath(_transform.position, PlayerGiver.Instance.PlayerPos + AstarPath.active.GetNearest(Random.insideUnitSphere * _radius).position);
    }
}
