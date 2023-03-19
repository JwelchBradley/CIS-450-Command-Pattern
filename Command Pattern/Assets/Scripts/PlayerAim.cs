/*
 * (Jacob Welch)
 * (PlayerAim)
 * (Command Pattern)
 * (Description: Aims the player's character to look at the mouse position.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    #region Functions
    /// <summary>
    /// Rotates the player to look at the mouse position.
    /// </summary>
    public void RotatePlayer()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        transform.right = mousePosition - transform.position;
    }
    #endregion
}
