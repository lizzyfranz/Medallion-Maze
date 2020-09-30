using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rbody;
    public int maxSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = maxSpeed * Input.GetAxis("Horizontal");
        float y = maxSpeed * Input.GetAxis("Vertical");
        rbody.velocity = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we hit a badguy, spawn a new version of ourselves from MSM and 
        if (collision.collider.gameObject.tag.Equals("Enemy"))
        {
            MSMScript.Instance.SpawnPlayer();
            MSMScript.Instance.PlayerDied();
            Destroy(gameObject);
        }
    }
}
