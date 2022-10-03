using System;

namespace TDS.Assets.Infrastructure
{
    public class ChangingScene : IChangingScene
    {
        public event Action OnBossDead;
        
        public void ChangeLevel()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}