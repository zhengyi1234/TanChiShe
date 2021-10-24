using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //引用
    public GameObject bodyPrefab;
    public GameObject head;
    private Enemy enemy;

    //属性值
    private int length;//长度

    private Vector3 up = new Vector3(0, 0, 1);
    private Vector3 direction;
    private float timer=4;
    public float threshold=0.1f;
    private Vector3 change;
    public float rotSpeed = 40;
    public int size = 1;
    public int speed = 1;

    private float Timer_ai;
    private bool hv_es=true;
    public int num_len=1;
    public bool tags = false;
    // Start is called before the first frame update
    void Start()
    {
        length = 3;
        direction = up;
        change = up;
        for (int n = 0; n < length; n++)
        {
            GameObject body = Instantiate(bodyPrefab, transform);
            body.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n + size));

        }
        enemy = head.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        num_len = enemy.num;


        if (timer > threshold)
        {
            float h = Random.Range(-1.0f, 1.0f);
            float v = Random.Range(-1.0f, 1.0f);

            if (Timer_ai < 2)
            {
                h = 0;
                v = 0;
                hv_es = false;

            }
            else
            {
                Timer_ai = 0;
            }
            Move_Rotate(h, v);

        }
        timer += Time.deltaTime;
        Timer_ai += Time.deltaTime;
        Len_manager();

    }

    private void FixedUpdate()
    {
      
    }
    public void Move_Rotate(float h,float v)
    {
        change = new Vector3(h, 0, v);

        for (int n = length - 1; n > 0; n--)
        {
            transform.GetChild(n).position = transform.GetChild(n - 1).position;
            transform.GetChild(n).rotation = transform.GetChild(n - 1).rotation;
        }
        //改变位置
        transform.GetChild(0).transform.position = head.transform.position;
        //  head.transform.position += change;

        head.transform.Translate(Vector3.forward * speed, Space.Self);

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
        if ((num_len % 3) == 0 && tags)
        {
          
            Length_add();
            tags = false;
        }
        else if ((num_len % 3) != 0)
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



    public void Scale()
    {
        if (num_len >= 40 && num_len < 160 && ((num_len % 20) == 0))
        {
            int index = num_len / 20;

            size = index;

            head.transform.localScale = new Vector3(2 + size, 1, 2 + size);


            for (int n = length - 1; n >= 0; n--)
            {
                transform.GetChild(n).localScale = new Vector3(2 + size, 1, 2 + size);


            }

        }

    }


    public void Change_num()
    {
        num_len++;
    }
}
