using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListApplicationOne.Models;

namespace ContactListApplicationOne.Interfaces
{
	public interface IContactService
	{
		void AddContact(string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city);
		List<Contact> GetAllContacts();
		void SaveContactsToFile();
		void LoadContactsFromFile();
		
	}
}
