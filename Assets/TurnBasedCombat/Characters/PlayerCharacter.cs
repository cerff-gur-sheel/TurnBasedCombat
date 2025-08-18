using TurnBasedCombat.Core;
using TurnBasedCombat.Data;

namespace TurnBasedCombat.Characters
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(CharacterData data) : base(data) { }

        internal override void TakeTurn(BattleManager manager, Character self)
        {
            throw new System.NotImplementedException();
        }
    }
}