using System.Collections.Generic;
using TurnBasedCombat.Core;
using TurnBasedCombat.Data;
using UnityEngine;

namespace TurnBasedCombat.Commands
{
    public class AttackCommand : ICommand
    {
        private Character attacker;
        private List<Character> targets = new();
        private AttackData data;
        
        internal AttackCommand(Character attacker, Character target, AttackData data)
        {
            this.attacker = attacker;
            targets.Add(target);
            this.data = data;
        }

        internal AttackCommand(Character attacker, List<Character> targets, AttackData data)
        {
            this.attacker = attacker;
            this.targets = targets;
            this.data = data;
        }
        
        public void Execute()
        {
            foreach (var target in targets)
            {
                target.TakeDamage(data.baseDamage);
                Debug.Log($"{attacker.CharacterName} attacks {target.CharacterName} using {data.attackName} causing {data.baseDamage} of damage");
            }
        }
    }
}