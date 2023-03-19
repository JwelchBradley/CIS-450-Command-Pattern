/*
 * (Jacob Welch)
 * (PlayerMovement)
 * (Command Pattern)
 * (Description: Moves the player based on their horizontal and vertical inputs.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// The rigidbody that will be moved for physics calculations.
    /// </summary>
    private Rigidbody2D rigidbody2D;

    /// <summary>
    /// The speed of movement.
    /// </summary>
    private float speed = 5.0f;

    /// <summary>
    /// The vector used to keep the player in bounds.
    /// </summary>
    private Vector2 boundingVector = new Vector2(9.2f, 5);
    #endregion

    #region Functions
    /// <summary>
    /// Initializes components.
    /// </summary>
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Moves the player based on input.
    /// </summary>
    public void MovePlayer()
    {
        // User input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        // Gets new position
        var moveAmount = new Vector2(horizontal, vertical).normalized * speed * Time.fixedDeltaTime;
        var newPosition = rigidbody2D.position + moveAmount;
        newPosition = new Vector2(Mathf.Clamp(newPosition.x, -boundingVector.x, boundingVector.x), Mathf.Clamp(newPosition.y, -boundingVector.y, boundingVector.y));

        rigidbody2D.MovePosition(newPosition);
    }
    #endregion
}
