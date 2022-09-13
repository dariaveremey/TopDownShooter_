using UnityEngine;

namespace TDS.Game.Enemy
{ 
    public class EnemyDeath : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private EnemyMoveToPlayer _enemyMoveToPlayer;
        [SerializeField] private EnemyDirectMovement _enemyDirectMovement;
        [SerializeField] private EnemyIdle _enemyIdle;
        [Header("Other")]
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyHp _enemyHp;

        private void Start()
        {
            _enemyHp.OnChanged += OnHpChanged;
        }

        public bool IsEnemyDead { get; private set; }

        private void OnHpChanged(int hp)
        {
            if (IsEnemyDead || hp > 0)
            {
                return;
            }

            IsEnemyDead = true;
            ZombieDeath();
        }

        private void ZombieDeath()
        {
            _enemyAnimation.Death();
            _enemyIdle.enabled = false;
            _enemyMoveToPlayer.enabled = false;
            _enemyDirectMovement.enabled = false;
        }
    }
}