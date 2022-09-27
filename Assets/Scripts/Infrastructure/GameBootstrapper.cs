using TDS.Assets.Infrastructure.ServicesContainer;
using TDS.Assets.Infrastructure.StateMachine;
using UnityEngine;

namespace TDS.Assets.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            GameStateMachine gameStateMachine = new GameStateMachine();
            Services.Container.Register<IGameStateMachine>(gameStateMachine);

            gameStateMachine.Enter<BootstrapState>();
        }
    }
}