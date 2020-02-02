using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Order : MonoBehaviour
{
    public int productId;
    public int timeToCompleteOrder = 20;
    public GameObject textObject;

    private TextMeshProUGUI textMeshPro;
    private Jobs orders;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        orders = transform.parent.GetComponent<Jobs>();

        InvokeRepeating("Countdown", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Countdown()
    {
        if (timeToCompleteOrder < 1)
        {
            orders.RemoveOrder(transform.GetSiblingIndex());
        }
        else
        {
            textMeshPro.SetText(timeToCompleteOrder.ToString());
            timeToCompleteOrder -= 1;
        }
    }
}
