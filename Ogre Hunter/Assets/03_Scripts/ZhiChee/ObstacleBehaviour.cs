using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene
public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("How long to wait before Displaying Restart Game Menu")]
    public float waitTime = 1.0f;

    [Tooltip("Rock Destroy Audio & Behaviour")]
    public AudioSource obstacleSource;
    public AudioClip obstacleSFX;
    MeshRenderer obstacleMesh;
    MeshCollider obstacleCollider;

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
            //Play Audio
            obstacleSource.PlayOneShot(obstacleSFX);

            //Set Mesh to Invisible
            obstacleMesh = this.gameObject.GetComponent<MeshRenderer>();
            obstacleMesh.enabled = false;

            //Set Mesh Collider to False
            obstacleCollider = this.gameObject.GetComponent<MeshCollider>();
            obstacleCollider.enabled = false;

            //Destroy the rock
            Destroy(this.gameObject, 1f);
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
