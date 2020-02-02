using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForgeDelay : Station
{
    public Dictionary<int, GameObject> recipes;
    public GameObject[] productPrefabs;

    public float timer;
    public float jobDuration;
    GameObject recipeResult;
    GameObject producedProduct;
    public GameObject hudParent;
    public Image fillingImage;
    public Image doneIcon;

    // Start is called before the first frame update
    void Start()
    {
        this.recipes = new Dictionary<int, GameObject>();
        this.recipes.Add(1, productPrefabs[0]);
        this.recipes.Add(2, productPrefabs[1]);
        this.recipes.Add(3, productPrefabs[2]);
    }

    // Update is called once per frame
    void Update()
    {
        switch(status)
        {
            case StationStatus.Working:
                if (timer <= jobDuration)
                    timer += Time.deltaTime;
                else
                {
                    status = StationStatus.Done;
                    producedProduct = Instantiate(recipeResult, transform.position + Vector3.up, recipeResult.transform.rotation);

                    timer = 0.0f;
                }
                    

                break;

        }
        UpdateHUD();
    }
    public GameObject TryRecipe(int sourceObjId)
    {
        if (recipes.ContainsKey(sourceObjId))
            return recipes[sourceObjId];
        else
            return (GameObject)null;
    }

    public  void UpdateHUD()
    {
        if(status == StationStatus.Idle)
        {
            hudParent.SetActive(false);
            doneIcon.gameObject.SetActive(false);

        }
        else if (status == StationStatus.Working)
        {
            if (!hudParent.activeInHierarchy) 
                hudParent.SetActive(true);
            fillingImage.fillAmount = timer / jobDuration;
        }
        else if (status == StationStatus.Done)
        {
            hudParent.SetActive(false);
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            Player player = col.transform.GetComponent<Player>();

            if (Input.GetButtonDown("Fire" + player.id.ToString()))
            {
                if (status == StationStatus.Idle)
                {
                    GameObject givenSourceObj = player.CheckInsideContainer();
                    if (givenSourceObj != null)
                    {
                        recipeResult = TryRecipe(givenSourceObj.GetComponent<Id>().id);
                        if (recipeResult != null)
                        {
                            player.DestroyObjectInContainer();
                            status = StationStatus.Working;

                        }
                        else Debug.Log("Wrong source input, Player" + player.id);
                    }
                    else
                    {
                        Debug.Log("Empty hands, Player" + player.id);
                    }
                }
                if (status == StationStatus.Done)
                {
                    if (player.IsContainerEmpty())
                    {
                        col.gameObject.GetComponent<Player>().PutInContainer(producedProduct);
                        status = StationStatus.Idle;

                    }

                }
            }
        }

    }

}
