using TDS.Game.Zombie;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyDeath : MonoBehaviour

    {
        [Header("Movement")]
        [SerializeField] private EnemyMoveToPlayer _enemyMoveToPlayer;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyIdle _enemyIdle;
        [Header("Other")]
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyHp _enemyHp;

        private void OnCollisionEnter2D(Collision2D col)

        {
            if (col.gameObject.CompareTag(Tags.PlayerBullet))
            {
                _enemyHp.ApplyDamage(1);
                Destroy(col.gameObject);
                if (_enemyHp.CurrentHp <= 0)
                {
                    ZombieDeath();
                    _enemyIdle.enabled = false;
                    _enemyMoveToPlayer.enabled = false;
                    _enemyMovement.enabled = false;
                }
            }
        }

        private void ZombieDeath()
        {
            _enemyAnimation.Death();
        }
    }
}