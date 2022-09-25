using UnityEngine;

namespace TDS.Assets.Game.Enemy.Base
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int Speed = Animator.StringToHash("Speed");

        public void PlayAttack()
        {
            _animator.SetTrigger("IsAttack");
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }

        public void Death()
        {
            _animator.SetTrigger("IsDead");
        }
    }
}