using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentManagementSystem.Services;

namespace AgentManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            AgentService service = new AgentService();
            int choice;

            do
            {
                Console.WriteLine("\n--- Agent Management System ---");
                Console.WriteLine("1. Add Agent");
                Console.WriteLine("2. Show Agents");
                Console.WriteLine("3. Search Agent");
                Console.WriteLine("4. Update Agent");
                Console.WriteLine("5. Delete Agent");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                bool valid = int.TryParse(Console.ReadLine(), out choice);
                if (!valid)
                {
                    Console.WriteLine("Enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: service.AddAgent(); break;
                    case 2: service.ShowAgents(); break;
                    case 3: service.SearchAgent(); break;
                    case 4: service.UpdateAgent(); break;
                    case 5: service.DeleteAgent(); break;
                    case 6: Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid choice."); break;
                }

            } while (choice != 6);
        }
    }
}
