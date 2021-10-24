using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //引用
    public Text text_len;
    
    public Text text_kill;
    public GameObject canv;

    // Start is called before the first frame update
    void Start()
    {
        text_len.text = 15.ToString();
        canv.SetActive(false);
      
        

    }

    // Update is called once per frame
    void Update()
    {
          len_add();
        if (GameManager.instance.hit_wall)
        {
            ShowCan();
        }
        else
        {
            canv.SetActive(false);
        }
    }
    /// <summary>
    /// 长度增加
    /// </summary>
    public void len_add()
    {
        text_len.text = (GameManager.instance.num_len+9).ToString();
    }
    /// <summary>
    /// 显示成绩界面
    /// </summary>
    public void ShowCan()
    {
        canv.SetActive(true);
       
    }

  
}
