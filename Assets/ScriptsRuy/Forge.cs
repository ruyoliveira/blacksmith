using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    public GameObject productPrefab;
    public int sourceObjId;
    public Dictionary<int, GameObject> forgingRecipes;
    public GameObject[] forgedPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        forgingRecipes = new Dictionary<int, GameObject>();
        forgingRecipes.Add(0,forgedPrefabs[0]);
        forgingRecipes.Add(1, forgedPrefabs[1]);
        forgingRecipes.Add(2, forgedPrefabs[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.transform.tag == "Player")
        {
            Player player = col.transform.GetComponent<Player>();
        
            if (Input.GetButtonDown("Fire"+player.id.ToString()))
            {
                GameObject givenSourceObj = player.CheckInsideContainer();
                if (givenSourceObj != null)
                {
                    GameObject forgeResult = TryForge(givenSourceObj.GetComponent<Id>().id);
                    if (forgeResult!= null)
                    {
                        Destroy(givenSourceObj);
                        GameObject obj = Instantiate(forgeResult, col.transform.position, forgeResult.transform.rotation);
                        col.gameObject.GetComponent<Player>().PutInContainer(obj);

                    }
                }
                Debug.Log(this.transform.name);
            }
        
        }
        


    }
    public GameObject TryForge(int sourceObjId)
    {
        if (forgingRecipes.ContainsKey(sourceObjId))
            return forgingRecipes[sourceObjId];
        else
            return (GameObject)null;
    }
}
