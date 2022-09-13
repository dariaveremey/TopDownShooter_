using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyDirectMovement _enemyDirectMovement;
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
            _enemyDirectMovement.SetTarget(target);
        }
    }
}