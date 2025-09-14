using System.Collections.Generic;
using TurnBasedCombat.Characters;
using TurnBasedCombat.Commands;

namespace TurnBasedCombat.Strategies
{
    public interface IAttackStrategy
    {
        ICommand ChooseCommand(Character self, List<Character> targets);
    }
}