using UnityEngine;

namespace TDS.Assets.Game
{
    public abstract class EnemyMovement : EnemyBehaviour
    {
        [SerializeField] private float _speed = 4;
        [SerializeField] private AnimationBase _enemyAnimation;

        protected float Spead => _speed;
        public abstract void SetTarget(Transform target);

        protected void SetAnimationSpeed(float speed)
        {
            _enemyAnimation.SetSpeed(speed);
        }
    }
}