namespace TurnBasedCombat.Core
{
    public interface IBattleState
    {
        void Enter();
        void Update();
        void Exit();
    }
}