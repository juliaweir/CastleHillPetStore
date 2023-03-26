using System;
using System.Collections.Generic;

namespace CastleHillPetStore
{
    class PetStore
       
    {
        // Properties
        private List<Pet> availablePets;
        PetLog log = new PetLog();

        // Constructor
        public PetStore()
        {
            // Initialize available pets list
            availablePets = new List<Pet>();
        }

        // Methods
        public List<Pet> ListPets()
        {
            // Return a list of all pets available in the store
            return availablePets;
        }

        public Pet AcquirePet(PetType petType, string name)
        {
            // Acquire a new pet of the specified type from the store and give it the provided name
            Pet pet = null;

            switch (petType)
            {
                case PetType.Dog:
                    pet = new Dog(name);
                    break;
                case PetType.Cat:
                    pet = new Cat(name);
                    break;
                default:
                    throw new ArgumentException($"Invalid pet type: {petType}");
            }

            // Remove the acquired pet from the available pets list
            availablePets.Remove(pet);
       
            log.SavePetLog(pet);

            // Return the acquired pet
            return pet;
        }
    }
}
