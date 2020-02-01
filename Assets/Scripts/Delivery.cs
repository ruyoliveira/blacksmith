using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public GameObject jobs;
    private Order orders;

    // Start is called before the first frame update
    void Start()
    {
        orders = jobs.GetComponent<Order>();
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
