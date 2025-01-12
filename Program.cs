using System;
using ContactListApplicationOne.Interfaces;
using ContactListApplicationOne.Services;

namespace ContactListApplicationOne
{
	public class Program
	{
		static void Main (string[] args)
		{


			// Manual Dependency Injection
			IContactService contactService = new ContactService();

			// Pass the service to the input handler
			var userInputHandler = new UserInputHandler(contactService);

			// Start the application
			userInputHandler.ShowMenu();

		}
	}
}