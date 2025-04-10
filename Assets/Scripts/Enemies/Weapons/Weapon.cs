using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField] private Transform _player;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _bulletLifetime;

    public void OnAttack(Quaternion rotation)
    {
        GameObject.Instantiate(_projectilePrefab, _player.position, rotation).Init(_damage, _speed, _bulletLifetime);
    }
}
