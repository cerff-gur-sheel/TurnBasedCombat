using System.Collections.Generic;
using TurnBasedCombat.Core;

namespace TurnBasedCombat.Strategies
{
    public interface IAttackStrategy
    {
        ICommand ChooseCommand(Character self, List<Character> targets);
    }
}