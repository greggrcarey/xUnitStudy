using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter sut;
        private readonly ITestOutputHelper output;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
           
            this.output = output;

            this.output.WriteLine("Creating new PlayerCharacter");
            sut = new PlayerCharacter();
        }
        public void Dispose() 
        { 
            output.WriteLine($"Disposing PlayerCharacter {sut.FullName}"); 
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            
            Assert.True(sut.IsNoob); //Test a boolean
        }
        [Fact]
        public void CalculateFullName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", sut.FullName);

        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            

            Assert.StartsWith("Sarah", sut.FullName);
        }
        [Fact]
        public void HaveFullNameEndsWithWithLastName()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.EndsWith("Smith", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCase()
        {

            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";
            

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);

        }
        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
          

            Assert.Contains("ah Sm", sut.FullName);

        }
        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);

        }
        [Fact]
        public void StartWithDefaultHealth()
        {
          
            Assert.Equal(100, sut.Health);
        }

        //Numberic Tests
        [Fact]
        public void IncreaseHealthAffterSleeping()
        {
         
            sut.Sleep();

            //You can add a conditional expression to Assert.Equals to test numeric values, but the Test Failures will not be expressive or helpful
            Assert.InRange(sut.Health, 101, 200);
        }
        [Fact]
        public void NotHaveNickNameByDefault()
        {
          

            Assert.Null(sut.Nickname); //There is also a NotNull method
        }
        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", sut.Weapons);
        }
        [Fact]
        public void NotHaveAStaffOfWonder()
        {
          
            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
          
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));//Assert against a predicate
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
          

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
        
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));//Asserts against each weapon in the collection
        }
        [Fact]
        public void RaiseSleptEvent()
        {
           

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }
        [Fact]
        public void RaisePropertyChangedEvent()
        {
         

            //Use the .PropertyChanged to test the INotifyPropertyChanged Interface of PlayerCharacter
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

       
    }
}
