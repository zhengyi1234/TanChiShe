using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyhit : MonoBehaviour
{
   public GameObject root;
    private void Start()
    {
        root = transform.root.gameObject;
        
    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.name == "head")
        {
            GameManager.instance.hit_wall = true;
        }

        
        
    }
}
