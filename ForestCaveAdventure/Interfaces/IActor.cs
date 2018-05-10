using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.Interfaces
{
    public interface IActor
    {
        int Strength { get; set; }
        int Agility { get; set; }
        int Power { get; set; }
        int Endurance { get; set; }
        int Perception { get; set; }

        int AttackChance { get; set; }
        int AttackDmg { get; set; }
        int DefenseChance { get; set; }
        int Defense { get; set; }

        int CurrentHealth { get; set; }
        int MaxHealth { get; set; }

        int Gold { get; set; }

        string Name { get; set; }
    }
}
