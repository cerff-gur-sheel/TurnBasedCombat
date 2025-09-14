using TurnBasedCombat.Data;
using TurnBasedCombat.Strategies;

namespace TurnBasedCombat.Characters
{
    public class EnemyCharacter : Character
    {
        public EnemyCharacter(CharacterData data) : base(data) { }

        internal override void TakeTurn(BattleManager manager, Character self)
        {
            throw new System.NotImplementedException();
        }

        public IAttackStrategy Strategy;
        
        public void SetStrategy(IAttackStrategy strategy) =>  Strategy = strategy;
    }
}