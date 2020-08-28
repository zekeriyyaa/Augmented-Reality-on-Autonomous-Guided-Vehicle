using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
   
    public GameObject line;
    private float[,] path = new float[5,2];
    void Start()
    {
        path[0, 0] = 0.0F;
        path[0, 1] = 0.0F;
        path[1, 0] = 1.0F;
        path[1, 1] = 0.0F;
        path[2, 0] = 1.0F;
        path[2, 1] = 1.0F;
        path[3, 0] = 0.0F;
        path[3, 1] = 1.0F;
        path[4, 0] = 4.0F;
        path[4, 1] = 4.0F;

        pathUpdate();
    }

    void Update()
    {
        
    }

    void pathUpdate()
    {
        int len = 5;
        if (len > 1)
        {
            for (int i = 0; i < len; i++)
            {

                GameObject newLine = (Instantiate(line, new Vector3((path[i, 0] + path[(i + 1) % len, 0]) / 2, 0, (path[i, 1] + path[(i + 1) % len, 1]) / 2), Quaternion.identity)) as GameObject;
                float degree = -Mathf.Atan2(path[(i + 1) % len, 0] - path[i, 0], path[(i + 1) % len, 1] - path[i, 1]) * Mathf.Rad2Deg;
                newLine.transform.eulerAngles = new Vector3(0, 0, degree);
                newLine.transform.localScale = new Vector3(Vector3.Distance(new Vector3(path[i, 0], 0, path[i, 1]), new Vector3(path[(i + 1) % len, 0], 0, path[(i + 1) % len, 1])) + 0.2F, 0.2F, 1);
            }
        }
    }
}
