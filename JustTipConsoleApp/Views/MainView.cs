using JustTipConsoleApp.Controllers;
using JustTipConsoleApp.Models;

namespace JustTipConsoleApp.Views
{
    public class MainView
    {
        private MainController controller;

        public MainView(MainController controller)
        {
            this.controller = controller;
        }
        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("----JustTip App -----");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Create Roster");
                Console.WriteLine("3. Assign Employees to a Specific Roster");
                Console.WriteLine("4. Distribute Tips for a Specific Roster");
                Console.WriteLine("5. Show Tip Distribution");
                Console.WriteLine("6. Exit");

                Console.WriteLine("Select an Option");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.AddEmployee();
                        break;
                    case "2":
                        controller.CreateRoster();
                        break;
                    case "3":
                        Console.WriteLine("Enter roster Name");
                        string rosName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Name");
                        string emp = Console.ReadLine();
                        controller.AssignEmployeesToRoster(rosName,emp);
                        break;
                    case "4":
                        Console.WriteLine("Enter the Roster Name");
                        string rosName1 = Console.ReadLine();
                        Console.WriteLine("Enter Total Tip Gathered for this specific roster");

                        // Reading the input from the command line as a string
                        string input = Console.ReadLine();

                        // Attempt to convert the input to a decimal value
                        if (decimal.TryParse(input, out decimal decimalValue))
                        {
                            Console.WriteLine($"You entered the decimal value: {decimalValue}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid decimal value entered. Please try again.");
                        }
                        controller.DistributeTips(rosName1, decimalValue);
                        break;
                    case "5":
                        controller.ShowTips();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Try Again");
                        break;

                }
            }

        }
        }
    }
