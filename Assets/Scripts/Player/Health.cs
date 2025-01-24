using UnityEngine;

public class Health : MonoBehaviour
{
    [field:SerializeField] public float MaxHealth { get; private set; }

    public float Health { get; private set; }

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
            Debug.Warning($"{nameof(MaxHealth)} is not initialized");

            Died?.Invoke();
        }

        Health = MaxHealth;
    }

    public void ApplyDamage(float value)
    {
        if (value < 0) return;

        Health = Mathf.Clamp(Health - value, 0, MaxHealth);

        if (Health == 0)
            Died?.Invoke();
        else
            Damaged?.Invoke();
    }

    public void Heal(float value)
    {
        Health += Mathf.Clamp(value, 0, float.maxValue);

        Healed?.Invoke();
    }
}
