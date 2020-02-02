using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jobs : MonoBehaviour
{
    public GameObject scoreObject;
    public GameObject[] orderPrefabs;
    public float newOrderInterval = 15.0f;

    public List<int> orders;
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        orders = new List<int>();
        score = scoreObject.GetComponent<Score>();
        InvokeRepeating("CreateOrder", 1.0f, newOrderInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // New orders
    void CreateOrder()
    {
        int randomOrderNumber = Random.Range(0, 3);
        Debug.Log(randomOrderNumber);
        orders.Add((randomOrderNumber + 1) * 100 );
        GameObject order = Instantiate(orderPrefabs[randomOrderNumber], transform.position, transform.rotation, transform);
    }

    // Delivered Order
    public bool CompleteOrder(GameObject product)
    {
        int productId = product.GetComponent<Id>().id;
        // Check if there's a order pending for this product
        if (orders.Contains(productId)) 
        {
            score.OrderCompleted();
            RemoveOrder(orders.IndexOf(productId));
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MissedOrder(int orderIndex)
    {
        score.OrderMissed();
        RemoveOrder(orderIndex);
    }

    public void RemoveOrder(int orderIndex)
    {
        int completedOrderIndex = orders.LastIndexOf(orderIndex);
        orders.RemoveAt(orderIndex);
        Destroy(transform.GetChild(orderIndex).gameObject);
    }
}
