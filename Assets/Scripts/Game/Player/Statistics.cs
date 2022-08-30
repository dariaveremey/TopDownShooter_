using UnityEngine;

namespace TDS.Assets.Scripts.Game.Player
{
    public class Statistics : SingletonMonoBehavior<Statistics>
    {

        private int _reloadLifeNumber;
        public int LifeNumber { get; private set; } = 5;
        public int LifeNumberZombie { get; private set; } = 1;

        public void IncrementLife(int number)
        {
            LifeNumber += number;
        }

        public void IncrementLifeZombieLife(int number)
        {
            LifeNumberZombie += number;
        }
    }
}