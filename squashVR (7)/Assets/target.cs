using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class target : MonoBehaviour
{
    int update = 0;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(update >= 50) {
            GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            update = 0;
        }
        update++;

    }

    private void OnCollisionEnter(Collision other)
        {
        GetComponent<Renderer>().material.color = new Color(0, 128, 0);
        int x = rnd.Next(0, 40);
        int y = rnd.Next(18, 32);
        transform.position = new Vector3(x, y, transform.position.z);
        update = 0;

    }
}
