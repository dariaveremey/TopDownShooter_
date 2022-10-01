using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class BonusesSpawner : MonoBehaviour
    {
        [SerializeField] private BonuseBase[] _bonusesPrefabArray;
        [SerializeField] private float _startTime;
        [SerializeField] private float _repeatingTime;

        private float _chanceValue;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnItem), _startTime, _repeatingTime);

            foreach (BonuseBase bonus in _bonusesPrefabArray)
            {
                _chanceValue += bonus.SpawnChance;
            }
        }

        private void SpawnItem()
        {
            float randomChance = Random.Range(0f, _chanceValue);
            float currentChance = 0;
            Vector3 min =
                Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            Vector3 max =
                Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));

            Vector3 randomPosition = new(Random.Range(min.x, min.y), Random.Range(max.x, max.y));

            foreach (BonuseBase item in _bonusesPrefabArray)
            {
                currentChance += item.SpawnChance;
                if (currentChance >= randomChance)
                {
                    LeanPool.Spawn(item, randomPosition, Quaternion.identity);
                    break;
                }
            }
        }
    }
}