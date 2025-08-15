using TurnBasedCombat.Core;
using UnityEngine;

namespace TurnBasedCombat.States
{
    public class VictoryState : IBattleState
    {
        public VictoryState(BattleManager manager)
        {
           
        }
        public void Enter()
        {
            
            Debug.Log("Enter Victory State");
        }

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