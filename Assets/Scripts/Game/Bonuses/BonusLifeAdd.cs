using TDS.Game.Player;
using TDS.Game.Zombie;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class BonusLifeAdd : BonuseBase
    {
        [Header(nameof(BonusLifeAdd))]
        [SerializeField] private int _lives;
        [SerializeField] private PlayerHp _playerHp;

        protected override void ApplyEffect()
        {
            _playerHp.ApplyHeal(_lives);
        }
    }
}