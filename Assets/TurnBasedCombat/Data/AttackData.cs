using UnityEngine;

namespace TurnBasedCombat.Data
{
    [CreateAssetMenu(fileName = "NewAttack",menuName = "")]
    public class AttackData : ScriptableObject
    {
        public string attackName;
        public int baseDamage;
        public float multiplier;
        public Sprite icon;
        public bool areaAttack;
        public bool selectableTarget;
    }
}