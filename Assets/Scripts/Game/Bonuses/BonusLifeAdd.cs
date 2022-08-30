using TDS.Assets.Scripts.Game.Player;
using UnityEngine;
using static TDS.Assets.Scripts.Game.Player.Statistics;

namespace TDS.Assets.Scripts.Game.Bonuses
{
    public class BonusLifeAdd : BonuseBase
    {
        [Header(nameof(BonusLifeAdd))]
        [SerializeField] private int _lives;

        protected override void ApplyEffect()
        {
            Statistics.Instance.IncrementLife(_lives);
        }
    }
}