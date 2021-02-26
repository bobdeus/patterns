using System;
using System.Collections.Generic;

namespace Examples
{
    internal class BuilderExample
    {
        public void Run()
        {
            var defaultPizza = Pizza.BuildWithDefaults();

            var emptyPizza = Pizza.GetEmptyPizzaToBuild();

            var pizzaWithEverything = Pizza.GetEmptyPizzaToBuild()
                .WithDough(new DeepDish())
                .WithToppings(new List<Topping> {new Cheese(), new Pepperoni()})
                .WithSauces(new List<Sauce> {new Marinara(), new Alfredo()})
                .Build();

            defaultPizza.ToConsole();
            emptyPizza.ToConsole();
            pizzaWithEverything.ToConsole();
        }
    }

    public class Pizza
    {
        private List<Sauce> _sauces = new List<Sauce>();
        private List<Topping> _toppings = new List<Topping>();

        private Pizza()
        {
        }

        public Dough Dough { get; private set; }
        public IEnumerable<Topping> Toppings => _toppings.AsReadOnly();
        public IEnumerable<Sauce> Sauces => _sauces.AsReadOnly();

        public Pizza Build()
        {
            return this;
        }

        public static Pizza BuildWithDefaults()
        {
            var pizza = new Pizza
            {
                Dough = new DeepDish(),
                _toppings = new List<Topping>
                {
                    new Cheese()
                },
                _sauces = new List<Sauce>
                {
                    new Marinara()
                }
            };
            return pizza;
        }

        public static Pizza GetEmptyPizzaToBuild()
        {
            return new Pizza();
        }

        public Pizza WithDough(Dough dough)
        {
            Dough = dough;
            return this;
        }

        public Pizza WithToppings(List<Topping> toppings)
        {
            _toppings = new List<Topping>(toppings);
            return this;
        }

        public Pizza WithSauces(List<Sauce> sauces)
        {
            _sauces = sauces;
            return this;
        }
    }

    public class Topping
    {
    }

    internal class Marinara : Sauce
    {
    }

    internal class Alfredo : Sauce
    {
    }

    internal class Pepperoni : Topping
    {
    }

    internal class Cheese : Topping
    {
    }

    public class Sauce
    {
    }

    internal class DeepDish : Dough
    {
    }

    public class Dough
    {
    }
    
    public static class PizzaExtensions
    {
        public static void ToConsole(this Pizza pizza)
        {
            if (pizza == null) return;
            Console.WriteLine("The Pizza created has:");
            var doughName = pizza.Dough != null ? pizza.Dough.GetType().Name : string.Empty;
            Console.WriteLine($"Dough: {doughName}");
            
            var toppings = "Toppings: ";
            foreach (var pizzaTopping in pizza.Toppings)
            {
                toppings += pizzaTopping.GetType().Name + " ";
            }
            Console.WriteLine(toppings);

            var sauces = "Sauces: ";
            foreach (var sauce in pizza.Sauces)
            {
                sauces += sauce.GetType().Name + " ";
            }
            Console.WriteLine(sauces);
            Console.WriteLine("=================================");
        }
    }
}