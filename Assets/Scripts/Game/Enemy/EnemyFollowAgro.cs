using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyFollowAgro : EnemyFollow
    {
        [SerializeField] private EnemyFollow _enemyFollow;
        [SerializeField] private EnemyBackToIdle _enemyBackToIdle;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            _enemyBackToIdle.Deactivate();
            _enemyFollow.Activate();
        }

        private void OnExited(Collider2D other)
        {
            _enemyFollow.Deactivate();
            _enemyBackToIdle.Activate();
        }
    }
}