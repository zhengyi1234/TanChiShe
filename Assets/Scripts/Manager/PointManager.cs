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
            float r = 0;
            float g = 0;
            float c = 0;
            float v = Random.Range(0, 3);
            if (v<1)
            {
                r = 1;
                g = 0;
                c = 0;
            }
            else if (v<2)
            {
                r = 0;
                g = 1;
                c = 0;
            }
            else
            {
                r = 0;
                g = 0;
                c = 1;
            }
            
            body[i].GetComponent<Renderer>().material.color = new Color(r,g,c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_point()
    {
        float b = Random.Range(-110, 110);
        float a = Random.Range(-140, 140);
        GameObject bodyad = Instantiate(prefab, points.transform);
        bodyad.transform.position = new Vector3(a,0,b);
        float r = 0;
        float g = 0;
        float c = 0;
        float v = Random.Range(0, 3);
        if (v < 1)
        {
            r = 1;
            g = 0;
            c = 0;
        }
        else if (v < 2)
        {
            r = 0;
            g = 1;
            c = 0;
        }
        else
        {
            r = 0;
            g = 0;
            c = 1;
        }
        bodyad.GetComponent<Renderer>().material.color = new Color(r, g, c);

    }
    public void Add_point_Enmey(float a,float b,int num_len)
    {


        prefab.transform.localScale = new Vector3(prefab.transform.localScale.x , prefab.transform.localScale.y, prefab.transform.localScale.z );
        GameObject bodyad = Instantiate(prefab, points.transform);
        bodyad.transform.position = new Vector3(a, 0, b);
    }
}
