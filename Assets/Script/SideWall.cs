using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public bool isLeftWall; // True if this is the left wall, false if this is the right wall

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Use tag comparison for better performance and flexibility
        if (hitInfo.CompareTag("ball"))  // Ensure correct casing for tag
        {
            // Store the name of the wall that was hit
            string sideWallName = transform.name;

            // Log the name of the wall that was hit
            Debug.Log("sideWallName: " + sideWallName);

            // Restart the game when the ball hits the wall
            hitInfo.gameObject.SendMessage("RestartGame");

            // Pass the wall name to the Score method in GameManager
            GameManager.instance.Score(sideWallName);
        }
    }
}
