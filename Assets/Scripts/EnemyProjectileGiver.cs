using UnityEngine;

public class EnemyProjectileGiver : MonoBehaviour
{
    [SerializeField] private CaterpillarProjectile _prefab;

    public static EnemyProjectileGiver Instance;

    private void Awake()
    {
        Instance = this;
    }

    public CaterpillarProjectile Get(Vector3 pos,Vector3 euler)
    {
        return Instantiate(_prefab, pos, Quaternion.Euler(euler));
    }
}
