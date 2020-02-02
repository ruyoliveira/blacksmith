using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public GameObject jobs;
    private Jobs orders;

    // Start is called before the first frame update
    void Start()
    {
        orders = jobs.GetComponent<Jobs>();
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
                GameObject product = player.CheckInsideContainer();
                if (product != null)
                {
                    if (orders.CompleteOrder(product))
                    {
                        player.DestroyObjectInContainer();
                    }
                }
            }
        }
    }
}
