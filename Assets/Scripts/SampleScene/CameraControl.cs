using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject head;
    public float timer=500f;
    public float threold=0.5f;
    private AudioSource adusouce;
    // Start is called before the first frame update
    void Start()
    {
        int music_on_off = PlayerPrefs.GetInt("music_on/off");
        adusouce = this.GetComponent<AudioSource>();
        if (music_on_off==1)
        {
            adusouce.Stop();
        }
        else
        {
            adusouce.Play();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
      var cameraVelocity = Vector3.zero;

      // transform.position = new Vector3(head.transform.position.x, transform.position.y, head.transform.position.z);
       transform.position = Vector3.SmoothDamp(transform.position, new Vector3(head.transform.position.x, transform.position.y, head.transform.position.z),  ref cameraVelocity,timer);
    }
  
}
