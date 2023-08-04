using System;
using System.Threading;

namespace TESODEV_Project1;

public class Rover : RoverBase
{
    // Constructor to the rovers position and direction
    public Rover(int x, int y, char direction) : base(x, y, direction)
    {
    }

    // Method to rotate rovers 90 degrees to the left
    public override void RotateLeft()
    {
        switch (Direction)
        {
            case 'N':
                Direction = 'W';
                break;
            case 'E':
                Direction = 'N';
                break;
            case 'S':
                Direction = 'E';
                break;
            case 'W':
                Direction = 'S';
                break;
        }
    }

    // Method to rotate rovers 90 degrees to the right
    public override void RotateRight()
    {
        switch (Direction)
        {
            case 'N':
                Direction = 'E';
                break;
            case 'E':
                Direction = 'S';
                break;
            case 'S':
                Direction = 'W';
                break;
            case 'W':
                Direction = 'N';
                break;
        }
    }

    // Method to move the rover
    public override void MoveForward(Plateau plateau)
    {
        // Calculate the rovers new location
        int newX = XCoordinate;
        int newY = YCoordinate;

        switch (Direction)
        {
            case 'N':
                newY++;
                break;
            case 'E':
                newX++;
                break;
            case 'S':
                newY--;
                break;
            case 'W':
                newX--;
                break;
        }

        // Check the rovers new location is within in the plateau
        if (plateau.IsInsidePlateau(newX, newY))
        {
            // Check if there is another rover at the new position
            IRover existingRover = plateau.GetRoverAtPosition(newX, newY);

            // if the new position is empty, move the rover
            if (existingRover == null)
            {
                XCoordinate = newX;
                YCoordinate = newY;
                Thread.Sleep(1500);
                Console.WriteLine($"New position of the rover: ({XCoordinate}, {YCoordinate}) Direction: {Direction}");
            }
            // if the new position is not empty, write collision and remove the rovers on plateau
            else
            {
                plateau.RemoveRover(this);
                plateau.RemoveRover(existingRover);
                Console.WriteLine("Collision! Both rovers exploded!");
            }
        }
        // if the rovers new location is 
        else
        {
            Console.WriteLine("Rover cannot move outside of the plateau boundaries.");
        }
    }
}