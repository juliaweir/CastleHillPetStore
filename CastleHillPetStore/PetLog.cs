using System;
using System.IO;

namespace CastleHillPetStore
{
    public class PetLog
    {
        public void UpdateLog(Pet pet, string interaction)
        {
            switch (interaction)
            {
                case "1":
                    pet.HappinessLevel += 2;
                    pet.HungerLevel += 1;
                    Console.WriteLine(pet.Name + " enjoyed being petted!");
                    break;
                case "2":
                    pet.HappinessLevel += 3;
                    pet.HungerLevel += 1;
                    Console.WriteLine(pet.Name + " enjoyed having its belly rubbed!");
                    break;
                case "3":
                    pet.HappinessLevel += 4;
                    pet.HungerLevel += 2;
                    Console.WriteLine(pet.Name + " had fun playing!");
                    break;
                case "4":
                    pet.HappinessLevel -= 1;
                    pet.HungerLevel += 1;
                    Console.WriteLine(pet.Name + " feels ignored.");
                    break;
                case "5":
                    pet.HappinessLevel -= 3;
                    pet.HungerLevel += 2;
                    Console.WriteLine(pet.Name + " has been scolded.");
                    break;
                default:
                    Console.WriteLine("Invalid interaction.");
                    break;
            }

            // Set the last interacted time to now
            pet.lastInteracted = DateTime.Now;
        }

        public void SavePetLog(Pet pet)
        {
            string fileName = $"{pet.Name}_log.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Name: {pet.Name}");
                writer.WriteLine($"Hunger Level: {pet.HungerLevel}");
                writer.WriteLine($"Happiness Level: {pet.HappinessLevel}");
                writer.WriteLine($"Last Interacted: {pet.lastInteracted.ToString()}");
                writer.WriteLine($"Last Fed: {pet.lastFed.ToString()}");
                writer.WriteLine();
            }
        }
    }
}
