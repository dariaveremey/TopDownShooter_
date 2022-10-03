using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using Object = UnityEngine.Object;

namespace TDS.Assets.Game
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _fireDelay = 0.3f;
        [SerializeField] private PlayerHp _playerHp;
 

        private Transform _cachedTransform;
        private float _timer;
        private Bullet[] _bullets;
        
        public event Action<int> OnChanged;
        public int BulletNumber { get; private set; } = 5;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            TickTimer();

           // _bullets = LeanGameObjectPool.TryFindPoolByPrefab(_bulletPrefab,ref LeanPool);
           _bullets = FindObjectsOfType<Bullet>();
            if (CanAttack())
            {
                Attack();
            }
        }

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _timer <= 0 && BulletNumber>0;
        }

        private void Attack()
        {
            if (_playerHp.CurrentHp <= 0)
            {
                return;
            }

            _playerAnimation.PlayShoot();
            BulletNumber -= 1;
            _timer = _fireDelay;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }

        public void AddBulletsNumber(int number)
        {
            BulletNumber = number;
            if (BulletNumber < _bullets.Length)
            {
                for (int i = 0; i <BulletNumber -_bullets.Length ; i++)
                {
                    LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
                }
            }
            OnChanged?.Invoke(BulletNumber);
        }

    }
}