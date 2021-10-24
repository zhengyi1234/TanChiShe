using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControll : MonoBehaviour
{
    //引用
    public GameObject bodyPrefab;
    public GameObject head;
 

    //属性值
    private int length;//长度
    
    private Vector3 up = new Vector3(0,0,1);
    private Vector3 direction;
    private float timer;
    private Vector3 change;
    public float rotSpeed = 60;
    public int size=1;
    public int speed = 1;
    private bool tags = true;
    private bool hit_wall = false;
    private Vector3 head_init;

   

    // Start is called before the first frame update
    void Start()
    {
        head_init = head.transform.position;
        length = 3;
        direction = up;
        change = up;
        for (int n=0;n<length;n++)
        {
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(head.transform.position.x,head.transform.position.y,head.transform.position.z-(n+size)) ;

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //撞墙了
        if (GameManager.instance.hit_wall)
        {
            size = 1;
            hit_wall = true;
            if (length>0)
            {
                for (int n = length - 1; n >= 0; n--)
                {
                    Destroy(transform.GetChild(n).gameObject);
                    length--;
                }
            }
            
          
            return;
        }
        if (!GameManager.instance.hit_wall&&hit_wall)
        {
            GameManager.instance.num_len = 1;
            Init_player();
            hit_wall = false;
        }
        

        Len_manager();
     

        if (timer > GameManager.instance.threshold)
        {
            Move_Rotate();

        }
        timer += Time.deltaTime;

    }
    /// <summary>
    /// 移动
    /// </summary>
    public void Move_Rotate()
    {
        float h = JoystickPanel.instance.x;
        float v = JoystickPanel.instance.y;

      

        change = new Vector3(h , 0, v );

        for (int n = length - 1; n > 0; n--)
        {
            transform.GetChild(n).position = transform.GetChild(n - 1).position;
            transform.GetChild(n).rotation = transform.GetChild(n - 1).rotation;
        }
        //改变位置
        transform.GetChild(0).transform.position = head.transform.position;
        //  head.transform.position += change;

        head.transform.Translate(Vector3.forward*speed, Space.Self);

        //改变角度
        Quaternion lookRot = Quaternion.LookRotation(direction);
        head.transform.rotation = Quaternion.Slerp(head.transform.rotation, lookRot, Mathf.Clamp01(rotSpeed * Time.deltaTime));
        transform.GetChild(0).transform.rotation = head.transform.rotation;
        //判断如果没有操作
        if (v == 0 && h == 0)
        {
            head.transform.Translate(direction, Space.Self);
        }
        else
        {
            direction = change;
        }
        timer = 0;
    }

    /// <summary>
    /// 长度管理 吃五个食物增加长度。
    /// </summary>
    public void Len_manager()
    {
        Scale();
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
        GameObject body = Instantiate(bodyPrefab, transform);
        body.transform.position = transform.GetChild(length - 1).position;
        body.transform.localScale = new Vector3(2 + size, 1, 2 + size);
        length++;
        
    }


    public void Init_player()
    {
        head.transform.localScale = new Vector3(2 + size, 1, 2 + size);
        length = 3;
        direction = up;
        change = up;
        head.transform.position = head_init;
        for (int n = 0; n < length; n++)
        {
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n + size));

        }

    }
    public void Scale()
    {
        if (GameManager.instance.num_len>=40&& GameManager.instance.num_len<160&& ((GameManager.instance.num_len%20)==0))
        {
            int index = GameManager.instance.num_len / 20;

            size = index;
            
            head.transform.localScale = new Vector3(2+size, 1, 2+size);

         
            for (int n = length - 1; n >=0; n--)
            {
                transform.GetChild(n).localScale= new Vector3(2 + size, 1, 2 + size); 
               

            }

        }
        
    }
}
