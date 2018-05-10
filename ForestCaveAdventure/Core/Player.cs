using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.Core
{
    public class Player : Actor
    {
        public Player()
        {
            Strength = 3;
            Agility = 5;
            Power = 1;
            Endurance = 3;
            Perception = 15;

            AttackChance = 35;
            AttackDmg = 3;
            DefenseChance = 25;
            Defense = 1;

            CurrentHealth = 50;
            MaxHealth = 50;

            Name = "Rogue";
            Colour = Colours.Player;
            Symbol = '@';
        }

        public void DrawStats(RLConsole statConsole)
        {
            statConsole.Print(1, 1, $"Name:    {Name}", Colours.Text);
            statConsole.Print(1, 3, $"Health:  {CurrentHealth}/{MaxHealth}", Colours.Text);
            statConsole.Print(1, 5, $"Attack:  {AttackDmg} ({AttackChance}%)", Colours.Text);
            statConsole.Print(1, 7, $"Defense: {Defense} ({DefenseChance}%)", Colours.Text);
            statConsole.Print(1, 9, $"Gold:    {Gold}", Colours.Gold);
        }
    }
}
