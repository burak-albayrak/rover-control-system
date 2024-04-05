namespace TESODEV_Project1;

// Interface representing the contract for a rover
public interface IRover
{
    // Properties representing the X and Y coordinates and direction of rovers position
    int XCoordinate { get; set; }
    int YCoordinate { get; set; }
    char Direction { get; set; }
    
    // Methods to move the Rover one step forward in its current direction and rotation
    void RotateLeft();
    void RotateRight();
    void MoveForward(Plateau plateau); // Takes a Plateau object to check for boundaries and collisions

}
