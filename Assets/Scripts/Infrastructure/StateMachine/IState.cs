namespace TDS.Assets.Infrastructure
{
    public interface IState:IExitableState
    {
        void Enter();
    }
}