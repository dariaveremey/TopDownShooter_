using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyAnimation : AnimationBase
    {
        [SerializeField] private Animator _animator;

        private static readonly int Speed = Animator.StringToHash("Speed");

        public override void PlayAttack()
        {
            _animator.SetTrigger("IsAttack");
        }

        public override void SetSpeed(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
        public override void Death()
        {
            _animator.SetTrigger("IsDead");
        }
    }
}