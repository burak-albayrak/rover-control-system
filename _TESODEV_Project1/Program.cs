using System;
using System.Threading;
using System.Collections.Generic;

namespace TESODEV_Project1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome!");
        Thread.Sleep(1500);
        Console.WriteLine("Loading rover deploy and control system...");
        Thread.Sleep(3000);
        Console.WriteLine("Please enter the coordinate system (X Y):");
        string[] size = Console.ReadLine().Split(' ');
        int width = int.Parse(size[0]);
        int height = int.Parse(size[1]);

        Plateau plateau = new Plateau(width, height);

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. View deployed rovers");
            Console.WriteLine("2. Deploy a new rover");
            Console.WriteLine("3. Move a rover");
            Console.WriteLine("4. Exit");

            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    ViewDeployedRovers(plateau);
                    break;
                case "2":
                    DeployRover(plateau);
                    break;
                case "3":
                    MoveRover(plateau);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
    }

    static void ViewDeployedRovers(Plateau plateau)
    {
        Thread.Sleep(1500);
        Console.WriteLine("");
        Console.WriteLine("Rovers on the plateau:");

        // Harita matrisini oluşturuyoruz
        char[,] map = new char[plateau.Width, plateau.Height];

        foreach (IRover rover in plateau.Rovers)
        {
            // Gezginin koordinatlarını alıyoruz
            int x = rover.XCoordinate;
            int y = rover.YCoordinate;

            // Gezginin yönünü alıyoruz
            char direction = rover.Direction;

            // Haritada gezginin konumuna X karakterini ekliyoruz
            map[x, y] = 'X';
        }

        // Haritayı konsola çizdiriyoruz
        for (int y = plateau.Height - 1; y >= 0; y--)
        {
            for (int x = 0; x < plateau.Width; x++)
            {
                char cell = map[x, y];
                if (cell == '\0') // Harita boşsa nokta karakterini çizdiriyoruz
                    Console.Write('.');
                else
                    Console.Write(cell);
            }

            Console.WriteLine();
        }
    }

    static void DeployRover(Plateau plateau)
    {
        Console.WriteLine("Enter the coordinates and direction of the new rover (2 3 E):");
        string[] gezginGirişi = Console.ReadLine().Split(' ');

        int x = int.Parse(gezginGirişi[0]);
        int y = int.Parse(gezginGirişi[1]);
        char direction = char.ToUpper(gezginGirişi[2][0]);

        if (!plateau.IsInsidePlateau(x, y))
        {
            Thread.Sleep(1500);
            Console.WriteLine("The rover cannot be placed outside the plateau boundaries.");
            return;
        }

        if (plateau.IsPositionOccupied(x, y))
        {
            Thread.Sleep(1500);
            Console.WriteLine("Rovers cannot overlap with each other.");
            return;
        }

        IRover rover = new Rover(x, y, direction);
        plateau.AddRover(rover);
        Thread.Sleep(1500);
        Console.WriteLine("");
        Console.WriteLine("The rover has been successfully deployed.");
    }

    static void MoveRover(Plateau plateau)
    {
        Console.WriteLine("Select a rover to move:");
        for (int i = 0; i < plateau.Rovers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Rover at position ({plateau.Rovers[i].XCoordinate}, {plateau.Rovers[i].YCoordinate}) Direction: {plateau.Rovers[i].Direction}");
        }

        string selection = Console.ReadLine();
        if (int.TryParse(selection, out int selectedRoverIndex))
        {
            if (selectedRoverIndex >= 1 && selectedRoverIndex <= plateau.Rovers.Count)
            {
                IRover selectedRover = plateau.Rovers[selectedRoverIndex - 1];

                Console.WriteLine("Enter movement commands (LMMRLL):");
                string movements = Console.ReadLine().ToUpper();

                foreach (char command in movements)
                {
                    switch (command)
                    {
                        case 'L':
                            selectedRover.RotateLeft();
                            break;
                        case 'R':
                            selectedRover.RotateRight();
                            break;
                        case 'M':
                            selectedRover.MoveForward(plateau);
                            break;
                        default:
                            Console.WriteLine($"Invalid command: {command}");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid rover selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
