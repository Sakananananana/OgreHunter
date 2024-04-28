using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float CurPos;
    private float NextPos;

    public int Score;
    [SerializeField] private Text Scoretxt;

    public string ScoreNumtxt;

    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        CurPos = this.transform.position.z;
        NextPos = CurPos + 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horiSpd = Input.GetAxis("Horizontal") * _dodgeSpd;
        _rb.velocity = new Vector3(0, 0, _moveSpd);
        _rb.AddForce(_horiSpd, 0, 0);

        _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _horiSpd/7, ref _r, 0.2f);

        transform.rotation = Quaternion.Euler(0, _angle, 0);

        CheckDistanceTravel();
    }

    private void CheckDistanceTravel()
    {
        CurPos = this.transform.position.z;

        if (CurPos >= NextPos)
        {
            Score += 1;
            NextPos += 1;
        }

        ConvertScore();

        Scoretxt.text = "Score :\n" + ScoreNumtxt;
    }


    private void ConvertScore()
    {
        string Converter = "00000000";

        ScoreNumtxt = Score.ToString(Converter);
    }

}
