using System;
using ContactListApplicationOne.Models;
using ContactListApplicationOne.Interfaces;
using ContactListApplicationOne.Configuration;
using System.Text.Json;


namespace ContactListApplicationOne.Services
{
	public class ContactService : IContactService
	{
		private readonly List<Contact> _contacts;

		public ContactService()
		{
			_contacts = new List<Contact>();
		}
		public void AddContact(string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city)
		{
			var contact = new Contact(firstName, lastName, email, phoneNumber, address, zipCode, city);
			_contacts.Add(contact);
		}

		public List<Contact> GetAllContacts()
		{
			return _contacts;
		}

		public void SaveContactsToFile()
		{
			var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(AppConfig.FilePath, json);
			Console.WriteLine($"Contacts saved to {AppConfig.FilePath}");
		}

		public void LoadContactsFromFile()
		{
			if (File.Exists(AppConfig.FilePath))
			{
				var json = File.ReadAllText(AppConfig.FilePath);
				var contactsFromFile = JsonSerializer.Deserialize<List<Contact>>(json);

				if (contactsFromFile != null && contactsFromFile.Any())
				{
					// Clear the existing list and add new contacts
					_contacts.Clear();
					_contacts.AddRange(contactsFromFile);

					Console.WriteLine($"Loaded {_contacts.Count} contacts from {AppConfig.FilePath}");
				}
				else
				{
					Console.WriteLine("The file exists, but it contains no valid contacts or is empty. Nothing was loaded.");
				}
			}
			else
			{
				Console.WriteLine($"File not found: {AppConfig.FilePath}");
			}
		}
	}
}
