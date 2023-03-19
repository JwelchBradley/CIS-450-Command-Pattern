/*
 * (Jacob Welch)
 * (PlayerMovementCommand)
 * (Command Pattern)
 * (Description: A command for executing and undoing movement.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCommand : Command
{
    #region Fields
    /// <summary>
    /// Keeps track of all previous player positions.
    /// </summary>
    private Stack<Vector3> playerPositionStack = new Stack<Vector3>();

    /// <summary>
    /// The player movement component that will handle new movements.
    /// </summary>
    private PlayerMovement playerMovement;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes the object with its component for moving the player.
    /// </summary>
    /// <param name="playerMovement">The component for moving the player.</param>
    public PlayerMovementCommand(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    /// <summary>
    /// Records previous positions and moves the player.
    /// </summary>
    public void Execute()
    {
        playerPositionStack.Push(playerMovement.transform.position);

        playerMovement.MovePlayer();
    }

    /// <summary>
    /// Undos previous commands of movement.
    /// </summary>
    public void Undo()
    {
        if (playerPositionStack.Count == 0) return;

        playerMovement.transform.position = playerPositionStack.Pop();
    }
    #endregion
}
