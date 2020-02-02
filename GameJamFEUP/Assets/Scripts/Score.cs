using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI score_text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (score_text == null)
        {
            score_text = gameObject.GetComponent<TextMeshProUGUI>();
        }
        score_text.text = "0";
    }
    
    public void AddScore(float s)
    {
        score += (int)(s*100);
        
        score_text.text = score.ToString("F0");
    }
}
