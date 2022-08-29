using UnityEngine;

namespace TDS.Assets.Scripts.Game.Zombie
{
    public class ZombieAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void ZombieShoot()
        {
            _animator.SetTrigger("Shoot");
        }

        public void Death()
        {
            _animator.Play("Death");
        }
    }
}