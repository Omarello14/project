using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField] public float Damage { get; private set; } = 10;
    [field: SerializeField] public float Speed { get; private set; } = 1;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + _transform.forward * Speed, float.MaxValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Health>(out Health health))
        {
            Debug.Log("hit");
            health.AddHealth(-Damage);
        }

        Destroy(gameObject);
    }
}
