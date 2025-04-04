using UnityEngine;

[CreateAssetMenu(menuName = "Enemy mover config/Air Random Point")]
public class AirRandomPointConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float TurnSpeed { get; private set; }
    [field: SerializeField] public float RandomRadius { get; private set; }
    [field: SerializeField] public float MinHeight { get; private set; }
    [field: SerializeField] public float NextPointDistance { get; private set; }
}
