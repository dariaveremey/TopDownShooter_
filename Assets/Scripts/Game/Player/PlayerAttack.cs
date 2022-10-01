using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Player
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
            return Input.GetButton("Fire1") && _timer <= 0;
        }

        private void Attack()
        {
            if (_playerHp.CurrentHp <= 0)
            {
                return;
            }

            _playerAnimation.PlayShoot();
            LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            _timer = _fireDelay;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}