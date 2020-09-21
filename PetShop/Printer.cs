using PetShop.Core;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace PetShop
{
    #region Comments

    /* -- UI --
        Console.WriteLine
        Console.ReadLine
        dkd
    */
    // -- Infrastructure --
    // EF - Static List - Text File

    // -- Test --
    // Unit test for Core

    /* -- CORE --
        Customer - Entity - Core.Entity
        Domain Service - Repository / UOW - Core
        Application Service - Service - Core
    */

    #endregion


    public class Printer : IPrinter
    {
        #region Service area

        readonly PetService _petService;
        readonly CustomerService _customerService;
        readonly TypeService _typeService;

        #endregion

        public Printer(IPetService petService, ICustomerService customerService, ITypeService typeService)
        {
            _petService = (PetService)petService;
            _petService.InitDatabaseData();
            _customerService = (CustomerService)customerService;
            _customerService.InitDatabaseDataCustomer();
            _typeService = (TypeService)typeService;
            _typeService.InitDatabaseDataType();
        }
        #region UI

        public void StartUI()
        {
            string[] menuItems =
            {
                "List all pets",
                "Add pet",
                "Delete pet",
                "Edit pet",
                "Search by type",
                "Sort pets by price",
                "Get 5 cheapest pets",
                "Create Customer",
                "Delete Customer",
                "Edit Customer",
                "List all Customer",
                "Create Type",
                "Delete Type",
                "Edit Type",
                "List all Types",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 16)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetPets();
                        ListPets(pets);
                        break;

                    case 2:
                        var name = AskQuestion("What is the name of the pet? ");
                        var type = AskQuestion("What is the type of the pet? ");
                        var previousOwner = AskQuestion("Who was the previous owner of the pet? ");
                        var price = AskQuestion("What is the price of the pet? ");
                        var soldDate = AskQuestion("When was the pet sold? ");
                        var birthDate = AskQuestion("When was the pet born? ");
                        var color = AskQuestion("What is the color of the pet? ");

                        var pet = _petService.NewPet(name, previousOwner, Convert.ToDouble(price), Convert.ToDateTime(soldDate), Convert.ToDateTime(birthDate), color);
                        _petService.CreatePet(pet);
                        break;

                    case 3:
                        var idForDeletePet = PrintFindPetId();
                        _petService.DeletePet(idForDeletePet);
                        break;

                    case 4:
                        var idForEdit = PrintFindPetId();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("What is the new name of pet? ");
                        var newPreviousOwner = AskQuestion("Who was the previous Owner? ");
                        var newPrice = AskQuestion("What is the new price of the pet? ");
                        var newSoldDate = AskQuestion("When was it sold?");
                        var newBirthDate = AskQuestion("When was it born?");
                        var newColor = AskQuestion("What is the color of the pet?");
                        _petService.UpdatePet(new Pet()
                        {
                            ID = idForEdit,
                            Name = newName,
                            PreviousOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice),
                            SoldDate = Convert.ToDateTime(newBirthDate),
                            BirthDate = Convert.ToDateTime(newBirthDate),
                            Color = newColor

                        });
                        break;

                    case 5:
                        var chosenType = AskQuestion("Insert type: ");
                        var specifiedTypes = _typeService.getAllByType(chosenType);
                        if (specifiedTypes != null)
                        {
                            ListTypes(specifiedTypes);
                        }
                        else
                        {
                            Console.WriteLine("No such type");
                        }
                        break;

                    case 6:
                        var choice = AskQuestion("ASC or DESC: ");
                        if (choice.Contains("ASC"))
                        {
                            ListPets(_petService.getASC());
                        }
                        else
                        {
                            ListPets(_petService.getDESC());
                        }
                        break;
                    case 7:
                        ListPets(_petService.getCheapest());
                        break;
                    case 8:
                        var firstName = AskQuestion("What is the first name of the customer? ");
                        var lastName = AskQuestion("What is the last name of the customer? ");
                        var birthDateOfCustomer = AskQuestion("What is the birthdate of the customer? ");
                        var adress = AskQuestion("What is the adress of the customer? ");
                        var newbirth = Convert.ToDateTime(birthDateOfCustomer);
                        var customer = _customerService.NewCustomer(firstName, lastName, newbirth, adress);
                        _customerService.CreateCustomer(customer);
                        break;

                    case 9:
                        var idForDeleteCustomer = PrintFindCustomerId();
                        _customerService.DeleteCustomer(idForDeleteCustomer);
                        break;

                    case 10:

                        var idForEditCustomer = PrintFindCustomerId();
                        var customerToEdit = _customerService.FindCustomerById(idForEditCustomer);
                        Console.WriteLine("Updating " + customerToEdit.FirstName + customerToEdit.LastName);
                        var newFirstName = AskQuestion("What is the new first name of customer? ");
                        var newLastName = AskQuestion("What is the new last name of customer?");
                        var newBirthDateOfCustomer = AskQuestion("What is the new birthdate of customer? ");
                        var newAdress = AskQuestion("What is the adress of the customer?");
                        _customerService.UpdateCustomer(new Customer()
                        {
                            ID = idForEditCustomer,
                            FirstName = newFirstName,
                            LastName = newLastName,
                            BirthDateOfCustomer = Convert.ToDateTime(newBirthDateOfCustomer),
                            Adress = newAdress,

                        });
                        break;

                    case 11:
                        var customers = _customerService.GetCustomer();
                        ListCustomers(customers);
                        break;

                    case 12:
                        var typetype = AskQuestion("What is the kind of pet? ");
                     
                        var TypeType = _typeService.NewType(typetype);
                        _typeService.CreateType(TypeType);

                        break;

                    case 13:

                        var idForDeleteType = PrintFindTypeId();
                        _typeService.DeleteType(idForDeleteType);
                        break;

                    case 14:

                        var idForEditType = PrintFindTypeId();
                        var typeToEdit = _typeService.FindTypeById(idForEditType);
                        Console.WriteLine("Updating " + typeToEdit);
                        var newType = AskQuestion("What is the new name of the type of pet? ");
                        
                        _typeService.UpdateType(new Core.Entities.Type()
                        {
                            ID = idForEditType,
                            TypeType = newType,
                            
                        });
                        break;

                    case 15:
                        var types = _typeService.GetTypes();
                        ListTypes(types);
                        break;

                    case 16:
                    default:
                        break;

                }

                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Have a blessed day. Bye and See you!");
            Console.ReadLine();
        }

        private void ListCustomers(List<Customer> customers)
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.ID} FirstName: {customer.FirstName} LastName: {customer.LastName} " +
                    $" Birth Date: {customer.BirthDateOfCustomer} " +
                    $" Adress: {customer.Adress} "
                    );

            }

            Console.WriteLine("\n");
        }

        private void ListTypes(List<Core.Entities.Type> TypeTypes)
        {
            Console.WriteLine("\nList of Kinds");
            foreach (var typetype in TypeTypes)
            {
                Console.WriteLine($"Id: {typetype.ID} Type: {typetype.TypeType} ");

            }

            Console.WriteLine("\n");
        }

        int PrintFindPetId()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a id number ");
            }
            return id;
        }

        int PrintFindCustomerId()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a id number ");
            }
            return id;
        }

        int PrintFindTypeId()
        {
            Console.WriteLine("Insert Type Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a id number ");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.ID} Name: {pet.Name} " +
                    $" Price: {pet.Price}" +
                    $" Sold Date: {pet.SoldDate} " +
                    $" Birth Date: {pet.BirthDate} " +
                    $" Color: {pet.Color} "
                    );

            }

            Console.WriteLine("\n");

        }

        /// <summary>
        /// Shows the menu
        /// </summary>
        /// <returns>MEnu Choice as int</returns>
        /// <param name="menuItems">Menu items.</param>

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }


            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 16)
            {
                Console.WriteLine("Please select a number between 1-16");
            }

            return selection;
        }
    }
    #endregion
}
