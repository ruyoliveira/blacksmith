using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBox : MonoBehaviour
{
    public GameObject materialPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider col)
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(materialPrefab, col.transform.position, col.transform.rotation);
            col.gameObject.GetComponent<Player>().PutInContainer(obj);
            Debug.Log(this.transform.name);
        }
        
    }
}
