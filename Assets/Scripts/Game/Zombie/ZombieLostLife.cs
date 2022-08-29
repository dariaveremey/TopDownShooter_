using TDS.Assets.Scripts.Game.Objects;
using TDS.Assets.Scripts.Game.Player;
using UnityEngine;

namespace TDS.Assets.Scripts.Game.Zombie
{
    public class ZombieLostLife : MonoBehaviour
    {
        [SerializeField] private ZombieAnimation _zombieAnimation;

        private void Update()
        {
            if (Statistics.Instance.LifeNumberZombie <= 0)
            {
                ZombieDeath();
            }
        }
        
        private void OnCollisionEnter2D(Collision2D col)

        {
            if (col.gameObject.CompareTag(Tags.PlayerBullet))
            {
                Statistics.Instance.IncrementLifeZombieLife(-1);
                Destroy(col.gameObject);
                
            }
        }

        private void ZombieDeath()
        {
            _zombieAnimation.Death();
        }
    }
}