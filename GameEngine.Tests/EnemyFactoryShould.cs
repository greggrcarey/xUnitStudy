using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        
        public void CreateNormalByDefault()
        {
            EnemyFactory sut = new();
            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }
        [Fact(Skip = "Dont' need to run this")]
        public void CreateNormalByDefault_NotTypeExample()
        {
            EnemyFactory sut = new();
            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<BossEnemy>(enemy);
        }
        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new();
            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }
        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new();
            Enemy enemy = sut.Create("Zombie King", true);

            //Assert and get the cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            //Additional asserts on the types object
            Assert.Equal("Zombie King", boss.Name);
        }
        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new();
            Enemy enemy = sut.Create("Zombie King", true);

            //IsType is a strict check so this check fails
            //Assert.IsType<Enemy>(enemy);

            //This Assert check the inheritance chain
            Assert.IsAssignableFrom<Enemy>(enemy);
            
        }
        [Fact]
        public void CreateSeperateInstances()
        {
            EnemyFactory sut = new();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);

        }
        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new();

            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));

            //You can also specifiy the parameter you are passing 
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }
        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new();

            //By assigning the result of the assert, we can further assert on the exception
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
