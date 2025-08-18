namespace TurnBasedCombat.Core
{
    public interface ICommand
    {
        bool CanExecute(Character user);
        void Execute();
    }
}