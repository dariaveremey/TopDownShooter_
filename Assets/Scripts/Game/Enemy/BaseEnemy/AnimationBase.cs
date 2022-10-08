using UnityEngine;

namespace TDS.Assets.Game
{
    public abstract class AnimationBase: MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        protected Animator Animation => _animator;
        
        public abstract void PlayAttack();
        public abstract void SetSpeed(float speed);
        public abstract void Death();

    }
}