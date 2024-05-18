using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolship : MonoBehaviour
{
    public Transform[] moveSpots;
    private Rigidbody2D rb;

    public float speed;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    public float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = moveSpots[randomSpot].position - transform.position;
        /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();*/
        facedirection(direction);

       // transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,moveSpots[randomSpot].position) < 0.5f)
        {
            if(waitTime <= 0)
            {
                
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                
                waitTime -= Time.deltaTime;
            }
        }
    }
        public void facedirection(Vector3 direction)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRotation,rotatespeed * Time.deltaTime);
            if(desiredRotation == transform.rotation)
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            }
            else{
                
            }
        }
    
}
