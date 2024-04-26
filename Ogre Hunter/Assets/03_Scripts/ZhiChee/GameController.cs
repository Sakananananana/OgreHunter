using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the main gameplay
/// </summary>
public class GameController : MonoBehaviour
{
    [Tooltip("A reference to the tile we want to spawn")]
    public Transform tile00;
    public Transform tile01;
    public Transform tile;
    public Transform tileStorage;
    //random range 1 - 3?
    //tile = tile00/tile01/tile02 to have different mapping.. later on do for aesthetic purposes

    private bool spawned;
    OgreBehaviour ogBehave;
    int targetNum = 0;
    public GameObject enemy;

    [Tooltip("A reference to the obstacle we want to spawn")]
    public List<Transform> obstacle;
    public Transform obstacleType00;
    public Transform obstacleType01;
    public Transform obstacleType02;
    int obstacleNum;

    [Tooltip("Where the first tile should be placed at")]
    public Vector3 startPoint = new Vector3(0, 20, -5);
    [Tooltip("How many tiles should we create in advance")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Tooltip("How many tiles to spawn initially with no obstacles")]
    public int initNoObstacles = 0;

    /// <summary>
    /// Where the next tile should be spawned at.
    /// </summary>
    private Vector3 nextTileLocation;

    /// <summary>
    /// How should the next tile be rotated?
    /// </summary>
    private Quaternion nextTileRotation;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        // Insert type of obstacles in
        obstacle = new List<Transform>();
        obstacle.Insert(0, obstacleType00);
        obstacle.Insert(1, obstacleType01);
        obstacle.Insert(2, obstacleType02);

        // Set our starting point
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }

    public void Update()
    {
        
    }

    /// <summary>
    /// Will spawn a tile at a certain location and setup the next
    /// position
    /// </summary>
    /// /// <param name="spawnObstacles">If we should spawn an
    /// obstacle</param>
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        Transform newTile = Instantiate(tile, nextTileLocation, nextTileRotation);
        newTile.SetParent(tileStorage);
        // Figure out where and at what rotation we should spawn
        // the next item
        var nextTile = newTile.Find("NextSpawnPoint");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;

        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    private void SpawnObstacle(Transform newTile)
    {
        // Now we need to get all of the possible places to spawn the
        // obstacle
        var obstacleSpawnPoints = new List<GameObject>();
        // Go through each of the child game objects in our tile
        foreach (Transform child in newTile)
        {
            // If it has the ObstacleSpawn tag
            if (child.CompareTag("ObstacleSpawn"))
            {
                // We add it as a possibility
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }
    
        // Make sure there is at least one
        if (obstacleSpawnPoints.Count > 0)
        {
            // Get a random object from the ones we have
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];

            // Store its position for us to use
            var spawnPos = spawnPoint.transform.position;
            
            // To spawn obstacle
            if (!spawned)
            {
                // Create our obstacle 
                var newObstacle = Instantiate(obstacle[Random.Range(0, obstacle.Count)], spawnPos, Quaternion.identity);

                // Have it parented to the tile
                newObstacle.SetParent(spawnPoint.transform);

                obstacleSpawnPoints.Remove(spawnPoint);

                // To stop spawnning
                spawned = true;
            }

            //To give enemy target to follow, so no collide with obstacle
            if (spawned)
            {
                spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];

                ogBehave = enemy.GetComponent<OgreBehaviour>();

                Debug.Log(spawnPoint);
                Debug.Log(spawnPoint.transform.position);

                ogBehave._target.Insert(targetNum, spawnPoint);

                targetNum++;

                spawned = false;
            }
        }
    }
}


