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


    }
}
