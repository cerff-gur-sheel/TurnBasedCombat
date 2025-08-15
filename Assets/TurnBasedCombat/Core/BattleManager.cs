using System.Collections.Generic;
using TurnBasedCombat.Characters;
using TurnBasedCombat.Data;
using TurnBasedCombat.States;
using UnityEngine;

namespace TurnBasedCombat.Core
{
    public class BattleManager : MonoBehaviour
    { 
        internal IBattleState CurrentState { get; private set; }
        private Dictionary<string, IBattleState> states = new();
        
        [SerializeField]
        private List<CharacterData> players;
        
        internal readonly List<Character> PlayerTeam = new();
        
        [SerializeField]
        private List<CharacterData> enemies;
        
        internal readonly List<Character> EnemyTeam = new();
        
        private void Start()
        {
            // Initialize Characters
            foreach (var player in players) PlayerTeam.Add(new PlayerCharacter(player));
            foreach (var enemy in enemies) EnemyTeam.Add(new EnemyCharacter(enemy));
            
            // Initialize and register the states
            states["StartTurn"]       = new StartTurnState(this);
            states["SelectAction"]    = new SelectActionState(this);
            states["ExecuteAction"]   = new ExecuteActionState(this);
            states["EndTurn"]         = new EndTurnState(this);
            states["Victory"]         = new VictoryState(this);
            states["Defeat"]          = new DefeatState(this);
            
            // Define initial state
            ChangeState("StartTurn");
        }
        
        private void Update() => CurrentState?.Update();

        internal void RegisterState(string name, IBattleState state)
        {
            states[name] = state;
        }       
        
        public void ChangeState(string stateName)
        {
            CurrentState?.Exit();

            if (CurrentState is VictoryState || CurrentState is DefeatState)
                return;

            if (states.TryGetValue(stateName, out var newState))
            {
                CurrentState = newState;
                CurrentState.Enter();
            }
            else throw new KeyNotFoundException($"State '{stateName}' not found on BattleManager.");
        }
    }
}
