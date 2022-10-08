using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyAnimationBoss : AnimationBase
    { 
        
        private readonly string[] _states = {"FirstAttack", "SecondAttack", "ThirdAttack"};
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        public override void PlayAttack()
        {
            string animationTrigger = _states[Random.Range(0, _states.Length)];
            Animation.SetTrigger(animationTrigger);
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