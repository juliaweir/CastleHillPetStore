using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillPetStore
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public int HungerLevel { get; set; }
        public int HappinessLevel { get; set; }
        public int MaxHunger { get; set; }
        public int MaxHappiness { get; set; }
        public int TimeToHunger { get; }
        public int TimeToUnhappiness { get; }
        public List<string> LikedFoods { get; set; }
        public List<string> LikedInteractions { get; set; }
        public DateTime lastInteracted { get; set; }
        public DateTime lastFed { get; set; }
        private DateTime lastUpdateTime;

        public Pet(string name, int maxHunger, int maxHappiness, int timeToHunger,
            DateTime lastInteracted, DateTime lastFed, int timeToUnhappiness, List<string> likedFoods, List<string> likedInteractions)
        {
            Name = name;
            HungerLevel = maxHunger / 2; // Set initial hunger level to half of max
            HappinessLevel = maxHappiness / 2; // Set initial happiness level to half of max
            MaxHunger = maxHunger;
            MaxHappiness = maxHappiness;
            TimeToHunger = timeToHunger;
            TimeToUnhappiness = timeToUnhappiness;
            LikedFoods = likedFoods;
            LikedInteractions = likedInteractions;
            lastUpdateTime = DateTime.Now; 

        }

        protected Pet(string name)
        {
            Name = name;
        }

        public virtual bool Feed(string foodType)
        {
            bool likedFood = LikedFoods.Contains(foodType);
            if (likedFood)
            {
                HungerLevel = Math.Max(0, HungerLevel - MaxHunger / 2); // Halves hunger if food is liked
                HappinessLevel = Math.Min(MaxHappiness, HappinessLevel + 1);
            }
            else
            {
                HungerLevel = Math.Min(MaxHunger, HungerLevel + 2); // Increases hunger by 2 if food is not liked
                HappinessLevel = Math.Max(0, HappinessLevel - 2);
            }
            return likedFood;
        }

        public virtual bool Interact(string interactionType)
        {
            bool likedInteraction = LikedInteractions.Contains(interactionType);
            if (likedInteraction)
            {
                HungerLevel = Math.Min(MaxHunger, HungerLevel + 1);
                HappinessLevel = Math.Min(MaxHappiness, HappinessLevel + 2);
            }
            else
            {
                HungerLevel = Math.Min(MaxHunger, HungerLevel + 2);
                HappinessLevel = Math.Max(0, HappinessLevel - 2);
            }
            return likedInteraction;
        }

        public void UpdateState()
        {
            TimeSpan timeSinceLastUpdate = DateTime.Now - lastUpdateTime;
            int secondsSinceLastUpdate = (int)timeSinceLastUpdate.TotalSeconds;
            int hungerIncrease = secondsSinceLastUpdate / TimeToHunger;
            int happinessDecrease = secondsSinceLastUpdate / TimeToUnhappiness;

            HungerLevel = Math.Min(MaxHunger, HungerLevel + hungerIncrease);
            HappinessLevel = Math.Max(0, HappinessLevel - happinessDecrease);

            lastUpdateTime = DateTime.Now;
        }
    }
}