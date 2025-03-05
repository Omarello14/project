using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [field:SerializeField] public float MaxHealth { get; private set; }

    public float Value { get; private set; }

    public event Action Died;
    public event Action Damaged;
    public event Action Healed;

    private void OnValidate()
    {
        Mathf.Clamp(MaxHealth, 0, float.MaxValue);
    }

    public void Awake()
    {
        if (MaxHealth == 0)
        {
            Debug.LogWarning($"{nameof(MaxHealth)} is not initialized");

            Died?.Invoke();
        }

        Value = MaxHealth;
    }

    public void ApplyDamage(float value)
    {
        if (value < 0) return;

        Value = Mathf.Clamp(Value - value, 0, MaxHealth);

        if (Value == 0)
            Died?.Invoke();
        else
            Damaged?.Invoke();
    }

    public void Heal(float value)
    {
        Value += Mathf.Clamp(value, 0, float.MaxValue);

        Healed?.Invoke();
    }
}
