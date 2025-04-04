using UnityEngine;

[CreateAssetMenu(menuName = "Enemy mover config/Air Radius Floating")]
public class AirRadiusFloatingConfig : ScriptableObject
{
    [field:SerializeField] public float LerpFactor { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float MaxLerpSpeed { get; private set; }
    [field: SerializeField] public float SwingFactor { get; private set; }
    [field: SerializeField] public float SwingSpeed { get; private set; }
    [field: SerializeField] public float Height { get; private set; }
    [field: SerializeField] public float Radius { get; private set; }
}
