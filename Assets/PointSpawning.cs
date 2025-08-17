using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawning : MonoBehaviour
{
    int frames = 0;
    public bool point = false;
    public GameObject pointObject;
    void Start()
    {
           
    }

    void FixedUpdate()
    {
        float x = Random.Range(-35, 35);
        float z = Random.Range(-35, 35);
        
        if(frames >= 50)
        {
            if (point != true)
            {
                Instantiate(pointObject, new Vector3(x, 6, z), Quaternion.Euler(0, 0, 0));
                point = true;
            }
            frames = 0;
        }
        frames++;
    }

}
