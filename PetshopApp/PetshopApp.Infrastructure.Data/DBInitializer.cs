using PetshopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PetshopApp.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetshopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner1 = ctx.Customers.Add(new Owner()
            {
                FirstName = "John",
                LastName = "Olesen"
            }).Entity;

            var owner2 = ctx.Customers.Add(new Owner()
            {
                FirstName = "Bill",
                LastName = "Bøllesen"
            }).Entity;

            var petType1 = ctx.PetTypes.Add(new PetType()
            {
                Id = 1,
                TypeName = "Dog"
            }).Entity;

            var petType2 = ctx.PetTypes.Add(new PetType()
            {
                TypeName = "Cat"
            }).Entity;

            var pet1 = ctx.Pets.Add(new Pet()
            {
                PetName = "AA",
                PetType = petType1,
                Owner = owner1,
                Color = "Brown"
            }).Entity;


            ctx.Pets.Add(new Pet()
            {
                Id = 2,
                Color = "White",
                Owner = owner2,
                PetName = "Obi",
                PetType = petType2
            });  




            var role1 = ctx.Roles.Add(new Role { Name = "Guest" }).Entity;
            ctx.Roles.Add(new Role { Name = "User" });
            var role3 = ctx.Roles.Add(new Role { Name = "Administrator" }).Entity;
            var role4 = ctx.Roles.Add(new Role { Name = "SuperAdministrator" }).Entity;

            ctx.Users.Add(
                new User()
                {
                    UserName = "blinko",
                    Email = "blinko@inko.dk",
                    PasswordHash = "AQAAAAEAACcQAAAAEFE8XWu6lIyinwsA4bBYJiOvabmOqZoURROPGY/eJdiNES+RGLLU7VW+/g3I+aFepA==",
                    Role = role1
                }
            );
            ctx.Users.Add(
                new User()
                {
                    UserName = "dinko",
                    Email = "dinko@inko.dk",
                    PasswordHash = "AQAAAAEAACcQAAAAENLKdwf9yrsIwY92GvwzYNVkXgdjoqWkgtt2TNlExnM+8lHORdurnPFszwiVYvJrwQ==",
                    Role = role3
                }
            );
            ctx.SaveChanges();
        }
    }
}
