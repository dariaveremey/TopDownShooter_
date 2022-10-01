using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDS.Assets.Game.Enemy.Base;
using TDS.Assets.Infrastructure.ServicesContainer;
using TDS.Game.Enemy;
using Object = UnityEngine.Object;

namespace TDS.Game.Servieces.Npc
{
    public class NpcService:INpcService
    {
        private List<EnemyDeath> _enemies;
        
        public event Action OnAllDead;
        
        public void Init()
        {
           EnemyStarter[] enemyStarters= Object.FindObjectsOfType<EnemyStarter>();

           foreach (EnemyStarter starter in enemyStarters)
           {
               starter.Begin();
           }
           _enemies=Object.FindObjectsOfType<EnemyDeath>().ToList();
           Subscribe();
        }

        private void Subscribe()
        {
            foreach (EnemyDeath enemyDeath in _enemies)
            {
                enemyDeath.OnHappened += OnEnemyDeath;
            }
        }

        private void OnEnemyDeath(EnemyDeath enemyDeath)
        {
            enemyDeath.OnHappened -= OnEnemyDeath;
            _enemies.Remove(enemyDeath);

            if (_enemies.Count == 0)
            {
                OnAllDead?.Invoke();
            }
        }

        public void Dispose()
        {
            Unsubscribe();
            _enemies = null;

        }

        private void Unsubscribe()
        {
            foreach (EnemyDeath enemyDeath in _enemies)
            {
                enemyDeath.OnHappened -= OnEnemyDeath;
            }
        }
    }
}