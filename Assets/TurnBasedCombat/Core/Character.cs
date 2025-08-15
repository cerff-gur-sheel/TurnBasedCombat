using System.Collections.Generic;
using TurnBasedCombat.Data;
using UnityEngine;

namespace TurnBasedCombat.Core
{
    public class Character
    {
        private readonly CharacterData _data;

        public string CharacterName => _data.characterName;
        
        public int Hp { get; private set; }
        
        public bool IsAlive => Hp > 0;
        
        public IReadOnlyList<AttackData> Attacks => _data.attacks;

        public Character(CharacterData data)
        {
            _data = data;
            Hp = data.hp;
        }

        public void TakeDamage(int damage)
        {
            Hp = Mathf.Max(Hp - damage, 0);
        }
    }
}