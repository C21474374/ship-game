using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightcannon : MonoBehaviour
{
 public float speed = 3f;
    float rot;
   
    bool qrot;
    bool erot;
    private GameObject rmaxrot;
    private bool hasLineOfSight = false;
    private bool hitenemy = false;
    private bool objects = false;
    public Transform raypoint;
    // Start is called before the first frame update
    void Start()
    {
        rmaxrot = GameObject.FindGameObjectWithTag("rmaxrot");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            if (erot == true)
            {
                rot = 0;
                erot = false;
            }
            qrot = true;
            
            rot = -1;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            if(qrot == true)
            {
                rot = 0;
                qrot = false;
            }
            erot = true;
            rot = +1;
        }
        else
        {
            rot = 0;
        }
         transform.Rotate(Vector3.forward * rot * speed * Time.deltaTime);

    }
     private void FixedUpdate()
     {
        RaycastHit2D ray = Physics2D.Raycast(raypoint.position , rmaxrot.transform.position - raypoint.position);
        if(ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("rmaxrot");
            hitenemy = ray.collider.CompareTag("enemy");
            objects = ray.collider.CompareTag("objects");
          
            if(hasLineOfSight || hitenemy || objects)
            {
                Debug.DrawRay(raypoint.position , rmaxrot.transform.position - raypoint.position, Color.green);

            }
            else
            {
                if(qrot == true)
                {
                transform.Rotate(Vector3.forward * 1 * speed * Time.deltaTime);

                }
                else if(erot == true)
                {
                    transform.Rotate(Vector3.forward * -1 * speed * Time.deltaTime);
                }
                Debug.DrawRay(raypoint.position , rmaxrot.transform.position - raypoint.position, Color.red);
            }
        }
     }
      
}
