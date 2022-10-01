namespace TDS.Assets.Infrastructure.StateMachine
{
    public interface IState:IExitableState
    {
        void Enter();
    }
}