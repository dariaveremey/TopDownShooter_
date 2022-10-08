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

        public event Action<int> OnChanged;
        public int BulletNumber { get; private set; } = 5;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            TickTimer();
            
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
            _timer = _fireDelay;
            LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            BulletNumber -= 1;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }

        public void AddBulletsNumber(int number)
        {
            BulletNumber += number;
            OnChanged?.Invoke(BulletNumber);
        }

    }
}