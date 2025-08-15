using TurnBasedCombat.Core;
using UnityEngine;

namespace TurnBasedCombat.States
{
    public class DefeatState : IBattleState
    {
        private BattleManager _manager;
        public DefeatState(BattleManager manager)
        {
            _manager = manager;
        }
        public void Enter() => _manager.Defeat();

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
        }
    }
}