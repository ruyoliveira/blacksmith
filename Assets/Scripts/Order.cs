using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public GameObject orderPrefab;
    public float newOrderInterval = 15.0f;

    public List<int> orders; 

    // Start is called before the first frame update
    void Start()
    {
        orders = new List<int>();
        InvokeRepeating("CreateOrder", 1.0f, newOrderInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // New orders
    void CreateOrder()
    {
        orders.Add((Random.Range(0, 1) + 1) * 100 );
        GameObject obj = Instantiate(orderPrefab, transform.position, transform.rotation, transform);
    }

    // Delivered Order
    public bool CompleteOrder(GameObject product)
    {
        int productId = product.GetComponent<Id>().id;
        // Check if there's a order pending for this product
        if (orders.Contains(productId)) 
        {
            RemoveOrder(orders.LastIndexOf(productId));
            return true;
        }
        else
        {
            return false;
        }
    }

    void RemoveOrder(int orderIndex)
    {
        int completedOrderIndex = orders.LastIndexOf(orderIndex);
        orders.RemoveAt(orderIndex);
        Destroy(transform.GetChild(orderIndex).gameObject);
    }
}
