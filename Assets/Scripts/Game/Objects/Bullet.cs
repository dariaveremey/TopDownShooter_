using System.Collections;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private int _enemyDamage = 1;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;

            StartCoroutine(LifeTimeTimer());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Enemy))
            {
                col.gameObject.GetComponentInParent<EnemyHp>().ApplyDamage(_enemyDamage);
            }
        }

        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}