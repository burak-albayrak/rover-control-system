namespace TESODEV_Project1;

public abstract class RoverBase : IRover
{
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }
    public char Direction { get; set; }

    public RoverBase(int x, int y, char direction)
    {
        XCoordinate = x;
        YCoordinate = y;
        Direction = direction;
    }

    public abstract void RotateLeft();
    public abstract void RotateRight();
    public abstract void MoveForward(Plateau plateau);
}
