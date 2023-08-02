namespace TESODEV_Project1;

public class Rover : RoverBase
{
    public Rover(int x, int y, char direction) : base(x, y, direction)
    {
    }

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

    public override void MoveForward(Plateau plateau)
    {
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

        if (plateau.IsInsidePlateau(newX, newY))
        {
            IRover existingRover = plateau.GetRoverAtPosition(newX, newY);

            if (existingRover == null)
            {
                XCoordinate = newX;
                YCoordinate = newY;
                Thread.Sleep(1500);
                Console.WriteLine($"New position of the rover: ({XCoordinate}, {YCoordinate}) Direction: {Direction}");
            }
            else
            {
                // Gezgin çarpışması işleme (her iki gezgin de patlar)
                plateau.RemoveRover(this);
                plateau.RemoveRover(existingRover);
                Console.WriteLine("Collision! Both rovers exploded!");
            }
        }
        else
        {
            Console.WriteLine("Rover cannot move outside of the plateau boundaries.");
        }
    }
}