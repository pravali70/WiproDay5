using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentManagementSystem.Exceptions;

namespace AgentManagementSystem.Models
{
    public class Agent
    {
        private static int counter = 1000;
        public int AgentId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public double PremiumAmount { get; set; }

        public Agent(string firstName, string lastName, string city, string gender, double premium)
        {
            if (firstName.Length < 3) throw new InvalidInputException("First name must be at least 3 characters.");
            if (lastName.Length < 3) throw new InvalidInputException("Last name must be at least 3 characters.");
            if (gender != "Male" && gender != "Female") throw new InvalidInputException("Gender must be Male or Female.");
            if (premium <= 10000) throw new InvalidInputException("Premium must be greater than 10000.");

            AgentId = ++counter;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Gender = gender;
            PremiumAmount = premium;
        }

        public void Display()
        {
            Console.WriteLine($"\nAgent ID: {AgentId}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Premium Amount: ₹{PremiumAmount}");
        }
    }
}
