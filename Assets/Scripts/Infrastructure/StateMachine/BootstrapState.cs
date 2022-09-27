using TDS.Assets.Infrastructure.SceneLoader;
using TDS.Assets.Infrastructure.ServicesContainer;
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
            Debug.Log($"StartOnBootstrapState");
            RegisterAllGlobalServices();
            ISceneLoadService sceneLoadService=Services.Container.Get<ISceneLoadService>();
            sceneLoadService.Load("MenuScene",OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            StateMachine.Enter<MenuState>();
        }

        private void RegisterAllGlobalServices()
        {
            Services.Container.Register<ISceneLoadService>(new SyncSceneLoadService());
        }

        public override void Exit()
        {
        }


    }
}