using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyMoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHp>().transform;
        }

        public override void Activate()
        {
            base.Activate();
            SetTarget(_playerTransform);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _enemyMovement.SetTarget(target);
        }
    }
}