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
    [Trait("Collection","GameState Collection Example")]
    public class TestClass2
    {
        private readonly GameStateFixture gameStateFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public TestClass2(GameStateFixture gameStateFixture, ITestOutputHelper testOutputHelper)
        {
            this.gameStateFixture = gameStateFixture;   
            this.testOutputHelper = testOutputHelper;  
        }
        [Fact]
        public void Test3()
        {
            testOutputHelper.WriteLine($"GameState ID={gameStateFixture.State.Id}");
        }
        [Fact]
        public void Test4()
        {
            testOutputHelper.WriteLine($"GameState ID={gameStateFixture.State.Id}");
        }

    }
}
