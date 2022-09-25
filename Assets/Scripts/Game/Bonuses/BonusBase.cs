using UnityEngine;

namespace TDS.Game.Bonuses
{
    public abstract class BonuseBase : MonoBehaviour
    {
        [SerializeField] private float _spawnChance;

        public float SpawnChance => _spawnChance;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Player))
            {
                return;
            }

            ApplyEffect();
        }

        protected abstract void ApplyEffect();
    }
}