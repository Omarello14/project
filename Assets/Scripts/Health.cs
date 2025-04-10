using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [field:SerializeField] public float MaxHealth { get; private set; }

    public float Value { get; private set; }

    public event Action<Health> Damaged;
    public event Action<Health> Died;

    private bool _isDead = false;

    private void OnValidate()
    {
        Mathf.Clamp(MaxHealth, 0, float.MaxValue);
    }

    public void Awake()
    {
        if (MaxHealth == 0)
        {
            Debug.LogWarning($"{nameof(MaxHealth)} is not initialized");
        }

        Value = MaxHealth;
    }

    public void AddHealth(float value)
    {
        Debug.Log("hit");
        Value = Mathf.Clamp(Value + value, 0, MaxHealth);
        Damaged?.Invoke(this);

        if (Value <= 0 && _isDead == false)
        {
            Died?.Invoke(this);
            _isDead = true;
        }
    }
}
