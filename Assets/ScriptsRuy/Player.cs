using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject container;
    public LayerMask collisionLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PutInContainer(GameObject obj)
    {
        this.container = obj;
        obj.transform.parent = this.transform;
    }

    public GameObject Give()
    {
        return this.container;
    }
    
    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.transform.name + " " + col.transform.tag);
    }
}
