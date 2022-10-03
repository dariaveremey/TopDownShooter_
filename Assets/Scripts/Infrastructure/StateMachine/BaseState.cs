namespace TDS.Assets.Infrastructure
{
    public abstract class BaseState: BaseExitableState,IState
    {
        protected BaseState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public abstract void Enter();
    }
}