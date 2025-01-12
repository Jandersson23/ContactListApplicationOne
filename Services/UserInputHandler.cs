using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListApplicationOne.Interfaces;



namespace ContactListApplicationOne.Services
{
	public class UserInputHandler
	{
		private readonly IContactService _contactService;

		// Injecting the contact service into this class
		public UserInputHandler(IContactService contactService)
		{
			_contactService = contactService;
		}

		public void ShowMenu()
		{
			while (true)
			{
				Console.WriteLine("\n--- Contact Application Menu ---");
				Console.WriteLine("1. Add a Contact");
				Console.WriteLine("2. List All Contacts");
				Console.WriteLine("3. Save contacts to file");
				Console.WriteLine("4. Load contacts");
				Console.WriteLine("0. Exit");

				Console.Write("\nEnter your choice: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						AddContact();
						break;
					case "2":
						ListContacts();
						break;
					case "3":
						_contactService.SaveContactsToFile();
						break;
					case "4":
						_contactService.LoadContactsFromFile();
						break;
					case "0":
						Console.WriteLine("Goodbye!");
						return;
					default:
						Console.WriteLine("Invalid choice. Try again.");
						break;
				}
			}
		}

		public string GetValidatedInput(string fieldName)
		{
			while (true)
			{
				Console.Write($"{fieldName}: ");
				var input = Console.ReadLine() ?? string.Empty;

				if (!string.IsNullOrWhiteSpace(input))
				{
					return input; // Return valid input
				}

				Console.WriteLine($"Error: {fieldName} cannot be empty. Please try again.");
			}
		}

		public void AddContact()
		{
			var firstName = GetValidatedInput("First Name");
			var lastName = GetValidatedInput("Last Name");
			var email = GetValidatedInput("Email");
			var phoneNumber = GetValidatedInput("Phone Number");
			var address = GetValidatedInput("Address");
			var zipCode = GetValidatedInput("Zip Code");
			var city = GetValidatedInput("City");

			_contactService.AddContact(firstName, lastName, email, phoneNumber, address, zipCode, city);
			Console.WriteLine("Contact added successfully!");
		}

		public void ListContacts()
		{
			Console.WriteLine("\n--- Contact List ---");
			var contacts = _contactService.GetAllContacts();

			if (contacts.Count == 0)
			{
				Console.WriteLine("No contacts found.");
				return;
			}

			foreach (var contact in contacts)
			{
				Console.WriteLine($"ID: {contact.Id}, Name: {contact.FirstName} {contact.LastName}, Email: {contact.Email}");
			}
		}

	}
}

