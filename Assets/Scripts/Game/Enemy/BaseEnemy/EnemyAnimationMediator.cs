using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyAnimationMediator:MonoBehaviour
    {
        [SerializeField] private EnemyMeleeAttack _enemyMeleeAttack;
        
        public void PerformDamage()
        {
            _enemyMeleeAttack.PerformDamage();
        }
    }
}