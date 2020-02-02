using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class grab_scores : MonoBehaviour
{
    public highscores hs;
    public TextMeshProUGUI caixa;
    public List<float> scores = new List<float>();
    // Start is called before the first frame update
    private void Start()
    {
        caixa = gameObject.GetComponent<TextMeshProUGUI>();
        caixa.text = "";
        if (FindObjectOfType<highscores>() == null)
        {
            caixa.text = "Nao ha objeto highscores";
        }
        else
        if (hs == null)
        {
            hs = FindObjectOfType<highscores>();
            scores = hs.scores;
        }

        if (caixa.text == "")
            Display();

    }

    public void Display()
    {
        Debug.Log("TESTE");
        caixa.text = "";
        int index = 0;
        if (FindObjectOfType<highscores>()!=null&&hs == null)
        {
            hs = FindObjectOfType<highscores>();
            scores = hs.scores;
        }
        if (hs != null)
        {
            scores = hs.scores;
            foreach (float este in hs.scores)
            {
                index++;
                switch (index)
                {
                    case 1:
                        caixa.text += "1st " + este.ToString("F2") + "\n";
                        break;
                    case 2:
                        caixa.text += "2nd " + este.ToString("F2") + "\n";
                        break;
                    case 3:
                        caixa.text += "3rd " + este.ToString("F2") + "\n";
                        break;
                    default:
                        caixa.text += index + "th " + este.ToString("F2") + "\n";
                        break;
                }
            }
        }
    }


}
