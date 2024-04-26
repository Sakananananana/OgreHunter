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
    private float _horiSpd;
    private float _angle;
    private float _r;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horiSpd = Input.GetAxis("Horizontal") * _dodgeSpd;
        _rb.velocity = new Vector3(0, 0, _moveSpd);
        _rb.AddForce(_horiSpd, 0, 0);

        _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _horiSpd/7, ref _r, 0.2f);

        transform.rotation = Quaternion.Euler(0, _angle, 0);
    }

}
