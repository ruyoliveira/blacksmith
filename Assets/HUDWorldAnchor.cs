using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDWorldAnchor : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(target.position - this.transform.position + offset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
