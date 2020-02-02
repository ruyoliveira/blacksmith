using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMove : MonoBehaviour
{
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
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 rotDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;

        if (dir.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(rotDir);
            _rigid.velocity = dir * runBoost;
        }
        else
        {
            _rigid.velocity = Vector3.zero;
        }
        
    }
}
