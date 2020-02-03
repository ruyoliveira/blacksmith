using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMove : MonoBehaviour
{
    public int input;

    Rigidbody _rigid;
    private float runBoost;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        runBoost = Input.GetKey(KeyCode.LeftShift) ? 10.0f : 5.0f;
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal" + input), 0.0f, Input.GetAxisRaw("Vertical" + input)).normalized;
        Vector3 rotDir = new Vector3(Input.GetAxis("Horizontal" + input), 0.0f, Input.GetAxis("Vertical" + input)).normalized;

        if (dir.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(rotDir);
            _rigid.velocity =  dir  * runBoost  + _rigid.velocity.y * Vector3.up;
        }
        else
        {
            _rigid.velocity = new Vector3(0.0f, _rigid.velocity.y,0.0f);
        }
        
    }
}
