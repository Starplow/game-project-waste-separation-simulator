﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject scoreTextObject; //get the scoreText
    public float minusPointsByDestroy = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy the object if it collide with the invisible wall
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        scoreTextObject.GetComponent<ScoreController>().scoreNumber -= minusPointsByDestroy;
    }

}
