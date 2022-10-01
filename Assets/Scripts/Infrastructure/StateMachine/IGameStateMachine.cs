using TDS.Assets.Infrastructure.ServicesContainer;

namespace TDS.Assets.Infrastructure.StateMachine
{
    public interface IGameStateMachine:IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}