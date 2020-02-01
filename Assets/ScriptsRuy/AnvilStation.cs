using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilStation : Station
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
        if (col.transform.tag == "Player")
        {
            Player player = col.transform.GetComponent<Player>();

            if (Input.GetButtonDown("Fire" + player.id.ToString()))
            {
                GameObject givenMat = player.CheckInsideContainer();
                if (givenMat != null)
                {
                    if (givenMat.GetComponent<Id>().id == sourceObjId)
                    {
                        player.DestroyObjectInContainer();
                        GameObject obj = Instantiate(productPrefab, col.transform.position, productPrefab.transform.rotation);
                        col.gameObject.GetComponent<Player>().PutInContainer(obj);

                    }
                    else Debug.Log("Wrong source input, Player" + player.id);
                }
                else
                {
                    Debug.Log("Empty hands, Player" + player.id);
                }
                
            }
        }

    }
}
