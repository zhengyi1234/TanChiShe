using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControll : MonoBehaviour
{
    //引用
    public GameObject bodyPrefab;
    public GameObject head;
    public GameObject enmeybody;

    //属性值
    private int length;//长度
    private Vector3 up = new Vector3(0,0,1);
    private Vector3 direction;
    private float timer;
    private Vector3 change;
    public float rotSpeed = 60;
    public int size=1;
    private int speed = 20;
    private bool tags = true;
    private bool hit_wall = false;
    private Vector3 head_init;
    private float timer_snake=50f;

    public int positionlength = 5; 

    // Start is called before the first frame update
    void Start()
    {
        head_init = head.transform.position;
        length = 3;
        direction = up;
        change = up;
        for (int n=0;n<length;n++)
        {
            for (int i=0;i<3;i++)
            {
                GameObject bodyEnemy = Instantiate(enmeybody, transform);
                bodyEnemy.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n * 3 + size));
            }
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(head.transform.position.x,head.transform.position.y,head.transform.position.z-(n*3+size)) ;          
        }           
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.act)
        {
            speed = 30;
        }
        else
        {
            speed = 20;
        }
        //撞墙了
        if (GameManager.instance.hit_wall)
        {
            size = 1;
            hit_wall = true;
            if (length > 0)
            {
                for (int n = length - 1; n >= 0; n--)
                {
                    Destroy(transform.GetChild(n).gameObject);
                    length--;
                }
            }
            return;
        }
        Len_manager();
        Move_Rotate();
    }

    /// <summary>
    /// 移动
    /// </summary>
    public void Move_Rotate()
    {
        float h = JoystickPanel.instance.x;
        float v = JoystickPanel.instance.y;


        change = new Vector3(h , 0, v );

        for (int n = length+9-1; n > 0; n--)
        {     
            transform.GetChild(n).position = transform.GetChild(n - 1).position;       
            transform.GetChild(n).rotation = transform.GetChild(n - 1).rotation;
        }
        float distance = Vector3.Distance(direction,change);
        //改变位置
        transform.GetChild(0).transform.position = head.transform.transform.position;
        head.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        //改变角度
        Quaternion lookRot = Quaternion.LookRotation(direction);
        head.transform.rotation = Quaternion.Slerp(head.transform.rotation, lookRot, Mathf.Clamp01(rotSpeed * Time.deltaTime));
        transform.GetChild(0).transform.rotation = head.transform.rotation;
        //判断如果没有操作
        if (v == 0 && h == 0)
        {
            head.transform.Translate(direction * speed * Time.deltaTime, Space.Self);
        }
        else
        {
            direction = change;
        }
        timer = 0;
    }
    /// <summary>
    /// 长度管理 吃三个个食物增加长度。
    /// </summary>
    public void Len_manager()
    {
        //Scale();
        if ((GameManager.instance.num_len % 3) == 0 && tags)
        {
           
            Length_add();
            tags = false;
        }
        else if ((GameManager.instance.num_len % 3) != 0)
        {
            tags = true;
        }
        else
        {
            return;
        }   
    }

    /// <summary>
    /// 增加身体
    /// </summary>
    public void Length_add()
    {
         
        for (int i = 0; i < 3; i++)
        {
            GameObject bodyEnemy = Instantiate(enmeybody, transform);
            bodyEnemy.transform.position = transform.GetChild(length - 1).position;
            length+=1;
        }

        GameObject body = Instantiate(bodyPrefab, transform);

        body.transform.position = transform.GetChild(length - 1).position;

       // body.transform.localScale = transform.GetChild(length - 1).localScale;
        length++;
        
    }
    public void Init_player()
    {
        head.transform.localScale = new Vector3(2 + size, 1, 2 + size);
        length = 3;
        direction = up;
        change = up;
        head.transform.position = head_init;

        //for (int n = 0; n < length; n++)
        //{
        //    GameObject body = Instantiate(bodyPrefab, transform);
        //    body.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n * 3 + size));

        //}

        for (int n = 0; n < length; n++)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject bodyEnemy = Instantiate(enmeybody, transform);
                bodyEnemy.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n * 3 + size));
            }
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n * 3 + size));


        }






    }
    public void Scale()
    {
        if (GameManager.instance.num_len>=40&& GameManager.instance.num_len<160&& ((GameManager.instance.num_len%20)==0))
        {
            int index = GameManager.instance.num_len / 20;

            size = index;
            
            head.transform.localScale = new Vector3(2+size, 1, 2+size);

         
            for (int n = length - 1+9; n >=0; n--)
            {
                transform.GetChild(n).localScale= new Vector3(2 + size, 1, 2 + size); 
               

            }

        }
        
    }
}
