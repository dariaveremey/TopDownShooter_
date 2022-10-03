using System;
using TDS.Assets.Infrastructure;

namespace TDS.Assets.Game
{
    public interface INpcService : IService
    {
        event Action OnAllDead;

        void Init();
        void Dispose();
    }
}