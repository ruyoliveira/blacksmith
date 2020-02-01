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
        if (col.transform.tag == "Player")
        {
            Player player = col.transform.GetComponent<Player>();

            if (Input.GetButtonDown("Fire" + player.id.ToString()))
            {
                if (player.IsContainerEmpty())
                {
                    GameObject obj = Instantiate(materialPrefab, col.transform.position, materialPrefab.transform.rotation);
                    col.gameObject.GetComponent<Player>().PutInContainer(obj);
                    Debug.Log(materialPrefab.name + " inside container, player" + player.id);
                }
                else
                    Debug.Log("Busy hands, player" + player.id);

            }
            
        }
        
    }
}
