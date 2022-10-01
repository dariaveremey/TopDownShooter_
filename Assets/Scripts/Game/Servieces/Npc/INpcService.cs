using System;
using TDS.Assets.Infrastructure.ServicesContainer;

namespace TDS.Game.Servieces.Npc
{
    public interface INpcService:IService
    {
        event Action OnAllDead;
        
        void Init();
        void Dispose();

    }
}