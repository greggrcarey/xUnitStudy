using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]//No other Implementation, Add Attribute only
    [Trait("Collection", "GameState Collection Example")]
    public class TestClass1
    {
        private readonly GameStateFixture gameStateFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public TestClass1(GameStateFixture gameStateFixture, ITestOutputHelper testOutputHelper)
        {
            this.gameStateFixture = gameStateFixture;   
            this.testOutputHelper = testOutputHelper;  
        }
        [Fact]
        public void Test1()
        {
            testOutputHelper.WriteLine($"GameState ID={gameStateFixture.State.Id}");
        }
        [Fact]
        public void Test2()
        {
            testOutputHelper.WriteLine($"GameState ID={gameStateFixture.State.Id}");
        }

    }
}
