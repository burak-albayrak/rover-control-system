# Rover Control System

## Overview

This project implements a rover control system that simulates the movement of rovers on a plateau. The system allows users to deploy multiple rovers onto the plateau, move them around, and view their positions. The rovers are constrained by the boundaries of the plateau and cannot overlap with each other.

## Usage

### Deploying a Rover

To deploy a new rover onto the plateau:

1. Run the program.

2. Enter the coordinate system (X Y) for the plateau when prompted.

3. Choose option 2 from the main menu to deploy a new rover.

4. Enter the rover's coordinates and direction (X Y D) when prompted. (e.g., `2 3 E`)

### Moving a Rover

To move a deployed rover on the plateau:

1. Run the program and deploy rovers onto the plateau.

2. Choose option 3 from the main menu to move a rover.

3. Select the rover you want to move from the list displayed.

4. When prompted, Enter the movement commands (L for left, R for right, M for move forward). (e.g., `LMMRLL`)

### Viewing Deployed Rovers

To view all the rovers currently deployed on the plateau:

1. Run the program and deploy rovers onto the plateau.

2. Choose option 1 from the main menu.

3. The system will display a grid representing the plateau with deployed rovers marked as 'X'.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please fork the repository and create a pull request with your changes.
