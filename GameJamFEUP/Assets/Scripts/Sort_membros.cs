using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_membros : MonoBehaviour
{
    public List<Transform> spawns;
    public List<GameObject> membros;
    public List<GameObject> obstacles = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        int obspicked = Random.Range(0, obstacles.Count);
        int mem_picked = Random.Range(0, membros.Count);
        foreach (GameObject este in membros)
        {
            int p = Random.Range(0, spawns.Count);

            if (spawns.Count-1 == mem_picked)
            {
                GameObject ob = obstacles[obspicked];
                ob = Instantiate(ob, new Vector2(0, 0), Quaternion.identity);
                ob.transform.parent = este.transform;
                GameObject child = este.transform.GetChild(0).gameObject;
                if (ob == child)
                {
                    child = este.transform.GetChild(1).gameObject;
                }
                ob.transform.position = child.transform.position;
                ob.transform.eulerAngles = new Vector3(0, 0, 90);
                Destroy(child);
            }

            Destroy(este.transform.GetChild(0).gameObject);
            este.transform.position = spawns[p].position;
            Destroy(spawns[p].gameObject);
            spawns.RemoveAt(p);
        }
    }

}
