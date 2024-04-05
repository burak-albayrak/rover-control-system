using System.Collections.Generic;
using System.Linq;

namespace TESODEV_Project1;

// This class representing a plateau where rovers can move
public class Plateau
{
    // Properties representing the width and height of the plateau
    public int Width { get; set; }

    public int Height { get; set; }

    // List to store the rovers currently on the plateau
    public List<IRover> Rovers { get; } = new List<IRover>();

    // Constructor to initialize the Plateau with its width and height
    public Plateau(int width, int height)
    {
        Width = width;
        Height = height;
    }

    // Method to add a rover to the plateau's list of Rovers
    public void AddRover(IRover rover)
    {
        Rovers.Add(rover);
    }

    // Method to check if a given position is inside the plateau boundaries
    public bool IsInsidePlateau(int x, int y)
    {
        return x >= 0 && x <= Width && y >= 0 && y <= Height;
    }
    
    // Method to check if a given position is occupied by any rover on the plateau
    public bool IsPositionOccupied(int x, int y)
    {
        return Rovers.Any(rover => rover.XCoordinate == x && rover.YCoordinate == y);
    }

    // Method to get the rover at a given position on the plateau
    public IRover GetRoverAtPosition(int x, int y)
    {
        return Rovers.FirstOrDefault(rover => rover.XCoordinate == x && rover.YCoordinate == y);
    }

    // Method to remove a given rover from the plateau
    public void RemoveRover(IRover rover)
    {
        Rovers.Remove(rover);
    }
}
