using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    
    public static EnemyManager instance;
    public GameObject player;
    public GameObject EnemyPrefab;
    //public GameObject points;
    public GameObject[] body;
    private int len = 19;
    public Text[] num;
    public Text player_grade;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        body = new GameObject[len+1];
        for (int i = 0; i < len; i++)
        {
            float a = Random.Range(-110, 110);
            float b = Random.Range(-140, 140);
            body[i] = Instantiate(EnemyPrefab);
            body[i].transform.position = new Vector3(b, 0, a);
            string name = "敌人" + i + "号";
            body[i].name = name;
           
        }
        body[len] = player;
        
      
    }
    private void Update()
    {
       
    }
    private void LateUpdate()
    {
        Sort();
        UpdateList();
        UpdatePlayer();
    }


    private void Sort()
    {
        for (int i = 0; i < body.Length; i++)
        {
            for (int j = i + 1; j < body.Length; j++)
            {

                int lengthOne = (body[i].name == "player" ? GameManager.instance.num_len: body[i].transform.GetChild(0).GetComponent<Enemy>().num); 
                int lengthTwo = (body[j].name == "player" ? GameManager.instance.num_len : body[j].transform.GetChild(0).GetComponent<Enemy>().num); 
                if (lengthOne < lengthTwo)
                {
                    var temp = body[i];
                    body[i] = body[j];
                    body[j] = temp;
                }
            }
        }
    }

    private void UpdateList()
    {
        for (int i=0;i<num.Length;i++)
        {
            num[i].text = body[i].name;
        }
       
    }
    private void UpdatePlayer()
    {
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i].name == "player")
            {
                player_grade.text = (i +1).ToString();
            }
        }
    }


}
