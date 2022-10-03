namespace TDS.Assets.Infrastructure
{
    public abstract class BaseExitableState: IExitableState
    {
        protected IGameStateMachine StateMachine { get; }

        protected BaseExitableState(IGameStateMachine gameStateMachine)
        {
            StateMachine = gameStateMachine;
        }
        
        public abstract void Exit();
    }
}