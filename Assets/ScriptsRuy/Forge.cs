using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    public GameObject productPrefab;
    public int sourceObjId;
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
        if (Input.GetButtonDown("Fire1"))
        {
            Player player = col.gameObject.GetComponent<Player>();
            GameObject givenMat = player.Give();
            if(givenMat!= null)
            {
                if(givenMat.GetComponent<Id>().id == sourceObjId)
                {
                    Destroy(givenMat);
                    GameObject obj = Instantiate(productPrefab, col.transform.position, col.transform.rotation);
                    col.gameObject.GetComponent<Player>().PutInContainer(obj);

                }
            }
            Debug.Log(this.transform.name);
        }

    }
}
