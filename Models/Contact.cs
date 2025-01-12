using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListApplicationOne.Models
{
	public class Contact
	{
		public Guid Id { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }

		public Contact(string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city)
		{
			Id = Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			PhoneNumber = phoneNumber;
			Address = address;
			ZipCode = zipCode;
			City = city;
		}


	}
}
