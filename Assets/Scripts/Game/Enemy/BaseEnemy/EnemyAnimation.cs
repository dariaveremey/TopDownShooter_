using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyAnimation : AnimationBase
    {
        private static readonly int Speed = Animator.StringToHash("Speed");

        public override void PlayAttack()
        {
            Animation.SetTrigger("IsAttack");
        }

        public override void SetSpeed(float speed)
        {
            Animation.SetFloat(Speed, speed);
        }
        public override void Death()
        {
            Animation.SetTrigger("IsDead");
        }
    }
}