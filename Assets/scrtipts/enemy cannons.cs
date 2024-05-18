using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycannons : MonoBehaviour
{
    private bool hasLineOfSight = false;
    private bool hitenemy = false;
    private bool objects = false;
    private bool hitlos = false;
    public float radius;
    public Transform raypoint;
    private GameObject player;
     public Transform firepoint;
    public GameObject cannonball;
    public float ballforce = 20f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public float rotatespeed;
    
    public Transform originalrotation;
    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
     private void FixedUpdate()
     {
         Vector3 originaldirection = originalrotation.position - transform.position;
        Vector3 direction = player.transform.position - transform.position;

         float distanceFromPlayer = Vector2.Distance(player.transform.position,raypoint.position);
        RaycastHit2D ray = Physics2D.Raycast(raypoint.position , player.transform.position - raypoint.position);
        if(ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            hitenemy = ray.collider.CompareTag("enemy");
            objects = ray.collider.CompareTag("objects");
            hitlos = ray.collider.CompareTag("los");
          
            if((hasLineOfSight) && (distanceFromPlayer<radius))
            {
              
                Debug.DrawRay(raypoint.position , player.transform.position - transform.position, Color.green);
                faceplayer(direction);
                if(Time.time >= nextAttackTime)
                {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
                }

            }
            else if(objects)
            {
                
                 Debug.DrawRay(raypoint.position , player.transform.position - transform.position, Color.green);
            }
          
            else
            {
                faceplayer(originaldirection);
                Debug.DrawRay(raypoint.position , player.transform.position - transform.position, Color.red);
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Shoot()
    {
        GameObject ball = Instantiate(cannonball,firepoint.position,firepoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * ballforce, ForceMode2D.Impulse);
    }
    void faceplayer(Vector3 direction)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRotation,rotatespeed * Time.deltaTime);
          
        }

}