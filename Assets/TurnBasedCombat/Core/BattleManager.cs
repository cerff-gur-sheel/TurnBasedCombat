using System;
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
        private readonly Dictionary<string, IBattleState> _states = new();
        
        [SerializeField]
        private List<CharacterData> players;
        
        internal readonly List<Character> PlayerTeam = new();
        
        [SerializeField]
        private List<CharacterData> enemies;
        
        internal readonly List<Character> EnemyTeam = new();
        public event Action OnVictory;
        public event Action OnDefeat; 
        
        private void Start()
        {
            // Initialize Characters
            foreach (var player in players) PlayerTeam.Add(new PlayerCharacter(player));
            foreach (var enemy in enemies) EnemyTeam.Add(new EnemyCharacter(enemy));
            
            // Initialize and register the states
            _states["StartTurn"]       = new StartTurnState(this);
            _states["SelectAction"]    = new SelectActionState(this);
            _states["ExecuteAction"]   = new ExecuteActionState(this);
            _states["EndTurn"]         = new EndTurnState(this);
            _states["Victory"]         = new VictoryState(this);
            _states["Defeat"]          = new DefeatState(this);
            
            // Define initial state
            ChangeState("StartTurn");
        }
        
        private void Update() => CurrentState?.Update();

        internal void RegisterState(string stateName, IBattleState state)
        {
            _states[stateName] = state;
        }       
        
        public void ChangeState(string stateName)
        {
            CurrentState?.Exit();

            if (CurrentState is VictoryState or DefeatState)
                return;

            if (_states.TryGetValue(stateName, out var newState))
            {
                CurrentState = newState;
                CurrentState.Enter();
            }
            else throw new KeyNotFoundException($"State '{stateName}' not found on BattleManager.");
        }
        
        internal void Victory() => OnVictory?.Invoke();
        internal void Defeat() => OnDefeat?.Invoke();
    }
}
