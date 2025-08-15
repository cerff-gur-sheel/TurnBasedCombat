using NUnit.Framework;
using TurnBasedCombat.Core;

namespace TurnBasedCombat.Tests
{
    public class BattleManagerTest
    {
        private class MockState : IBattleState
        {
            public string Name;
            public bool EnterCalled;
            public bool ExitCalled;
            private readonly string _nextState;

            private readonly BattleManager _manager;

            public MockState(string name, string next, BattleManager m)
            {
                Name = name;
                _nextState = next;
                _manager = m;
            }

            public void Enter() { EnterCalled = true; }
            public void Update() { _manager.ChangeState(_nextState); }
            public void Exit() { ExitCalled = true; }
        }

        [Test]
        public void TestBattleLoop()
        {
            // ReSharper disable once Unity.IncorrectMonoBehaviourInstantiation
            var manager = new BattleManager();
            
            var stateA = new MockState("A", "B", manager);
            var stateB = new MockState("B", "C", manager);
            var stateC = new MockState("C", "A", manager);

            manager.RegisterState("A", stateA);
            manager.RegisterState("B", stateB);
            manager.RegisterState("C", stateC);
            manager.ChangeState("A");

            manager.CurrentState.Update(); // A -> B
            Assert.IsTrue(stateA.EnterCalled);
            Assert.IsTrue(stateA.ExitCalled);

            manager.CurrentState.Update(); // B -> C
            Assert.IsTrue(stateB.EnterCalled);
            Assert.IsTrue(stateB.ExitCalled);

            manager.CurrentState.Update(); // C -> A
            Assert.IsTrue(stateC.EnterCalled);
            Assert.IsTrue(stateC.ExitCalled);
        }
    }
}