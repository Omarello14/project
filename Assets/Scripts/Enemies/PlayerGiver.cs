using UnityEngine;

public class PlayerGiver : MonoBehaviour
{
    [SerializeField] private Transform _player;

    public static PlayerGiver Instance;

    public Transform Player => _player;
    public Vector3 PlayerPos => _player.position;

    private void Awake()
    {
        Instance = this;
    }
}
