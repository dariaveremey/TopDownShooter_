using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttackAgro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private EnemyFollow _enemyFollow;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            _enemyFollow.Deactivate();
            _attack.Activate();
        }

        private void OnExited(Collider2D col)
        {
            _enemyFollow.Activate();
            _attack.Deactivate();
        }
    }
}