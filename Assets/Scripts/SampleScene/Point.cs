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
    /// <summary>
    /// 触发
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
       // PointManager.instance.Add_point();

        if (other.name=="head")
        {
            GameManager.instance.num_len++;
            float b = Random.Range(-110, 110);
            float a = Random.Range(-140, 140);
           
            this.transform.position = new Vector3(a, 0, b);
           
        }
        if (other.name=="Enemy")
        {
            other.GetComponent<Enemy>().num_change();

            float b = Random.Range(-110, 110);
            float a = Random.Range(-140, 140);

            this.transform.position = new Vector3(a, 0, b);
        }
    }
}
