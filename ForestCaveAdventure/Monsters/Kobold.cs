using ForestCaveAdventure.Core;
using RogueSharp.DiceNotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.Monsters
{
    public class Kobold : Monster
    {
        public static Kobold Create(int level)
        {
            int health = Dice.Roll("2D5");

            return new Kobold
            {
                Strength = 1,
                Agility = 2,
                Power = 0,
                Endurance = 2,
                Perception = 5,
                Colour = Colours.Kobold,
                AttackChance = 20,
                AttackDmg = 1,
                DefenseChance = 20,
                Defense = 1,
                CurrentHealth = 20,
                MaxHealth = 20,
                Gold = Dice.Roll("1D3"),
                Name = "Kobold",
                Symbol = 'k'
            };
        }
    }
}
