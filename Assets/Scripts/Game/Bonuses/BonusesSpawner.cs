using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TDS.Assets.Game.Bonuses
{
    public class BonusesSpawner : MonoBehaviour
    {
        [SerializeField] private BonusSpawnData[] _bonusesPrefabArray;
        [SerializeField] private float _spawnRadius = 3.5f;
        
        [SerializeField] private Transform _enemy;

        private float _chanceValue;

        private void Start()
        {
            foreach (BonusSpawnData bonus in _bonusesPrefabArray)
            {
                _chanceValue += bonus.SpawnChance;
            }
        }

        public void SpawnItem()
        {
            float randomChance = Random.Range(0f, _chanceValue);
            float currentChance = 0;

            foreach (BonusSpawnData item in _bonusesPrefabArray)
            {
                currentChance += item.SpawnChance;

                if (currentChance >= randomChance)
                {
                    Vector2 randomSpawnPoint = Random.insideUnitCircle*_spawnRadius;
                    LeanPool.Spawn(item.Bonus, randomSpawnPoint, Quaternion.identity);
                    break;
                }
            }
        }
    }
}