using TurnBasedCombat.Core;
using TurnBasedCombat.Data;

namespace TurnBasedCombat.Characters
{
    public class EnemyCharacter : Character
    {
        public EnemyCharacter(CharacterData data) : base(data) { }

        internal override void TakeTurn(BattleManager manager, Character self)
        {
            throw new System.NotImplementedException();
        }
    }
}