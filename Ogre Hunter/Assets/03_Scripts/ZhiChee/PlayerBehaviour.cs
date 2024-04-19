using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //declaration
    private Rigidbody _rb;

    //variable
    public float _dodgeSpd;
    public float _moveSpd;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _horiSpd = Input.GetAxis("Horizontal") * _dodgeSpd;
        _rb.AddForce(_horiSpd, 0, _moveSpd);
    }
}
