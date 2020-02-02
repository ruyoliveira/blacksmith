using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public GameObject container;
    public LayerMask collisionLayers;
    public Transform containerAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsContainerEmpty()
    {
        return this.container == null;
    }

    public void PutInContainer(GameObject obj)
    {
        this.container = obj;
        obj.transform.SetParent(containerAnchor);
        obj.transform.SetPositionAndRotation(containerAnchor.position, containerAnchor.rotation);
    }

    public void DestroyObjectInContainer()
    {
        Destroy(this.container);
        container = (GameObject)null;
    }

    public void ClearContainer()
    {
        container = (GameObject)null;
    }
    public GameObject CheckInsideContainer()
    {
        return this.container;
    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.transform.name + " " + col.transform.tag);
    }
}
