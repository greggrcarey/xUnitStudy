using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter(); //sut stands for System Under Test
            Assert.True(sut.IsNoob); //Test a boolean
        }
        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            Assert.Equal("Sarah Smith", sut.FullName);

        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            Assert.StartsWith("Sarah", sut.FullName);
        }
        [Fact]
        public void HaveFullNameEndsWithWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            Assert.EndsWith("Smith", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCase()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "SARAH",
                LastName = "SMITH"
            };

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);

        }
        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            Assert.Contains("ah Sm", sut.FullName);

        }
        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);

        }
        [Fact]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();
            Assert.Equal(100, sut.Health);
        }

        //Numberic Tests
        [Fact]
        public void IncreaseHealthAffterSleeping()
        {
            PlayerCharacter sut = new();
            sut.Sleep();

            //You can add a conditional expression to Assert.Equals to test numeric values, but the Test Failures will not be expressive or helpful
            Assert.InRange(sut.Health, 101, 200);
        }
        [Fact]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter sut = new();

            Assert.Null(sut.Nickname); //There is also a NotNull method
        }
        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new();
            Assert.Contains("Long Bow", sut.Weapons);
        }
        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter sut = new();
            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new();
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));//Assert against a predicate
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }
        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new();
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));//Asserts against each weapon in the collection
        }
        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }
        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new();

            //Use the .PropertyChanged to test the INotifyPropertyChanged Interface of PlayerCharacter
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }


    }
}
