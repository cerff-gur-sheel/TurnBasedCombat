using TurnBasedCombat.Core;
using UnityEngine;

namespace TurnBasedCombat.States
{
    public class ExecuteActionState : IBattleState
    {
        private readonly BattleManager _manager;
        
        public ExecuteActionState(BattleManager manager)
        {
            _manager = manager;
        }

        public void Enter()
        {
            Debug.Log("[ExecuteAction] Enter");
        }

        public void Update()
        {
            _manager.ChangeState("EndTurn");
        }

        public void Exit()
        {
            Debug.Log("[ExecuteAction] Exit");
        }
    }
}