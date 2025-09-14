using UnityEngine;

namespace TurnBasedCombat.States
{
    public class EndTurnState : IBattleState
    {
        private readonly BattleManager _manager;
        
        public EndTurnState(BattleManager manager)
        {
            _manager = manager;
        }
        
        public void Enter()
        {
        }

        public void Update()
        {
            if (_manager.PlayerTeam.TrueForAll(c => c.Hp <= 0)) _manager.ChangeState("Defeat");
            else if (_manager.EnemyTeam.TrueForAll(c => c.Hp <= 0)) _manager.ChangeState("Victory");
            else _manager.ChangeState("StartTurn");
        }

        public void Exit()
        {
        }
    }
}