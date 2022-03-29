﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);//3 is the precesion for a float. The expected value must include the rounded float value to be valid
        }
    }
}