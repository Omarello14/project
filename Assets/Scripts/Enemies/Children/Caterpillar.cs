using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : Enemy
{
    private const int MinSegmentCount = 2;
    private const int MaxSegmentCount = 4;

    [SerializeField] private float _distanceBetweenSegments;
    [SerializeField] private float _segmentsLerpFactor;

    private List<Transform> _bodySegments;
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();

        this.Init(Random.Range(MinSegmentCount, MaxSegmentCount));
        base.Init(_bodySegments[0]);
    }

    private void Init(int segmentCount)
    {
        _bodySegments = new List<Transform>(segmentCount)
        {
            Instantiate(PrefabGiver.Instance.CaterpillarHead, transform.position, Quaternion.identity).transform
        };

        _bodySegments[0].GetComponent<Health>().Died += OnSegmentDied;

        for (int i = 1; i < segmentCount; i++)
        {
            _bodySegments.Add(Instantiate(PrefabGiver.Instance.CaterpillarBody, Vector3.zero, Quaternion.identity).transform);

            _bodySegments[i].position = _bodySegments[i - 1].position - 
                (_bodySegments[i - 1].position - _bodySegments[i].position).normalized
                * _distanceBetweenSegments;

            _bodySegments[i].GetComponent<Health>().Died += OnSegmentDied;
        }
    }
    
    private new void Update()
    {
        base.Update();
        ShiftSegments();
    }

    private void ShiftSegments()
    {
        for (int i = 1; i < _bodySegments.Count; i++)
        {
            _bodySegments[i].position = Vector3.Lerp(
                _bodySegments[i].position, 
                _bodySegments[i - 1].position - (_bodySegments[i - 1].position - _bodySegments[i].position).normalized * _distanceBetweenSegments,
                _segmentsLerpFactor);

            _bodySegments[i].LookAt(_bodySegments[i - 1]);
        }
    }

    private void OnSegmentDied(Health health)
    {
        int index = _bodySegments.IndexOf(health.transform);

        for (int i = _bodySegments.Count - 1; i >= index; i--)
        {
            Transform killedSegment = _bodySegments[i];

            _bodySegments[i].GetComponent<Health>().Damaged -= OnSegmentDied;
            _bodySegments.RemoveAt(i);
            Destroy(killedSegment.gameObject);

            if (i == 0)
            {
                _health.AddHealth(-_health.Value);
                Destroy(gameObject);
            }
        }
    }
}
