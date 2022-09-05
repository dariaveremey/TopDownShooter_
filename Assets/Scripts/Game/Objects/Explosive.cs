using UnityEngine;

namespace TDS.Game.Objects
{
    public class Explosive : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private ExplosiveAnimation _explosiveAnimation;

        private bool _isExplode;

        private void OnCollisionEnter2D(Collision2D col)
        {
            ExplodeLogic();
        }

        private void ExplodeLogic()
        {
            Explode();
            _explosiveAnimation.Explode();
        }

        private void Explode()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector3.zero, 10);

            foreach (Collider2D col in colliders)
            {
                IHealth health = col.GetComponentInParent<IHealth>();
                if (health != null)
                {
                    health.ApplyDamage(_damage);
                }
            }
        }
    }
}