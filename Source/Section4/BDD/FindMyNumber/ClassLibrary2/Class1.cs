using System;

namespace FindMyNumber
{

    public interface IRandomGenerator
    {
        int GenerateARandomNumber();
    }
    public class FindMyNumberGame
    {
       readonly IRandomGenerator randomGenerator;
        int pickedNumber;
        public FindMyNumberGame(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public void PickARandomNumber()
        {
           pickedNumber =   randomGenerator.GenerateARandomNumber();
        }

        public string MakeAGuess(int x)
        {
            if (x == pickedNumber)
            {
                return "equal";
            }
            else if (x < pickedNumber)
            {
                return "smaller";
            }
            else
                return "larger";
        }
    }
}
