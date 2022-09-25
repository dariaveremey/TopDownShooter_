using TDS.Assets.Game.Enemy.Base;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMeleeAttack : EnemyAttack
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
        [SerializeField] private float _radius=2f;
        [SerializeField] private LayerMask _layerMask;

        private float _delayTimer;

        protected override void OnUpdate()
        {
            TickTimer();
        }

        protected override void OnActiveUpdate()
        {
            base.OnActiveUpdate();
            Attack();
        }

        /*public override void Activate()
        {
            base.Activate();
            _enemyAnimation.StartPlayAttack();
        }*/

        private void Attack()
        {
            if (CanAttack())
            {
                AttackInternal();
                //Instantiate(_weaponPrefab, _weaponSpawnPointTransform.position, transform.rotation);
               // _enemyAnimation.ZombieShoot();
            }
        }

        /*public override void Deactivate()
        {
            base.Deactivate();
            _enemyAnimation.StopPlayAttack();
        }*/

        private void TickTimer() =>
            _delayTimer -= Time.deltaTime;

        private bool CanAttack() =>
            _delayTimer <= 0;

        private void AttackInternal()
        {
            _delayTimer = _attackDelay;
            _enemyAnimation.PlayAttack();
        }

        public void PerformDamage()
        {
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);

            if (col == null)
                return;

            PlayerHp playerHp = col.GetComponentInParent<PlayerHp>();
            if (playerHp != null)
                playerHp.ApplyDamage(_damage);
        }
    }
}