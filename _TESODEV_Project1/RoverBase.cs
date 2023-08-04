namespace TESODEV_Project1;

// Abstract class representing the base implementation of a Rover and implements the IRover interface
public abstract class RoverBase : IRover
{
    // Properties representing the X and Y coordinates and direction of rovers position
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }
    public char Direction { get; set; }

    // Constructor to initialize the RoverBase with its position and direction
    public RoverBase(int x, int y, char direction)
    {
        XCoordinate = x;
        YCoordinate = y;
        Direction = direction;
    }

    // Abstract methods to move the over one step forward in its current direction and rotation
    public abstract void RotateLeft();
    public abstract void RotateRight();
    public abstract void MoveForward(Plateau plateau);
}
