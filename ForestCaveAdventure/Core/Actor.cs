using ForestCaveAdventure.Interfaces;
using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.Core
{
    public class Actor : IActor, IDrawable
    {
        private int _Strength;
        private int _Agility;
        private int _Power;
        private int _Endurance;
        private int _Perception;
        private int _AttackChance;
        private int _AttackDmg;
        private int _DefenseChance;
        private int _Defense;
        private int _CurrentHealth;
        private int _MaxHealth;
        private int _Gold;
        private string _Name;

        public int Strength
        {
            get => _Strength;
            set => _Strength = value;
        }

        public int Agility
        {
            get => _Agility;
            set => _Agility = value;
        }

        public int Power
        {
            get => _Power;
            set => _Power = value;
        }

        public int Endurance
        {
            get => _Endurance;
            set => _Endurance = value;
        }

        public int Perception
        {
            get => _Perception;
            set => _Perception = value;
        }

        public int AttackChance
        {
            get => _AttackChance;
            set => _AttackChance = value;
        }

        public int AttackDmg
        {
            get => _AttackDmg;
            set => _AttackDmg = value;
        }

        public int DefenseChance
        {
            get => _DefenseChance;
            set => _DefenseChance = value;
        }

        public int Defense
        {
            get => _Defense;
            set => _Defense = value;
        }

        public int CurrentHealth
        {
            get => _CurrentHealth;
            set => _CurrentHealth = value;
        }

        public int MaxHealth
        {
            get => _MaxHealth;
            set => _MaxHealth = value;
        }

        public int Gold
        {
            get => _Gold;
            set => _Gold = value;
        }

        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        public RLColor Colour { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(RLConsole console, IMap map)
        {
            // Dont draw in cells that arent explored
            if (!map.GetCell(X,Y).IsExplored)
            {
                return;
            }

            // Only draw with the colour and symbole when they are in FOV
            if (map.IsInFov(X,Y))
            {
                console.Set(X, Y, Colour, Colours.FloorBackgroundFOV, Symbol);
            }
            else
            {
                // When not in FOV jsut draw a normal floor
                console.Set(X, Y, Colours.Floor, Colours.FloorBackground, '.');
            }
        }
    }
}
