using Pathfinding;
using UnityEngine;

public class GroundFollow : IEnemyMover
{
    public GroundFollow(Transform player, AIDestinationSetter pathfinder)
    {
        pathfinder.target = player;
    }

    public void MoveTick() { }
}
