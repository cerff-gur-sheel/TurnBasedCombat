using System.Collections.Generic;
using NUnit.Framework;
using TurnBasedCombat.Characters;
using TurnBasedCombat.Commands;
using TurnBasedCombat.Data;
using UnityEngine;

namespace TurnBasedCombat.Tests
{
    public class AttackCommandTests
    {
        private Character _player;
        private Character _enemy1;
        private Character _enemy2;

        [SetUp]
        public void Setup()
        {
            var attackData = ScriptableObject.CreateInstance<AttackData>();
            attackData.attackName = "sample Attack";
            attackData.baseDamage = 10;
            
            var playerData = ScriptableObject.CreateInstance<CharacterData>();
            playerData.characterName = "Hero";
            playerData.attacks = new List<AttackData> { attackData };
            playerData.hp = 50;
            _player = new PlayerCharacter(playerData);

            var enemyData = ScriptableObject.CreateInstance<CharacterData>();
            enemyData.characterName = "Goblin";
            enemyData.attacks = new List<AttackData> { attackData };
            enemyData.hp = 20;
            _enemy1 =  new EnemyCharacter(enemyData);
            _enemy2 =  new EnemyCharacter(enemyData);
        }

        [Test]
        public void SingleTargetAttack_ReducesHP()
        {
            var attack = new AttackCommand(_player, new List<Character>{ _enemy1 }, _player.Attacks[0]);
            attack.Execute();
            Assert.AreEqual(10, _enemy1.Hp);
        }

        [Test]
        public void AreaAttack_ReducesAllTargetsHP()
        {
            var enemies = new List<Character> { _enemy1, _enemy2 };
            var aoe = new AttackCommand(_player, enemies, _player.Attacks[0]);
            aoe.Execute();
            Assert.AreEqual(10, _enemy1.Hp);
            Assert.AreEqual(10, _enemy2.Hp);
        }
    }
}