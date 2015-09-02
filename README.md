# Maze-And-Dice
An unusual maze game playing with dice

#usage
1. Create your map with colliders.
2. Map's name in Hierarchy must be "Maze".
3. Use existing one or import your own dice model. It's size must be (1,1,1) in world space.
4. Dice's name in hierarchy must be "Dice".
5. Add Move and UpSide scripts as component of Dice.
6. Set Finish Offset of Move script on inspector (f.o= Vector3 finishCoordinates - Vector 3 startCoordinates)
7. Set the Dice array size as 6 and initialize each elements values. It shows which face of dice is looking which direction (eg. if a face looks up, it values need to be (0,1,0)) . Element0 is value 1, Element1 is value 2 and so on.
8. Flippers rotation must be (0,0,0) at first.
9. And run the game!

This is a ready to run project with one example map.
