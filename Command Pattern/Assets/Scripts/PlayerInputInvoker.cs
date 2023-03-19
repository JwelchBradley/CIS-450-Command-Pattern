/*
 * (Jacob Welch)
 * (PlayerInputInvoker)
 * (Command Pattern)
 * (Description: Invokes commands base on user input and allows the user
 *               to undo those commands.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAim))]
public class PlayerInputInvoker : MonoBehaviour
{
    #region Fields
    // Action components
    private PlayerMovement playerMovement;
    private PlayerAim playerAim;

    // Command objects
    private Command playerMovementCommand;
    private Command playerAimCommand;

    /// <summary>
    /// The last recorded position of the users mouse.
    /// </summary>
    private Vector2 lastMousePosition = Vector2.negativeInfinity;

    /// <summary>
    /// A stack of all previous frames that had commands.
    /// </summary>
    private Stack<List<Command>> previousCommands = new Stack<List<Command>>();
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAim = GetComponent<PlayerAim>();

        playerMovementCommand = new PlayerMovementCommand(playerMovement);
        playerAimCommand = new PlayerAimCommand(playerAim);
    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            UndoCommands();
        }
        else
        {
            CheckCommandInputs();
        }
    }

    /// <summary>
    /// Checks if the user has made inputs and executes those commands.
    /// </summary>
    private void CheckCommandInputs()
    {
        List<Command> frameCommands = new List<Command>();

        #region Check Movement Input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            playerMovementCommand.Execute();
            frameCommands.Add(playerMovementCommand);

            playerAimCommand.Execute();
            frameCommands.Add(playerAimCommand);
        }
        #endregion

        else if(lastMousePosition != (Vector2)Input.mousePosition)
        {
            lastMousePosition = Input.mousePosition;
            playerAimCommand.Execute();
            frameCommands.Add(playerAimCommand);
        }

        if (frameCommands.Count != 0)
        {
            previousCommands.Push(frameCommands);
        }
    }

    /// <summary>
    /// Undos previous commands by each frame they happened in.
    /// </summary>
    private void UndoCommands()
    {
        if (previousCommands.Count == 0) return;

        var frameCommands = previousCommands.Pop();

        foreach(Command command in frameCommands)
        {
            command.Undo();
        }
    }
    #endregion
}
