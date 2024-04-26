using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreBehaviour : MonoBehaviour
{
    Rigidbody _rb;

    //after a tile is spawned 
    //check the obstacle spawn place and randomize between the left spawn point as target to walk towards
    //i need a list to store target to move to

    public List<GameObject> _target;
    public GameObject _tileStorage;

    private Vector3 direction;
    public int targetNum;
    public int count;
    private float maxSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        _target = new List<GameObject>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_target);
        //Debug.Log(_target[targetNum].transform.position);
        direction = (_target[targetNum].transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        _rb.velocity = direction * maxSpeed;
    }

}
