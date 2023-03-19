/*
 * (Jacob Welch)
 * (PlayerAimCommand)
 * (Command Pattern)
 * (Description: Handles the exectution and undoing of player aim inputs.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimCommand : Command
{
    #region Fields
    /// <summary>
    /// A stack of all previous player rotations.
    /// </summary>
    private Stack<Quaternion> playerRotationStack = new Stack<Quaternion>();

    /// <summary>
    /// The component that handles actually aiming the player's rotation.
    /// </summary>
    private PlayerAim playerAim;
    #endregion

    #region Functions
    /// <summary>
    /// Initialzes the object with its playeraim.
    /// </summary>
    /// <param name="playerAim">The player aim to use in command executions.</param>
    public PlayerAimCommand(PlayerAim playerAim)
    {
        this.playerAim = playerAim;
    }

    /// <summary>
    /// Executes the aiming command and tracks previous rotations.
    /// </summary>
    public void Execute()
    {
        playerRotationStack.Push(playerAim.transform.rotation);

        playerAim.RotatePlayer();
    }

    /// <summary>
    /// Undos previous aiming commands.
    /// </summary>
    public void Undo()
    {
        if (playerRotationStack.Count == 0) return;

        playerAim.transform.rotation = playerRotationStack.Pop();
    }
    #endregion
}
