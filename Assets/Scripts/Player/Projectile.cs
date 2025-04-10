using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage { get; private set; } = 10;
    public float Speed { get; private set; } = 1;
    public float Lifetime { get; private set; } = 10;

    private Transform _transform;

    public void Init(float damage, float speed, float lifetime)
    {
        _transform = transform;
        Damage = damage;
        Speed = speed * Time.deltaTime;
        Lifetime = lifetime;
    }

    private void Update()
    {
        Lifetime -= Time.deltaTime;

        if (Lifetime <= 0)
        {
            Destroy(gameObject);
            return;
        }

        _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + _transform.forward * Speed, float.MaxValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Health health))
        {
            health.AddHealth(-Damage);
        }

        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, GetComponent<SphereCollider>().radius);
    }
}
