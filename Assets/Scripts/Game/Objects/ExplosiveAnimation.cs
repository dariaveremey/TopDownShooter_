using UnityEngine;

namespace TDS.Assets.Game
{
    public class ExplosiveAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animatorExplosion;

        public void Explode()
        {
            _animatorExplosion.SetTrigger("ExplosiveBarrel");
        }
    }
}