using TDS.Assets.Infrastructure.Coroutine;
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
            CreateCoroutineRunner();
            Services.Container.Register<ISceneLoadService>(
                new SyncSceneLoadService(Services.Container.Get<ICoroutineRunner>()));
        }

        
        private void CreateCoroutineRunner()
        {
            CoroutineRunner coroutineRunner =
                new GameObject(nameof(CoroutineRunner)).AddComponent<CoroutineRunner>();
            Object.DontDestroyOnLoad(coroutineRunner);
            Services.Container.Register<ICoroutineRunner>(coroutineRunner);
        }

        public override void Exit()
        {
        }


    }
}