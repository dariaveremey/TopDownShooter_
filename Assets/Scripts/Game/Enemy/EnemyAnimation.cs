using UnityEngine;

namespace TDS.Game.Zombie
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void ZombieShoot()
        {
            _animator.SetTrigger("Shoot");
        }

        public void Death()
        {
            _animator.SetTrigger("Death");
        }
    }
}