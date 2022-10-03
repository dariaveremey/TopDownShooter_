using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _enemyIdle;

        public override void Activate()
        {
            base.Activate();

            Deactivate();
            _enemyIdle.Activate();
        }
    }
}