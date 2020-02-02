using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScoreData
{
    public List<float> score_saved=new List<float>();
    public ScoreData(List<float> score)
    {
        score_saved = score;
    }
}
