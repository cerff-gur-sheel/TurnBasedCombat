using TurnBasedCombat.Core;
using UnityEngine;

namespace TurnBasedCombat.States
{
    public class VictoryState : IBattleState
    {
        private readonly BattleManager _manager;
        
        public VictoryState(BattleManager manager)
        {
           _manager = manager;
        }
     
        public void Enter() => _manager.Victory();
        
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}