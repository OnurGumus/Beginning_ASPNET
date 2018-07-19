using System;
using System.ComponentModel;
using FindMyNumber;
using FakeItEasy;
using SpecLight;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        FindMyNumberGame game;
        IRandomGenerator random;
        string result;
        [Theory]
        [InlineData(0,1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [Description(@"Given the game picks a random number $y
When I make a guess $x
Then if $x is smaller than $y then game should return ""smaller""
And if  $x is larger than $y  then the game should return ""larger""
And if $x is equal than $y  then the game should return ""equal""

")]
        public void Test1(int x, int y)
        {
            random = A.Fake<IRandomGenerator>();

            game = new FindMyNumberGame(random);

            new Spec(@"")
                .Given(TheGamePicksARandomNumber_, y)
                .When(IMakeAGuess_, x)
                .Then(If_IsSmallerThan_ThenGameShouldReturn_, x, y, "smaller")
                .And(If_IsLargerThan_ThenTheGameShouldReturn_, x, y, "larger")
                .And(If_IsEqualThan_ThenTheGameShouldReturn_, x, y, "equal")
                .Execute();



        }

        void TheGamePicksARandomNumber_(int o0)
        {
            A.CallTo(() =>  random.GenerateARandomNumber()).Returns(o0);
            game.PickARandomNumber();
        }

        void IMakeAGuess_(int o0)
        {
            result = game.MakeAGuess(o0);
        }

        void If_IsSmallerThan_ThenGameShouldReturn_(int o0, int o1, string o2)
        {
            if(o0<o1)
            {
                Assert.Same(o2, result);
            }
        }

        void If_IsLargerThan_ThenTheGameShouldReturn_(int o0, int o1, string o2)
        {
            if (o0 > o1)
            {
                Assert.Same(o2, result);
            }
        }

        void If_IsEqualThan_ThenTheGameShouldReturn_(int o0, int o1, string o2)
        {
            if (o0 == o1)
            {
                Assert.Same(o2, result);
            }
        }
    }
}
