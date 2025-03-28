using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform sunrise;
    [SerializeField] private Transform sunset;
    [SerializeField] private Transform target;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    public void Update()
    {

    }

    private Vector3 RotateAround(Vector3 pivot, Vector3 axis, float angle, Vector3 obj)
    {
        return Quaternion.AngleAxis(angle, axis) * (obj - pivot) + pivot;
    }
}
