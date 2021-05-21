using HepsiCase.Application.Contracts;
using HepsiCase.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HepsiCase.ConsoleApp
{
    class Program
    {
        private static ServiceProvider InitializeServices()
        {
            var services = new ServiceCollection();
            services.ConfigureServices();
            return services.BuildServiceProvider();
        }

        static void Main(string[] args)
        {
            var provider = InitializeServices();

            Console.WriteLine("Welcome to the HepsiCase Mars Rover Application");
            Console.WriteLine("===============================================");

            var plateau = provider.GetService<IPlateau>();
            var commander = provider.GetService<ICommander>();

            while (true)
            {
                try
                {
                    Console.WriteLine("\nPlease enter the plateau size (like '5 5'): ");
                    var size = Console.ReadLine();

                    plateau.SetSize(size);
                    commander.Plateau = plateau;

                    Console.WriteLine("\nEnter position for rover (like '1 2 N'): ");
                    var position = Console.ReadLine();

                    var rover = provider.GetService<IRover>();
                    rover.SetPosition(position);

                    Console.WriteLine("\nEnter your commands (like 'LMLMLMLMM'): ");
                    var commands = Console.ReadLine();

                    rover.Commands = commands;
                    commander.Plateau.AddRover(rover);
                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{ex.Message}");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine("\nDo you want to add another Rover? (Y/N): ");
                var answer = Console.ReadLine();

                if (answer.ToLower() != "y")
                    break;
            }

            if (commander != null && commander.Plateau != null)
            {
                foreach (var rover in commander.Plateau.Rovers)
                {
                    try
                    {
                        commander.Move(rover);
                        Console.WriteLine($"\n{rover.PositionX} {rover.PositionY} {rover.Direction}");
                        Console.WriteLine($"The rover landed at point ({rover.PositionX} {rover.PositionY}) and the rover is facing direction '{rover.Direction}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }

            Console.Read();
        }
    }
}
