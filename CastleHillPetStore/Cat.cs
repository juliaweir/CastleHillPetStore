using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillPetStore
{
    public class Cat : Pet
    {
        public Cat(string name) : base(name)
        {
            MaxHunger = 8;
            MaxHappiness = 5;
            HungerLevel = 2;
            HappinessLevel = 4;
            LikedFoods = new List<string> { "Tuna", "Dry Cat Food" };
            LikedInteractions = new List<string> { "Pet", "Ignore", "Scold" };
        }

        public override bool Feed(string foodType)
        {
            bool liked = false;
            if (LikedFoods.Contains(foodType))
            {
                if (foodType == "Tuna")
                {
                    HungerLevel = 0;
                    HappinessLevel += 3;
                }
                else if (foodType == "Dry Cat Food")
                {
                    HungerLevel /= 2;
                    HappinessLevel++;
                }
                liked = true;
            }
            else
            {
                HungerLevel += 2;
                HappinessLevel -= 2;
            }
            return liked;
        }

        public override bool Interact(string interactionType)
        {
            bool liked = false;
            if (LikedInteractions.Contains(interactionType))
            {
                if (interactionType == "Pet")
                {
                    HungerLevel++;
                    HappinessLevel++;
                    int random = new Random().Next(0, 2);
                    if (random == 0)
                    {
                        liked = false;
                        HungerLevel++;
                        HappinessLevel -= 2;
                    }
                    else
                    {
                        liked = true;
                    }
                }
                else if (interactionType == "Ignore")
                {
                    HungerLevel++;
                    HappinessLevel += 2;
                    liked = true;
                }
                else if (interactionType == "Scold")
                {
                    HungerLevel += 2;
                    HappinessLevel -= 2;
                    liked = true;
                }
            }
            else
            {
                HungerLevel += 2;
                HappinessLevel -= 2;
            }
            return liked;

        }
    }
}
    