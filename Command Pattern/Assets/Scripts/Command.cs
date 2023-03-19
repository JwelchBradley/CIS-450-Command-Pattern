/*
 * (Jacob Welch)
 * (Command)
 * (Command Pattern)
 * (Description: An interface for all commands that can be executed and undone.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    /// <summary>
    /// Executes a specified action.
    /// </summary>
    public void Execute();

    /// <summary>
    /// Undos a specified action.
    /// </summary>
    public void Undo();
}