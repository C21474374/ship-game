using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject cannonball;
    public float ballforce = 20f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }
    void Shoot()
    {
        GameObject ball = Instantiate(cannonball,firepoint.position,firepoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * ballforce, ForceMode2D.Impulse);
    }
}
