using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Patterns
{
    internal class ObserverExample
    {
        public ObserverExample()
        {
            Subject subject = new Subject();
            IObserver observer = new ConcreteObserver();
            IObserver loopingObserver = new LoopingObserver();
            subject.Subscribe(observer);
            subject.Subscribe(loopingObserver);
            subject.ChangeState(1);
            Thread.Sleep(1000);
            subject.ChangeState(7);
            Thread.Sleep(1000);
            subject.ChangeState(3);
            Thread.Sleep(1000);
            subject.ChangeState(5);
        }
    }

    internal class ConcreteObserver : IObserver
    {
        private int CustomChange { get; } = 5;
        public void UpdateMe(Subject subject)
        {
            Console.WriteLine(subject.GetState() * CustomChange);
        }
    }

    internal class LoopingObserver : IObserver
    {
        public void UpdateMe(Subject subject)
        {
            ProcessNewState(subject.GetState());
        }

        private void ProcessNewState(int state)
        {
            if (state >= 5)
            {
                Console.WriteLine("High");
            }
            else
            {
                Console.WriteLine("Low");
            }
        }
    }

    internal interface IObserver
    {
        void UpdateMe(Subject subject);
    }

    internal class Subject
    {
        private int State { get; set; }

        readonly List<IObserver> listOfObservers = new List<IObserver>();
        public Subject()
        {
        }

        internal void ChangeState(int newState)
        {
            State = newState;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var item in listOfObservers)
            {
                item.UpdateMe(this);
            }
        }

        internal int GetState()
        {
            return State;
        }

        internal void Subscribe(IObserver observer)
        {
            listOfObservers.Add(observer);
        }
    }
}