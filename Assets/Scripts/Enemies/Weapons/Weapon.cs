using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _damage;

    public void OnAttack(Quaternion rotation)
    {
        GameObject.Instantiate(_projectilePrefab, _player.position, rotation);
    }
}
