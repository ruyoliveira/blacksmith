using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int totalScore = 0;
    public int pointsPerOrderCompleted = 10;
    public int pointsPerOrderMissed = -15;

    private TextMeshProUGUI textMeshPro;


    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = transform.GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateText()
    {
        textMeshPro.SetText("Score: " + totalScore);
    }

    public void OrderCompleted(int timeLeft)
    {
        totalScore += (pointsPerOrderCompleted + timeLeft);
        UpdateText();
    }

    public void OrderMissed()
    {
        totalScore += pointsPerOrderMissed;
        UpdateText();
    }
}
