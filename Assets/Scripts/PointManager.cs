using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    public static PointManager instance;

    public GameObject prefab;
    public GameObject points;
    private GameObject[] body;
    private int len = 180;



    // Start is called before the first frame update
  
    void Awake()
    {
        instance = this;


        body = new GameObject[len];
        for (int i=0;i<len;i++)
        {
            float a = Random.Range(-110, 110);
            float b = Random.Range(-140, 140);
            body[i]= Instantiate(prefab,points.transform);
            body[i].transform.position = new Vector3(b,0,a);
            Debug.Log("ok");
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_point()
    {
        float a = Random.Range(-110, 110);
        float b = Random.Range(-140, 140);
        GameObject bodyad = Instantiate(prefab, points.transform);
        bodyad.transform.position = new Vector3(b,0,a);

    }
}
