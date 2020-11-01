using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyLittlestPetShop.Core.Entity
{
    //public enum PetType
    //{
    //    KomodoDragon,
    //    Sunfish,
    //    Earthworm,
    //    Alpaca,
    //    Bear,
    //    Apple,
    //    Mosquito,
    //    Dog,
    //    Cat
    //}

    public class Pet
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public DateTime Birthdate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public Owner Owner { get; set; }
    }
}
