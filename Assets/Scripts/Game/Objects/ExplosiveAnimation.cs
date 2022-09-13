using UnityEngine;

namespace TDS.Game.Objects
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