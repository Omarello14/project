using UnityEngine;

public class PlayerGiver : MonoBehaviour
{
    [SerializeField] private Transform _player;

    public static PlayerGiver Instance;

    public Vector3 PlayerPos => _player.position;

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
