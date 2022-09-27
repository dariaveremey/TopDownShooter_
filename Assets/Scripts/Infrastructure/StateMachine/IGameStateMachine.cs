using TDS.Assets.Infrastructure.ServicesContainer;

namespace TDS.Assets.Infrastructure.StateMachine
{
    public interface IGameStateMachine:IService
    {
        void Enter<TState>() where TState:IState;
    }
}