using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleHillPetStore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pet> pets = new List<Pet>();
            PetLog log = new PetLog();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Pet Store!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. List pets in the store");
                Console.WriteLine("2. Acquire pets from the store");
                Console.WriteLine("3. Remove pets from your collection");
                Console.WriteLine("4. Feed your pets");
                Console.WriteLine("5. Interact with your pets");
                Console.WriteLine("6. View current state of your pets");
                Console.WriteLine("0. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("The store currently has the following pets:");
                        Console.WriteLine("Dog");
                        Console.WriteLine("Cat");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Which pet would you like to acquire? (enter 'dog' or 'cat')");
                        string petType = Console.ReadLine().ToLower();
                        if (petType == "dog")
                        {
                            Console.WriteLine("What would you like to name your dog?");
                            string name = Console.ReadLine();
                            pets.Add(new Dog(name));
                            Console.WriteLine("Congratulations, you now own a dog named " + name + "!");
                        }
                        else if (petType == "cat")
                        {
                            Console.WriteLine("What would you like to name your cat?");
                            string name = Console.ReadLine();
                            pets.Add(new Cat(name));
                            Console.WriteLine("Congratulations, you now own a cat named " + name + "!");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, we do not carry that type of pet.");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Which pet would you like to remove? (enter name)");
                        string petName = Console.ReadLine();
                        bool removed = false;
                        for (int i = 0; i < pets.Count; i++)
                        {
                            if (pets[i].Name == petName)
                            {
                                pets.RemoveAt(i);
                                Console.WriteLine(petName + " has been removed from your collection.");
                                removed = true;
                                break;
                            }
                        }
                        if (!removed)
                        {
                            Console.WriteLine("You do not own a pet named " + petName + ".");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("What would you like to feed your pets? (enter 'bacon snack', 'dry dog food', 'tuna', or 'dry cat food')");
                        string foodType = Console.ReadLine().ToLower();
                        bool validFood = false;
                        foreach (Pet pet in pets)
                        {
                            bool liked = pet.Feed(foodType);
                            if (liked)
                            {
                                validFood = true;
                            }
                        }
                        if (validFood)
                        {
                            Console.WriteLine("Your pets enjoyed the " + foodType + "!");
                        }
                        else
                        {
                            Console.WriteLine("Your pets did not like the " + foodType + ".");
                            foreach (Pet pet in pets)
                            {
                                pet.HappinessLevel -= 2;
                                pet.HungerLevel += 2;
                            }
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Which pet would you like to interact with? (enter name)");
                        string petName1 = Console.ReadLine();
                        bool foundPet = false;
                        foreach (Pet pet in pets)
                        {
                            if (pet.Name == petName1)
                            {
                                foundPet = true;
                                Console.WriteLine("What would you like to do with " + petName1 + "?");
                                Console.WriteLine("1. Pet");
                                Console.WriteLine("2. Rub Belly");
                                Console.WriteLine("3. Play");
                                Console.WriteLine("4. Ignore");
                                Console.WriteLine("5. Scold");
                                string interaction = Console.ReadLine();

                                // Update the pet's hunger and happiness levels based on the interaction
                                log.UpdateLog(pet, interaction);

                                // Save the updated pet log to file
                                log.SavePetLog(pet);

                                break;
                            }
                        }
                        if (!foundPet)
                        {
                            Console.WriteLine("You do not own a pet named " + petName1 + ".");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Current state of your pets:");
                        foreach (Pet pet in pets)
                        {
                            Console.WriteLine(pet.Name + " the " + pet.GetType().Name);
                            Console.WriteLine("Hunger: " + pet.HungerLevel + "/" + pet.MaxHunger);
                            Console.WriteLine("Happiness: " + pet.HappinessLevel + "/" + pet.MaxHappiness);
                            Console.WriteLine("-----------------------------");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
