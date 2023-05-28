using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class NavigationNode : MonoBehaviour
{
    public UnlockNode isUnlocked;
    public NavigationNode up;
    public NavigationNode down;
    public NavigationNode left;
    public NavigationNode right;
    public int levelNumber;

    public NavigationNode GetConnectedNode(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return up;
            case Direction.Down:
                return down;
            case Direction.Left:
                return left;
            case Direction.Right:
                return right;
            default:
                return null;
        }
    }
}
