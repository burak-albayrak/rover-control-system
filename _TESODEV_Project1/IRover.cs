namespace TESODEV_Project1;

public interface IRover
{
    int XCoordinate { get; set; }
    int YCoordinate { get; set; }
    char Direction { get; set; }

    void RotateLeft();
    void RotateRight();
    void MoveForward(Plateau plateau);
}