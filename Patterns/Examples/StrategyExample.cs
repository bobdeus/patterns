using System;
using System.Collections.Generic;
using System.Threading;

namespace Patterns
{
    internal class StrategyExample
    {
        private readonly Dictionary<int, Character> characterMapping = new Dictionary<int, Character>();
        public StrategyExample()
        {
            var king = new King();
            var queen = new Queen();
            var squire = new Squire();
            var troll = new Troll();

            characterMapping.Add(0, king);
            characterMapping.Add(1, queen);
            characterMapping.Add(2, squire);

            var club = new Club();
            var knife = new Knife();
            var sword = new Sword();
            var unarmed = new Unarmed();
            var healingStaff = new HealingStaff();

            List<Weapon> weapons = new List<Weapon>()
            {
                club,
                knife,
                sword,
                unarmed,
                healingStaff
            };

            Fight(CreateRandomCharacters(), weapons, troll);
        }

        internal void Fight(List<Character> characters, List<Weapon> weapons, Character targetCharacter)
        {
            while (targetCharacter.Health > 0)
            {
                foreach (Character character in characters)
                {
                    EquipRandomWeapon(character, weapons);
                    character.UseWeapon(targetCharacter);
                    Console.WriteLine($"{character.GetType().Name} used a {character.Weapon.GetType().Name} on {targetCharacter.GetType().Name} and its health is: {targetCharacter.Health}");
                    if (targetCharacter.Health <= 0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"The {targetCharacter.GetType().Name} is now dead!");
        }

        private static void EquipRandomWeapon(Character character, List<Weapon> weapons)
        {
            Thread.Sleep(10);
            character.Weapon = weapons[new Random().Next(0, weapons.Count)];
        }

        private List<Character> CreateRandomCharacters()
        {
            List<Character> characters = new List<Character>();
            int lastUsedCharacterIndex = 0;
            while (characters.Count < characterMapping.Values.Count)
            {
                if (characters.Contains(characterMapping[lastUsedCharacterIndex]))
                {
                    lastUsedCharacterIndex = new Random().Next(0, 3);
                }
                else
                {
                    characters.Add(characterMapping[lastUsedCharacterIndex]);
                }
            }
            return characters;
        }
    }

    internal abstract class Weapon
    {
        internal int Damage { get; set; }
    }

    internal class Unarmed : Weapon
    {
        private readonly int damage = 1;

        internal Unarmed()
        {
            Damage = damage;
        }
    }
    internal class HealingStaff : Weapon
    {
        private readonly int damage = -10;

        internal HealingStaff()
        {
            Damage = damage;
        }
    }

    internal class Sword : Weapon
    {
        private readonly int damage = 9;

        internal Sword()
        {
            Damage = damage;
        }
    }

    internal class Knife : Weapon
    {
        private readonly int damage = 4;

        internal Knife()
        {
            Damage = damage;
        }
    }

    internal class Club : Weapon
    {
        private readonly int damage = 6;
        internal Club()
        {
            Damage = damage;
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
        internal void UseWeapon(Character targetCharacter)
        {
            targetCharacter.TakeDamage(Weapon.Damage);
        }
    }

    internal class King : Character
    {
        internal King()
        {
        }
    }

    internal class Queen : Character
    {
        internal Queen()
        {
        }
    }

    internal class Troll : Character
    {
        internal Troll()
        {
        }
    }

    internal class Squire : Character
    {
        internal Squire()
        {
        }
    }
}