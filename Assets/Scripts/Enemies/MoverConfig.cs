using UnityEngine;

[CreateAssetMenu(menuName = "Mover config")]
public class MoverConfig : ScriptableObject
{
    [field:SerializeField] public float LerpFactor { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float MaxLerpSpeed { get; private set; }
    [field: SerializeField] public float SwingFactor { get; private set; }
    [field: SerializeField] public float SwingSpeed { get; private set; }
    [field: SerializeField] public float Height { get; private set; }
    [field: SerializeField] public float Radius { get; private set; }
    [field: SerializeField] public Vector3 PushingRadius { get; private set; }
    [field: SerializeField] public float PushingForce { get; private set; }
    [field: SerializeField] public LayerMask PushingMask { get; private set; }
}
