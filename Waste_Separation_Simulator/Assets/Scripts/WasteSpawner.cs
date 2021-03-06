﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WasteSpawner : MonoBehaviour
{
    public List<GameObject> wasteList;
    public GameObject WasteHolder;
    public float Timer;
    public float waitSecondsToSpawn = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            int prefabIndex = UnityEngine.Random.Range(0, 15);
            GameObject myObject = Instantiate(wasteList[prefabIndex], transform.position, Quaternion.identity);
            myObject.transform.SetParent(WasteHolder.transform);
            Timer = waitSecondsToSpawn;
        }
 
    }

}



