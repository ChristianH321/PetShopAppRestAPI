using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {

        private static List<Pet> pets = new List<Pet>();
        private static List<Customer> customers = new List<Customer>();
        private static List<Core.Entities.Type> types = new List<Core.Entities.Type>();
        static int id = 1;
        public static List<Pet> InitDataPet()
        {

            var pet1 = new Pet()
            {
                ID = id++,
                Name = "Willie",
                PreviousOwner = "Alexander",
                Price = 1000,
                SoldDate = DateTime.Now,
                BirthDate = DateTime.Parse("23.06.2012", CultureInfo.GetCultureInfo("da-DK")),
                Color = "White",

            };

            pets.Add(pet1);

            var pet2 = new Pet()
            {
                ID = id++,
                Name = "Remus",
                PreviousOwner = "Ute",
                Price = 100,
                SoldDate = DateTime.Now,
                BirthDate = DateTime.Parse("20.03.1984", CultureInfo.GetCultureInfo("da-DK")),
                Color = "Gray",
            };

            pets.Add(pet2);

            var pet3 = new Pet()
            {
                ID = id++,
                Name = "Bonny",
                PreviousOwner = "Charlotte",
                Price = 500,
                SoldDate = DateTime.Now,
                BirthDate = DateTime.Parse("20.07.1999", CultureInfo.GetCultureInfo("da-DK")),
                Color = "Blonde"
            };

            pets.Add(pet3);
            
            var pet4 = new Pet()
            {
                ID = id++,
                Name = "Chichi",
                PreviousOwner = "Nicole",
                Price = 50,
                SoldDate = DateTime.Now,
                BirthDate = DateTime.Parse("18.12.2000", CultureInfo.GetCultureInfo("da-DK")),
                Color = "Green"
            };

            pets.Add(pet4);

            var pet5 = new Pet()
            {
                ID = id++,
                Name = "Pete",
                PreviousOwner = "Friderikke",
                Price =2000,
                SoldDate = DateTime.Now,
                BirthDate = DateTime.Parse("29.05.2005", CultureInfo.GetCultureInfo("da-DK")),
                Color = "Black"
            };

            pets.Add(pet5);

            var pet6 = new Pet()
            {
                ID = id++,
                Name = "Greg",
                PreviousOwner = "Kasper",
                Price = 150,
                SoldDate = DateTime.Now,
                BirthDate = DateTime.Parse("27.06.2006", CultureInfo.GetCultureInfo("da-DK")),
                Color = "White"
            };

            pets.Add(pet6);

            return (pets);
            
        }

        public static List<Customer> InitDataCustomer()
        {
            var customer1 = new Customer()
            {
                ID = id++,
                FirstName = "Christian",
                LastName = "Hansen",
                BirthDateOfCustomer = DateTime.Parse("03.02.1983", CultureInfo.GetCultureInfo("da-DK")),
                Adress = "Gl Vardevej 78M, Esbjerg"
            };

            customers.Add(customer1);

            var customer2 = new Customer()
            {
                ID = id++,
                FirstName = "Sascha",
                LastName = "Giessman",
                BirthDateOfCustomer = DateTime.Parse("24.06.1978", CultureInfo.GetCultureInfo("da-DK")),
                Adress = "Preetzer Strasse 23a, Kiel"
            };

            customers.Add(customer2);

            var customer3 = new Customer()
            {
                ID = id++,
                FirstName = "Timo",
                LastName = "Degler",
                BirthDateOfCustomer = DateTime.Parse("05.12.1991", CultureInfo.GetCultureInfo("da-DK")),
                Adress = "Kongensgade 23, København"
            };

            customers.Add(customer3);

            var customer4 = new Customer()
            {
                ID = id++,
                FirstName = "Anders",
                LastName = "Bilgaard",
                BirthDateOfCustomer = DateTime.Parse("20.03.1965", CultureInfo.GetCultureInfo("da-DK")),
                Adress = "Ribevej 23, Ribe"
            };

            customers.Add(customer4);

            var customer5 = new Customer()
            {
                ID = id++,
                FirstName = "Kåre",
                LastName = "Relinggaard",
                BirthDateOfCustomer = DateTime.Parse("13.07.1955", CultureInfo.GetCultureInfo("da-DK")),
                Adress = "Petersvej 34, Esbjerg"
            };

            customers.Add(customer5);

            var customer6 = new Customer()
            {
                ID = id++,
                FirstName = "Jens",
                LastName = "Jeans",
                BirthDateOfCustomer = DateTime.Parse("20.04.1976", CultureInfo.GetCultureInfo("da-DK")),
                Adress = "Timovej 23, Esbjerg"
            };

            customers.Add(customer6);

            return (customers);
        }

        public static List<Core.Entities.Type> InitDataTypes()
        {

            var type1 = new Core.Entities.Type()
            {
                ID = id++,
                TypeType = "Dog"
            };

            types.Add(type1);

            var type2 = new Core.Entities.Type()
            {
                ID = id++,
                TypeType = "Cat"
            };

            types.Add(type2);

            var type3 = new Core.Entities.Type()
            {
                ID = id++,
                TypeType = "Dog"
            };

            types.Add(type3);

            var type4 = new Core.Entities.Type()
            {
                ID = id++,
                TypeType = "Bird"
            };

            types.Add(type4);

            var type5 = new Core.Entities.Type()
            {
                ID = id++,
                TypeType = "Dog"
            };

            types.Add(type5);

            var type6 = new Core.Entities.Type()
            {
                ID = id++,
                TypeType = "Cat"
            };

            types.Add(type6);

            return types;
        }

        public static int getID()
        {
            return id;
        }
    }
}
