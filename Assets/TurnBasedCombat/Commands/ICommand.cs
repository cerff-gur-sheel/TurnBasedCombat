using TurnBasedCombat.Characters;

namespace TurnBasedCombat.Commands
{
    public interface ICommand
    {
        bool CanExecute(Character user);
        void Execute();
    }
}