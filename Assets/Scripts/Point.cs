using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private GameObject head;
    private float distance;
    public float movespeed=5f;
    void Start()
    {
        head = GameObject.Find("head");
    }

    void Update()
    {
        
        distance = Vector3.Distance(this.transform.position,head.transform.position);
       

        if (distance<=6)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, head.transform.position, Time.deltaTime * movespeed);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PointManager.instance.Add_point();

        if (other.name=="head")
        {
            GameManager.instance.num_len++;
            Destroy(gameObject);
        }
        if (other.name=="Enemy")
        {
            other.GetComponent<Enemy>().num_change();
            Destroy(gameObject);
        }
    }
}
