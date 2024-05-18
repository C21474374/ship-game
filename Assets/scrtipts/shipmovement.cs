using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipmovement : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float speed = 5f;
    float inputY;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputY = Input.GetAxisRaw("Vertical");
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
   
    private void FixedUpdate()
    {
        if(inputY > 0)
        {
            moveCharacter(movement);
        }
      
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }
   
  
}
