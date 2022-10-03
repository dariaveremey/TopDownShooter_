using UnityEngine;

namespace TDS.Assets.Game
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