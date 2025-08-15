using TurnBasedCombat.Core;
using UnityEngine;

namespace TurnBasedCombat.States
{
    public class SelectActionState : IBattleState
    {
        private readonly BattleManager _manager;
        
        public SelectActionState(BattleManager manager)
        {
            _manager = manager;
        }
        
        public void Enter()
        {
            Debug.Log("[SelectAction] Enter");
        }

        public void Update()
        {
            _manager.ChangeState("ExecuteAction");
        }

        public void Exit()
        {
            Debug.Log("[SelectAction] Exit");
        }
    }
}