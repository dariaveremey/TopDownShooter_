using UnityEngine;

namespace TDS.Assets.Infrastructure.StateMachine
{
    public class BootstrapState: BaseState
    {
        public BootstrapState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log($"In BootstrapState");

            RegisterAllGlobalServices();
            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
        }

        private void RegisterAllGlobalServices()
        {
            Services.Container.RegisterMono<ICoroutineRunner>(typeof(CoroutineRunner));
            Services.Container.Register<ISceneLoadService>(
                new AsyncSceneLoadService(Services.Container.Get<ICoroutineRunner>()));
            Services.Container.Register<ILoadingScreenService>(new LoadingScreenService());
        }
    }
}