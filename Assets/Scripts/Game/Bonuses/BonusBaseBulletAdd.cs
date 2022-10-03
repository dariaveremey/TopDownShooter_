using Lean.Pool;
using TDS.Assets.Game;
using UnityEngine;

namespace TDS.Game.Bonuses
{
    public class BonusBaseBulletAdd : BonusBase
    {
        [Header(nameof(BonusBaseBulletAdd))]
        [SerializeField] private int _bullets;
        protected override void ApplyEffect(Collision2D col)
        {
            PlayerAttack playerAttack = col.gameObject.GetComponentInParent<PlayerAttack>();
            playerAttack.AddBulletsNumber(_bullets);
            
            LeanPool.Despawn(gameObject);
            
        }
    }
}



