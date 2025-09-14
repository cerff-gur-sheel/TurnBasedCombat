namespace TurnBasedCombat.States
{
    public interface IBattleState
    {
        void Enter();
        void Update();
        void Exit();
    }
}