using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class BonusLifeAdd : BonusBase
    {
        [Header(nameof(BonusLifeAdd))]
        [SerializeField] private int _lives;

        protected override void ApplyEffect(Collision2D col)
        {
            PlayerHp playerHp = col.gameObject.GetComponentInParent<PlayerHp>();
            playerHp.ApplyHeal(_lives);
        }
    }
}