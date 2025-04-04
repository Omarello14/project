using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Caterpillar _prefab;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(_prefab, Vector3.zero, Quaternion.identity);
    }
}
