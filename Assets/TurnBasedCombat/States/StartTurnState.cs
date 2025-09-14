using UnityEngine;

namespace TurnBasedCombat.States
{
    public class StartTurnState : IBattleState
    {
        private readonly BattleManager _manager;
        
        public StartTurnState(BattleManager manager)
        {
            _manager = manager;
        }
        
        public void Enter()
        {
        }

        public void Update()
        {
            _manager.ChangeState("SelectAction");
        }

        public void Exit()
        {
        }
    }
}