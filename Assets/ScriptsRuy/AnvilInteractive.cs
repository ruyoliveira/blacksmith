using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnvilInteractive : Station
{
    
    public Dictionary<int, GameObject> recipes;
    public int[] sourceIds;
    public GameObject[] productPrefabs;

    public float gauge;
    public float incrementPerHit;
    GameObject recipeResult;
    GameObject producedProduct;
    public GameObject hudParent;
    public Image fillingImage;
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        this.recipes = new Dictionary<int, GameObject>();
        this.recipes.Add(sourceIds[0], productPrefabs[0]);
        this.recipes.Add(sourceIds[1], productPrefabs[1]);
        this.recipes.Add(sourceIds[2], productPrefabs[2]);
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case StationStatus.Working:



                gauge -= Time.deltaTime * incrementPerHit;
                gauge= gauge > 0.0f ? gauge:0.0f;
                if (gauge >= 1.0f)
                {
                    status = StationStatus.Done;
                    producedProduct = Instantiate(recipeResult, transform.position + Vector3.up, recipeResult.transform.rotation);

                    gauge = 0.0f;
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

        }
        else if (status == StationStatus.Working)
        {
            if (!hudParent.activeInHierarchy) 
                hudParent.SetActive(true);
            fillingImage.fillAmount =  gauge;
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
                else if (status == StationStatus.Working)
                {
                    _anim.SetTrigger("Hit");
                    gauge += incrementPerHit;
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
            if (Input.GetButtonUp("Fire" + player.id.ToString()))
            {
                if (status == StationStatus.Working)
                {

                    gauge += incrementPerHit / 4;
                }
            }
        }

    }

}
