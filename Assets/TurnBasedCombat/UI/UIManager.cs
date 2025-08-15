using System;
using TurnBasedCombat.Core;
using UnityEngine;

namespace TurnBasedCombat.UI
{
    public class UIManager : MonoBehaviour
    {
        public event Action<string> OnMessageGenerated;

        public void Subscribe(BattleManager battleManager, Character player, Character enemy)
        {
        }
    }
}