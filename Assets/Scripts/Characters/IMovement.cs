using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All scripts implementing the  IMovement shall them self make the character move.
/// They shall them self decide on what buttons or actions that will activate the movement
/// </summary>
public interface IMovement
{
    Vector2 GetLastDirection();
}



//// Covered, trying to get away from the boos and shoot at it
/// The