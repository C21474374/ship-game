using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centering : MonoBehaviour
{
    public Transform centre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = centre.position;
         transform.rotation =centre.rotation;
    }
}
