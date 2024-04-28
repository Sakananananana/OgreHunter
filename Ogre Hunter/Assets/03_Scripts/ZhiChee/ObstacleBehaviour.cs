using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene
public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("How long to wait before Displaying Restart Game Menu")]
    public float waitTime = 1.0f;

    

    private void OnCollisionEnter(Collision collision)
    {
        // First check if we collided with the player
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            // Destroy the player
            Destroy(collision.gameObject);
            // Call the function ResetGame after waitTime
            // has passed
            Invoke("ResetGame", waitTime);
        }

        if (collision.gameObject.GetComponent<OgreBehaviour>())
        {
            // Destroy the player
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// Let Reset Game Menu to be active
    /// </summary>
    private void ResetGame()
    {
        //Access InGameButtonBehaviour to open reset game menu
        InGameButtonBehaviour.Instance.ResetDisplay();
    }
}
