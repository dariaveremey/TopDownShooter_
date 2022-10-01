using TDS.Assets.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(EnemyFollowAgro))]
    [RequireComponent(typeof(EnemyAttackAgro))]
    public class EnemyStarter : MonoBehaviour
    {
        [SerializeField] private EnemyIdle _enemyIdle;
        

        public void Begin()
        {
            _enemyIdle.Activate();
        }
    }
}