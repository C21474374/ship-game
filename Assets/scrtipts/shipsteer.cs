using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipsteer : MonoBehaviour
{
    public Transform centre;
    public float speed;
    float inputX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        transform.position = centre.position;
        transform.Rotate(Vector3.forward * inputX * speed * Time.deltaTime);
        
    }
}
