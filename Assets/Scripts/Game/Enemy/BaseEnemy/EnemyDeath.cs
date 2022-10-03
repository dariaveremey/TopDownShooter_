using System;
using TDS.Game.Bonuses;
using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyDeath : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private EnemyMoveToPlayer _enemyMoveToPlayer;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyIdle _enemyIdle;
        [SerializeField] private EnemyStarter _enemyStarter;
        
        [Header("Other")]
        [SerializeField] private AnimationBase _enemyAnimation;
        [SerializeField] private EnemyHp _enemyHp;

        [SerializeField] private BonusesSpawner _spawner;

        private void Start()
        {
            _enemyHp.OnChanged += OnHpChanged;
        }

        public bool IsEnemyDead { get; private set; }

        public event Action<EnemyDeath> OnHappened;

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
            OnHappened?.Invoke(this);
            _spawner.SpawnItem();
            _enemyIdle.Deactivate();
            _enemyMoveToPlayer.Deactivate();
            _enemyMovement.Deactivate();
            _enemyStarter.enabled = false;
            
        }
    }
}