using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Caterpillar : Enemy
{
    private const int MinSegmentCount = 2;
    private const int MaxSegmentCount = 8;

    [SerializeField] private float _distanceBetweenSegments;
    [SerializeField] private float _segmentsLerpFactor;

    private List<Transform> _bodySegments;

    private void Awake()
    {
        this.Init(Random.Range(MinSegmentCount, MaxSegmentCount));
        base.Init(_bodySegments[0]);
    }

    public void Init(int segmentCount)
    {
        _bodySegments = new List<Transform>(segmentCount)
        {
            Instantiate(PrefabGiver.Instance.CaterpillarHead, transform.position, Quaternion.identity).transform
        };

        for (int i = 1; i < segmentCount; i++)
        {
            _bodySegments.Add(Instantiate(PrefabGiver.Instance.CaterpillarBody, Vector3.zero, Quaternion.identity).transform);

            _bodySegments[i].position = _bodySegments[i - 1].position - 
                (_bodySegments[i - 1].position - _bodySegments[i].position).normalized
                * _distanceBetweenSegments;
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
}
