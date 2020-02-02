using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilStation : Station
{
    public GameObject productPrefab;
    public int sourceObjId;
    public Dictionary<int, GameObject> recipes;
    public GameObject[] productPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        this.recipes = new Dictionary<int, GameObject>();
        this.recipes.Add(10, productPrefabs[0]);
        this.recipes.Add(20, productPrefabs[1]);
        this.recipes.Add(30, productPrefabs[2]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject TryRecipe(int sourceObjId)
    {
        if (recipes.ContainsKey(sourceObjId))
            return recipes[sourceObjId];
        else
            return (GameObject)null;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            Player player = col.transform.GetComponent<Player>();

            if (Input.GetButtonDown("Fire" + player.id.ToString()))
            {

                GameObject givenSourceObj = player.CheckInsideContainer();
                if (givenSourceObj != null)
                {
                    GameObject recipeResult = TryRecipe(givenSourceObj.GetComponent<Id>().id);
                    if (recipeResult != null)
                    {
                        player.DestroyObjectInContainer();
                        GameObject obj = Instantiate(recipeResult, col.transform.position, recipeResult.transform.rotation);
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
