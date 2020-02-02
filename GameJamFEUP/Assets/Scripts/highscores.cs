using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class highscores : MonoBehaviour
{
    public List<float> scores = new List<float>();
    public ScoreData loaded;

    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        loaded = Save_system.LoadPlayer(scores);
        if (loaded.score_saved != null)
            scores = loaded.score_saved;
    }

    public void save_new(float n)
    {
        if (n != 0)
        {
            scores.Add(n);
            scores.Sort();
            scores.Reverse();
            if (scores.Count > 4)
                scores.RemoveAt(scores.Count - 1);
            Save_system.SavePlayer(scores);
        }
    }

    public void Delete_all()
    {
        Save_system.Destroy_saves();
        scores.Clear();
    }
}
