using System;
using UnityEngine;

namespace TDS.Assets.Scripts.Game.Player
{
    public class Statistics : SingletonMonoBehavior<Statistics>
    {
        [SerializeField] private int _lifes;
        
        
        //public event Action<int> OnLifeLeft;
        //public event Action<bool> OnLost;

        private int _reloadLifeNumber;  
        public int LifeNumber { get; private set; } = 5;
        public int LifeNumberZombie { get; private set; } = 1;
        

        public void IncrementLife(int number)
        {
            LifeNumber += number;
            /*if (LifeNumber >= 5)
                LifeNumber= 5;
            //OnLifeLeft?.Invoke(LifeNumber);
            if (LifeNumber == 0)
            {
                OnLost?.Invoke(true);
            }*/
        }
        public void IncrementLifeZombieLife(int number)
        {
            LifeNumberZombie += number;

        }
    }
}
