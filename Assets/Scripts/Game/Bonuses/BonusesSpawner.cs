using System.Collections;
using Lean.Pool;
using TDS.Assets.Game;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class BonusesSpawner : MonoBehaviour
    {
        [SerializeField] private BonusBase[] _bonusesPrefabArray;
        [Range(0, 5)]
        [SerializeField] private float _xMax;
        [Range(0, 8)]
        [SerializeField] private float _yMax;
        [SerializeField] private Transform _enemy;

        private float _chanceValue;

        private void Start()
        {
            foreach (BonusBase bonus in _bonusesPrefabArray)
            {
                _chanceValue += bonus.SpawnChance;
            }
        }

        public void SpawnItem()
        {
            float randomChance = Random.Range(0f, _chanceValue);
            float currentChance = 0;

            foreach (BonusBase item in _bonusesPrefabArray)
            {
                currentChance += item.SpawnChance;

                if (currentChance >= randomChance)
                {
                    Vector2 randomDirection = new Vector2(transform.position.x + _xMax, transform.position.y + _yMax);
                    LeanPool.Spawn(item, randomDirection, Quaternion.identity);
                    break;
                }
            }
        }
    }
}