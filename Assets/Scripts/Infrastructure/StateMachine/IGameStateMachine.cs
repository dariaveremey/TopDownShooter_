using TDS.Assets.Infrastructure.StateMachine;

namespace TDS.Assets.Infrastructure
{
    public interface IGameStateMachine:IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}