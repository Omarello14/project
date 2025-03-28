using UnityEngine;

public interface IEnemyMover
{
    void MoveTick();
    void OnTriggerEnter(Collider other);
    void OnTriggerExit(Collider other);
    void FixedUpdate();
}
