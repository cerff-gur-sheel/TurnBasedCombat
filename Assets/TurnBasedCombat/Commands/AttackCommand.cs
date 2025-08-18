using System.Collections.Generic;
using TurnBasedCombat.Core;
using TurnBasedCombat.Data;
using UnityEngine;

namespace TurnBasedCombat.Commands
{
    public class AttackCommand : ICommand
    {
        private readonly Character _user;
        private readonly List<Character> _targets = new();
        private readonly AttackData _data;
        
        internal AttackCommand(Character user, Character target, AttackData data)
        {
            _user = user;
            _targets.Add(target);
            _data = data;
        }

        internal AttackCommand(Character user, List<Character> targets, AttackData data)
        {
            _user = user;
            _targets = targets;
            _data = data;
        }

        public bool CanExecute(Character user) => user.Stamina >= _data.staminaCost && user.Mana >= _data.manaCost;

        public void Execute()
        {
            foreach (var target in _targets)
            {
                target.TakeDamage(_data.baseDamage);
                Debug.Log($"{_user.CharacterName} " +
                          $"attacks {target.CharacterName} " +
                          $"using {_data.attackName} " +
                          $"causing {_data.baseDamage} of damage");
            }
        }
    }
}