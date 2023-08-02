namespace TESODEV_Project1;

public class Plateau
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<IRover> Rovers { get; } = new List<IRover>();

    public Plateau(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void AddRover(IRover rover)
    {
        Rovers.Add(rover);
    }

    public bool IsInsidePlateau(int x, int y)
    {
        return x >= 0 && x <= Width && y >= 0 && y <= Height;
    }

    public bool IsPositionOccupied(int x, int y)
    {
        return Rovers.Any(rover => rover.XCoordinate == x && rover.YCoordinate == y);
    }
    public IRover GetRoverAtPosition(int x, int y)
    {
        return Rovers.FirstOrDefault(rover => rover.XCoordinate == x && rover.YCoordinate == y);
    }

    public void RemoveRover(IRover rover)
    {
        Rovers.Remove(rover);
    }
}
