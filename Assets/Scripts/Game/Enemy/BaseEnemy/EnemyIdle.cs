using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyIdle : EnemyBehaviour
    {
        [SerializeField] private EnemyIdle _idle;

        private void OnEnabled()
        {
            _idle.enabled = true;
        }
        /*[SerializeField] private Transform _playerTransform;
        [SerializeField] private EnemyMoveToPlayer _enemyMoveToPlayer;

        [SerializeField] private EnemyHp _enemyHp;

        private void Awake()
        {
            _enemyMoveToPlayer.enabled = false;
        }

        private void Update()
        {
            if (_enemyHp.CurrentHp == 0)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            Vector3 difference = _playerTransform.position - transform.position;
            transform.up = difference;
        }
    }*/
    }
}