using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillPetStore
{
    class Dog : Pet
    {
        public Dog(string name) : base(name)
        {
            MaxHunger = 10;
            MaxHappiness = 10;
            HungerLevel = 2;
            HappinessLevel = 5;
            LikedFoods = new List<string>() { "Bacon Snack", "Dry dog food" };
            LikedInteractions = new List<string>() { "Rub Belly", "Play", "Scold" };
        }

        public override bool Feed(string foodType)
        {
            if (!LikedFoods.Contains(foodType))
            {
                HungerLevel += 2;
                HappinessLevel -= 2;
                return false;
            }

            if (foodType == "Bacon Snack")
            {
                HungerLevel /= 2;
                HappinessLevel++;
            }
            else if (foodType == "Dry dog food")
            {
                HungerLevel = 0;
                HappinessLevel++;
            }

            return true;
        }

        public override bool Interact(string interactionType)
        {
            if (!LikedInteractions.Contains(interactionType))
            {
                HungerLevel += 2;
                HappinessLevel -= 2;
                return false;
            }

            if (interactionType == "Rub Belly")
            {
                HungerLevel++;
                HappinessLevel++;
            }
            else if (interactionType == "Play")
            {
                HungerLevel += 3;
                HappinessLevel += 2;
            }
            else if (interactionType == "Scold")
            {
                HungerLevel += 2;
                HappinessLevel -= 2;
            }

            return true;
        }
    }
}