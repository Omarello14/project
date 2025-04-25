using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int LevelIndex = 1;

    public void Play()
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
