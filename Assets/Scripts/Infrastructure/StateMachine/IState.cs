namespace TDS.Assets.Infrastructure.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}