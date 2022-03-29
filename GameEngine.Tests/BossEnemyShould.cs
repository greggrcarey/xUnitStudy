using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Category","Boss")]
        public void HaveCorrectPower()
        {
            output.WriteLine("Creating Boss Enemny");
            BossEnemy sut = new();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);//3 is the precesion for a float. The expected value must include the rounded float value to be valid
        }
    }
}
