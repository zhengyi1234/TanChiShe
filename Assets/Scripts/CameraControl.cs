using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject head;
    public float timer;
    public float threold=0.5f;
    private Vector3 cameraVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
      

        transform.position = new Vector3(head.transform.position.x, transform.position.y, head.transform.position.z);
       
    }
  
}
