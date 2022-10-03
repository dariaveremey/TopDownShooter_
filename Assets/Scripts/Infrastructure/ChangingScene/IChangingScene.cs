using System;

namespace TDS.Assets.Infrastructure
{
    public interface IChangingScene:IService
    {
        event Action OnBossDead;

        void ChangeLevel();
        void EndGame();
    }
}