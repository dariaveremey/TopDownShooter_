using System;
using TDS.Game.Bonuses;

namespace TDS.Assets.Game.Bonuses
{
    [Serializable] 
    public struct BonusSpawnData
    {
        public float SpawnChance;
        public BonusBase Bonus;
    }
}

