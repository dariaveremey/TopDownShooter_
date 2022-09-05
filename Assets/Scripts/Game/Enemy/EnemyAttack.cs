using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class EnemyAttack : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] private Transform _weaponSpawnPointTransform;
        [SerializeField] private GameObject _weaponPrefab;

        [Header("Attack")]
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _attackDelay = 5f;

        [Header("AttackAria")]
        [SerializeField] private int _damage = 2;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private float _delayTimer;

        private void Update()
        {
            TickTimer();
        }

        public void Attack()
        {
            if (CanAttack())
            {
                AttackInternal();
                Instantiate(_weaponPrefab, _weaponSpawnPointTransform.position, transform.rotation);
                _enemyAnimation.ZombieShoot();
            }
        }

        private void TickTimer() =>
            _delayTimer -= Time.deltaTime;

        private bool CanAttack() =>
            _delayTimer <= 0;

        private void AttackInternal()
        {
            _delayTimer = _attackDelay;
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);

            if (col == null)
                return;

            PlayerHp playerHp = col.GetComponentInParent<PlayerHp>();
            if (playerHp != null)
                playerHp.ApplyDamage(_damage);
        }
    }
}