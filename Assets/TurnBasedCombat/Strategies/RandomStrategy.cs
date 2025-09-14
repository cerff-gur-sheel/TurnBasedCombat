using System;
using System.Collections.Generic;
using TurnBasedCombat.Characters;
using TurnBasedCombat.Commands;

namespace TurnBasedCombat.Strategies
{
    public class RandomStrategy : IAttackStrategy
    {
        public ICommand ChooseCommand(Character self, List<Character> targets)
        {
            var attacks = self.Attacks;
            var index = new Random().Next(attacks.Count);
            
            return new AttackCommand(self, targets, attacks[index]);
        }
    }
}