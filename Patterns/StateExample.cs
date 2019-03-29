using System;

namespace Patterns
{
    internal class StateExample
    {
        internal ICaseState State { get; set; }
        public StateExample()
        {
            Console.WriteLine("State Pattern Example");
            string testString = "What's my case?";

            State = new LowerState();
            Console.WriteLine(State.GetCase(testString));
            State = State.Switch();
            Console.WriteLine(State.GetCase(testString));
            State = State.Switch();
            Console.WriteLine(State.GetCase(testString));
            State = State.Switch();
            Console.WriteLine(State.GetCase(testString));
        }

        public interface ICaseState
        {
            ICaseState Switch();
            string GetCase(string properCase);
        }

        private class LowerState : ICaseState
        {
            public ICaseState Switch()
            {
                return new UpperState();
            }

            public string GetCase(string properCase)
            {
                return properCase.ToLower();
            }
        }

        private class UpperState : ICaseState
        {
            public ICaseState Switch()
            {
                return new MixedState();
            }

            public string GetCase(string properCase)
            {
                return properCase.ToUpper();
            }
        }

        private class MixedState : ICaseState
        {
            public ICaseState Switch()
            {
                return new LowerState();
            }

            public string GetCase(string properCase)
            {
                string newCaseReturn = "";
                for (int i = 0; i < properCase.Length; i++)
                {
                    if (i % 2 == 0)
                        newCaseReturn += properCase[i].ToString().ToLower();
                    else
                        newCaseReturn += properCase[i].ToString().ToUpper();
                }
                return newCaseReturn;
            }
        }
    }
}