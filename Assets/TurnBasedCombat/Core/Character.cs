using System;
using System.Collections.Generic;
using TurnBasedCombat.Data;
using UnityEngine;

namespace TurnBasedCombat.Core
{
    public abstract class Character
    {
        private readonly CharacterData _data;
        
        public string CharacterName => _data.characterName;
        
        public int Hp { get; private set; }
        
        public int Stamina { get; private set; }
        public int Mana { get; private set; }
        
        public bool IsAlive => Hp > 0;
        
        public IReadOnlyList<AttackData> Attacks => _data.attacks;
        
        public event Action<Character, int> OnDamageTaken;
        public event Action<Character> OnDeath; 
        
        protected Character(CharacterData data)
        {
            _data = data;
            Hp = data.hp;
        }

        internal void TakeDamage(int damage)
        {
            Hp = Mathf.Max(Hp - damage, 0);
            OnDamageTaken?.Invoke(this, damage);
            if (Hp == 0) OnDeath?.Invoke(this);
        }

        internal void ExecuteCommand(ICommand command)
        {
            if (command.CanExecute(this))
            {
                command.Execute();
            }
        }
        
        internal abstract void TakeTurn(BattleManager manager, Character self);
    }
}