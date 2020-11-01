using MyLittlestPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittlestPetshop.Infrastructure.SQL.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetshopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var sunfish = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "SunFish"

            }).Entity;

            var earthworm = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "Earthworm"

            }).Entity;

            var alpaca = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "Alpaca"

            }).Entity;

            var komododragon = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "KomodoDragon"

            }).Entity;

            var bear = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "Bear"

            }).Entity;

            var apple = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "Apple"

            }).Entity;

            var mosquito = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "Mosquito"

            }).Entity;

            var owner1 = ctx.Owners.Add(new Owner()
            {
                Address = "Somewhere",
                FirstName = "Daddy",
                LastName = "Cool"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                Address = "That Place",
                FirstName = "Momma",
                LastName = "Cool"
            }).Entity;

            var owner3 = ctx.Owners.Add(new Owner()
            {
                Address = "The Void",
                FirstName = "Kevin",
                LastName = "McBiggy"
            }).Entity;

            Pet pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Clyde",
                Description = "Got him a while back now under strange circumstance. A truck with a big fish tank was left by the shop, so we took him in.\n" +
                              "He's an odd one, doesn't say much, a 1000 mile stare but has a heart of gold! Barks a lot too but luckily it isn't too loud underwater.",
                PetType = sunfish,
                Birthdate = DateTime.Now.AddYears(-5),
                Color = "Blueish Grey",
                Price = 45000,
                Owner = owner1
            }).Entity;

            Pet pet2 = ctx.Pets.Add(new Pet()
            {
                Name = "Jim",
                Description = "Jim is a cool little worm, we really like him here in the shop. He isn't like most other worms. \n" +
                              "He's special. Has a robotic suit and occasionally fights evil. Price is without his blaster.",
                PetType = earthworm,
                Birthdate = DateTime.Now.AddYears(-26),
                Color = "Pink",
                Price = 50,
                Owner = owner1
            }).Entity;

            Pet pet3 = ctx.Pets.Add(new Pet()
            {
                Name = "Chubs",
                Description = "Good ol' Chubs here is generally a peaceful fella. Far from what I ever expected a dragon to be but I ain't one to judge.\n" +
                              "Word of advice? He's fast, so if he's running towards you, just yell '停止胖男孩!' and he should stop",
                PetType = komododragon,
                Birthdate = DateTime.Now.AddYears(-2),
                Color = "Dark Green/Grey",
                Price = 55000,
                Owner = owner2
            }).Entity;

            Pet pet4 = ctx.Pets.Add(new Pet()
            {
                Name = "Tina",
                Description = "Tina is very ravenous and cranky woman. She eats basically anything you feed her. Previous owner was a weird guy.\n" +
                              "He had some wild dance moves tho and I believe he referred to Tina as 'Fat Lard'. Kinda mean but I totally get it.",
                PetType = alpaca,
                Birthdate = DateTime.Now.AddYears(-7),
                Color = "Dark Brown",
                Price = 15000,
                Owner = owner2
            }).Entity;

            Pet pet5 = ctx.Pets.Add(new Pet()
            {
                Name = "Paddington",
                Description = "Aaah Paddington, what a lovely little guy. He's a very curious and kind one, especially for a bear.\n" +
                              "Make sure he has his jacket and hat before heading outside. Also don't worry about the prison thing, he was wrongly convicted.. I think.",
                PetType = bear,
                Birthdate = DateTime.Now.AddYears(-3),
                Color = "Brown",
                Price = 25000,
                Owner = owner2
            }).Entity;

            Pet pet6 = ctx.Pets.Add(new Pet()
            {
                Name = "Apple",
                Description = "It's an Apple from the tree in my backyard",
                PetType = apple,
                Birthdate = DateTime.Now.AddDays(-4),
                Color = "Red",
                Owner = owner3,
                Price = 5
            }).Entity;

            Pet pet7 = ctx.Pets.Add(new Pet()
            {
                Name = "Bear Grylls",
                Description = "I've seen a few bears in my time and this one sure is the weirdest. Ever since we got it, it's been trying to escape.\n" +
                              "It keeps saying it will 'call the police' and 'let me out'. It's a bear, how is it even supposed to use a phone? Hahaha",
                PetType = bear,
                Birthdate = DateTime.Now.AddYears(-46),
                Color = "Caucasian",
                Owner = owner3,
                Price = 12500
            }).Entity;

            Pet pet8 = ctx.Pets.Add(new Pet()
            {
                Name = "Legion",
                Description = "A jar of earthworms.. That's pretty much it. Prefers to be called 'Legion' for 'they are many' or something like that.\n" +
                              "Can speak telepathically. Has interesting plans regarding world domination. Likes listening to Pink Floyd.",
                PetType = earthworm,
                Birthdate = DateTime.Now.AddYears(-1),
                Color = "Brown/Pink",
                Owner = owner3,
                Price = 55
            }).Entity;

            Pet pet9 = ctx.Pets.Add(new Pet()
            {
                Name = "Smaug",
                Description = "Not the friendliest lizard I've encountered but good with finances. Has a small fortune at this point (not included).\n" +
                              "Has a large disdain for small people, Hobbits and Dwarfs alike. Prefers mountains as his main habitat.",
                PetType = komododragon,
                Birthdate = DateTime.Now.AddYears(-83),
                Color = "Red/Golden",
                Owner = owner3,
                Price = 750000
            }).Entity;

            Pet pet10 = ctx.Pets.Add(new Pet()
            {
                Name = "Egon",
                Description = "It was one helluva tough time to catch this one. Not only is he a tiny bug, he's also riding around on a bicycle of all things.",
                PetType = mosquito,
                Birthdate = DateTime.Now.AddDays(-2),
                Color = "Black with Yellow T-Shirt",
                Owner = owner3,
                Price = 15
            }).Entity;

            var user1 = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Username = "user",
            }).Entity;
            ctx.SaveChanges();
        }
    }
}
