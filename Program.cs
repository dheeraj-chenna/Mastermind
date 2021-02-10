using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerProgramApp
{
    class Program
    {
        #region Game Counter
        /// <summary>
        /// Counter
        /// </summary>
        private static int counter = 1;
        #endregion

        /// <summary>
        /// Method to Entry the Player Game
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            #region Generate Number
            string generatedRandom = GenerateRandomNumber();
            #endregion

            Console.WriteLine("Playing Game");
            Console.WriteLine("Guess a combination of 4 digits ranging from 1 to 6");

            #region User Input Combination
            string userInput = Console.ReadLine();
            #endregion 

            #region Run the Game
            string output = string.Empty;

            do
            {
                if (userInput.Length == 4 && IsDigitsOnly(userInput))
                {
                    if (!string.IsNullOrEmpty(generatedRandom) && !string.IsNullOrEmpty(userInput) && userInput.Length == 4 && generatedRandom.Length == 4)
                    {
                        output = ValidateUserInput(generatedRandom, userInput);
                        if (!string.IsNullOrEmpty(output))
                        {
                            Console.WriteLine("Your Result: " + output);
                            Console.WriteLine("- : Guessed digit is correct but not in correct order");
                            Console.WriteLine("+ : Guessed digit is correct and in correct order");
                            userInput = "E";
                        }
                        else
                        {
                            Console.WriteLine("Try once Again or Press E to exit the game");
                            userInput = Console.ReadLine();
                        }
                        IncrementCounter(counter);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please try again or Press E to exit the game");
                    userInput = Console.ReadLine();
                }

            }
            while (counter < 11 && userInput.ToUpper() != "E");
            if (counter == 11)
            {
                Console.WriteLine("You have Lost");
                Console.ReadLine();
            }
            if (userInput.ToUpper() == "E")
            {
                Console.WriteLine("Happy Gaming. Have a nice day.");
                Console.ReadLine();
            }
            #endregion

        }

        /// <summary>
        /// Method to Increment the counter
        /// </summary>
        /// <param name="value"></param>
        private static void IncrementCounter(int value)
        {
            counter = value + 1;
        }

        /// <summary>
        /// Method to Validate user combination with generated comination
        /// </summary>
        /// <param name="generatedRandom"></param>
        /// <param name="userInput"></param>
        /// <returns></returns>
        private static string ValidateUserInput(string generatedRandom, string userInput)
        {
            string result = string.Empty;
            List<string> lstInputDigits = new List<string>();
            List<string> lstGeneratedDigits = new List<string>();
            lstInputDigits.AddRange(userInput.Trim().Select(c => c.ToString()));
            lstGeneratedDigits.AddRange(generatedRandom.Trim().Select(c => c.ToString()));
            if (lstInputDigits.Count() > 0 && lstGeneratedDigits.Count() > 0)
            {
                foreach(var item in lstInputDigits)
                {
                    if (lstGeneratedDigits.Contains(item))
                    {
                        if (lstGeneratedDigits.Contains(item) && lstGeneratedDigits.IndexOf(item) != lstInputDigits.IndexOf(item))
                            result = result + "-";
                        else if (lstGeneratedDigits.Contains(item) && lstGeneratedDigits.IndexOf(item) == lstInputDigits.IndexOf(item))
                            result = result + "+";
                    }
                    else
                        return string.Empty;
                }
            }
            return result;
        }

        /// <summary>
        /// Method to Generate Random Combination
        /// </summary>
        /// <returns></returns>
        private static string GenerateRandomNumber()
        {
            Random rnd = new Random();
            int numOrg = rnd.Next(1000, 9999);
            string strNumOrg = Convert.ToString(numOrg);
            if (!string.IsNullOrEmpty(strNumOrg))
            {
                strNumOrg.Replace("7", "1");
                strNumOrg.Replace("8", "2");
                strNumOrg.Replace("9", "3");
                strNumOrg.Replace("0", "4");
                return strNumOrg.Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Method to Check User input is Digits only
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '1' || c > '6')
                    return false;
            }
            return true;
        }
    }
}
