using UnityEngine;

namespace TDS.Assets.Game
{
    public class EnemyAnimationBoss : AnimationBase
    { 
        [SerializeField] private Animator _animator;
        
        private readonly string[] _states = {"FirstAttack", "SecondAttack", "ThirdAttack"};
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        public override void PlayAttack()
        {
            _animator.SetTrigger(_states[Random.Range(0,_states.Length)]);
           
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