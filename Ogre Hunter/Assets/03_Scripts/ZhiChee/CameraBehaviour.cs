using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //Character reference
    public Transform _target;

    //Camera's offset
    public Vector3 _offset = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            // Set our position to an offset of our target
            transform.position = _target.position + _offset;

            // Change the rotation to face target
            transform.LookAt(_target);
        }
    }
}
