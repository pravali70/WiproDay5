using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentManagementSystem.Models;
using AgentManagementSystem.Exceptions;

namespace AgentManagementSystem.Services
{
    public class AgentService
    {
        private List<Agent> agents = new List<Agent>();

        public void AddAgent()
        {
            try
            {
                Console.Write("Enter First Name: ");
                string fname = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lname = Console.ReadLine();

                Console.Write("Enter City: ");
                string city = Console.ReadLine();

                Console.Write("Enter Gender (Male/Female): ");
                string gender = Console.ReadLine();

                Console.Write("Enter Premium Amount: ");
                double premium = Convert.ToDouble(Console.ReadLine());

                Agent newAgent = new Agent(fname, lname, city, gender, premium);
                agents.Add(newAgent);
                Console.WriteLine("Agent record inserted successfully.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Input Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        public void ShowAgents()
        {
            if (agents.Count == 0)
                Console.WriteLine("No agents found.");
            else
                agents.ForEach(a => a.Display());
        }

        public void SearchAgent()
        {
            Console.Write("Enter Agent ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Agent found = agents.Find(a => a.AgentId == id);

            if (found != null) found.Display();
            else Console.WriteLine("Agent not found.");
        }

        public void UpdateAgent()
        {
            Console.Write("Enter Agent ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Agent agent = agents.Find(a => a.AgentId == id);
            if (agent == null)
            {
                Console.WriteLine("Agent not found.");
                return;
            }

            try
            {
                Console.Write("Enter New First Name: ");
                string fname = Console.ReadLine();

                Console.Write("Enter New Last Name: ");
                string lname = Console.ReadLine();

                Console.Write("Enter New City: ");
                string city = Console.ReadLine();

                Console.Write("Enter New Gender (Male/Female): ");
                string gender = Console.ReadLine();

                Console.Write("Enter New Premium Amount: ");
                double premium = Convert.ToDouble(Console.ReadLine());

                if (fname.Length < 3 || lname.Length < 3)
                    throw new InvalidInputException("First or last name must be at least 3 characters.");
                if (gender != "Male" && gender != "Female")
                    throw new InvalidInputException("Gender must be Male or Female.");
                if (premium <= 10000)
                    throw new InvalidInputException("Premium must be greater than 10000.");

                agent.FirstName = fname;
                agent.LastName = lname;
                agent.City = city;
                agent.Gender = gender;
                agent.PremiumAmount = premium;

                Console.WriteLine("Agent updated successfully.");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Update Error: " + ex.Message);
            }
        }

        public void DeleteAgent()
        {
            Console.Write("Enter Agent ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Agent agent = agents.Find(a => a.AgentId == id);
            if (agent != null)
            {
                agents.Remove(agent);
                Console.WriteLine("Agent deleted successfully.");
            }
            else
            {
                Console.WriteLine("Agent not found.");
            }
        }
    }
}
