﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("TAG: " + collision.collider.gameObject.tag);
        MSMScript.Instance.HitCoin();
        // THIS IS DESTRUCTION.  DO IT LAST.
        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
