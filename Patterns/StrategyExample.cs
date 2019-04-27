using System;
using System.Collections.Generic;
using System.Threading;

namespace Patterns
{
    internal class StrategyExample
    {
        public StrategyExample()
        {
            var king = new King();
            var queen = new Queen();
            var squire = new Squire();
            var troll = new Troll();

            var club = new Club();
            var knife = new Knife();
            var sword = new Sword();
            var unarmed = new Unarmed();

            List<Weapon> weapons = new List<Weapon>()
            {
                club,
                knife,
                sword,
                unarmed
            };

            List<Character> characters = new List<Character>
            {
                king,
                queen,
                squire
            };

            Fight(characters, weapons, troll);
        }

        internal void Fight(List<Character> characters, List<Weapon> weapons, Character attacked)
        {
            for (int i = 0; i < 100; i++)
            {
                foreach (var character in characters)
                {
                    character.Weapon = weapons[new Random().Next(0, 4)];
                    Thread.Sleep(10);
                }

                foreach (var character in characters)
                {
                    Console.Write($"{character.GetType().Name} ");
                    character.Weapon.UseWeapon(attacked);
                    Console.WriteLine($" and the health of the {attacked.GetType().Name} is now: {attacked.Health}");
                    if (attacked.Health <= 0)
                    {
                        Console.WriteLine($"The {attacked.GetType().Name} has been killed!");
                        return;
                    }
                }
            }
        }
    }

    internal abstract class Weapon
    {
        internal abstract void UseWeapon(Character targetCharacter);
    }

    internal class Unarmed : Weapon
    {
        private readonly int damage = 1;

        internal Unarmed()
        {
        }

        internal override void UseWeapon(Character targetCharacter)
        {
            targetCharacter.TakeDamage(damage);
            Console.Write("used an unarmed attack");
        }
    }

    internal class Sword : Weapon
    {
        private readonly int damage = 9;

        internal Sword()
        {
        }

        internal override void UseWeapon(Character targetCharacter)
        {
            targetCharacter.TakeDamage(damage);
            Console.Write("used a sword");
        }
    }

    internal class Knife : Weapon
    {
        private readonly int damage = 4;

        public Knife()
        {
        }

        internal override void UseWeapon(Character targetCharacter)
        {
            targetCharacter.TakeDamage(damage);
            Console.Write("used a knife");
        }
    }

    internal class Club : Weapon
    {
        private readonly int damage = 6;
        public Club()
        {
        }

        internal override void UseWeapon(Character targetCharacter)
        {
            targetCharacter.TakeDamage(damage);
            Console.Write("used a club");
        }
    }

    internal abstract class Character
    {
        internal Weapon Weapon { get; set; }
        internal int Health { get; set; } = 100;
        internal void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }

    internal class King : Character
    {
        public King()
        {
        }
    }

    internal class Queen : Character
    {
        public Queen()
        {
        }
    }

    internal class Troll : Character
    {
        public Troll()
        {
        }
    }

    internal class Squire : Character
    {
        public Squire()
        {
        }
    }
}