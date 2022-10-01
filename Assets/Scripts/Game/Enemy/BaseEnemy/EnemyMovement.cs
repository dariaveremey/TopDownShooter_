using TDS.Assets.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        [SerializeField] private float _speed = 4;
        [SerializeField] private EnemyAnimation _enemyAnimation;

        protected float Spead => _speed;
        public abstract void SetTarget(Transform target);

        protected void SetAnimationSpeed(float speed)
        {
            _enemyAnimation.SetSpeed(speed);
        }
    }
}