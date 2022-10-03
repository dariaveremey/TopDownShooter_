using System.Collections;
using UnityEngine;

namespace TDS.Assets.Game
{
    public class Explosive : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private ExplosiveAnimation _explosiveAnimation;
        [SerializeField] private float _radius = 5f;

        private bool _isExplode;
        private float _waiter = 4f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            ExplodeLogic();
            StartCoroutine(Destruction());
        }

        private void ExplodeLogic()
        {
            Explode();
            _explosiveAnimation.Explode();
        }

        private void Explode()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (Collider2D col in colliders)
            {
                IHealth health = col.GetComponentInParent<IHealth>();
                if (health != null)
                {
                    health.ApplyDamage(_damage);
                }
            }
        }

        private IEnumerator Destruction()
        {
            yield return new WaitForSeconds(_waiter);
            Destroy(gameObject);
        }
    }
}