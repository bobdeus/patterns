using System;

namespace Patterns
{
    internal class StateExample
    {
        public StateExample()
        {
            RunGame();
        }

        private void RunGame()
        {
            var currentKeyPressed = "";
            var previousKeyPressed = "";
            var timeBeforeThatPressed = "";
            var times = 1;
            while (true)
            {
                currentKeyPressed = GetKey();
                if (CheckCombo(currentKeyPressed, previousKeyPressed, timeBeforeThatPressed))
                {
                    Console.WriteLine("You Win!");
                    return;
                }
                previousKeyPressed = currentKeyPressed;
                if (times++ == 1)
                {
                    timeBeforeThatPressed = previousKeyPressed;
                }

                //Reset the check
                if (times == 3) times = 1;
            }
        }

        //LeftArrow, RightArrow, A
        private static bool CheckCombo(string currKeyPressed, string previousKeyPressed, string timeBeforeThatPressed)
        {
            if (timeBeforeThatPressed.Equals("LeftArrow") && previousKeyPressed.Equals("RightArrow") && currKeyPressed.Equals("A"))
            {
                return true;
            }
            else if(timeBeforeThatPressed.Equals("LeftArrow") && previousKeyPressed.Equals("RightArrow") && currKeyPressed.Equals("A") && currKeyPressed.Equals("B"))
            {
                return true;
            }

            return false;
        }

        private static string GetKey()
        {
            var keyPressed = Console.ReadKey().Key.ToString();
            Console.Clear();
            Console.WriteLine($"You pressed the {keyPressed} key.");
            return keyPressed;
        }
    }
}