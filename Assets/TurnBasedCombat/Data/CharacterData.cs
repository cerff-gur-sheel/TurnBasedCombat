using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TurnBasedCombat.Data
{
    [CreateAssetMenu(fileName = "NewCharacter" ,menuName = "TurnBasedCombat/Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public int hp;
        public List<AttackData> attacks;
    }
}