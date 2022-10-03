using UnityEngine;

namespace TDS.Assets.Game
{
    public abstract class AnimationBase: MonoBehaviour
    {
        public abstract void PlayAttack();
        public abstract void SetSpeed(float speed);
        public abstract void Death();

    }
}