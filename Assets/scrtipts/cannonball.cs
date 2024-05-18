using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
