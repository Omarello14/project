using UnityEngine;

public class PrefabGiver : MonoBehaviour
{
    [field: SerializeField] public GameObject CaterpillarHead { get; private set; }
    [field: SerializeField] public GameObject CaterpillarBody { get; private set; }

    public static PrefabGiver Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
