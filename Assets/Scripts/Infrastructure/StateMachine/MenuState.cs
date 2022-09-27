using UnityEngine;

namespace TDS.Assets.Infrastructure.StateMachine
{
    public class MenuState: BaseState
    {
        public MenuState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }
        public override void Enter()
        {
            Debug.Log($"In MenuState");
        }

        public override void Exit()
        {
        }
    }
}