using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainUIManager : MonoBehaviour
{
    public Button Set_button;
    public Button ESC_button;
    public GameObject set_panel;
    public Button Wujin_button;
    public Text text_longest;

    // Start is called before the first frame update
    void Start()
    {
        text_longest.text = PlayerPrefs.GetInt("longest",0).ToString();
        ESC_button.onClick.AddListener(ESC);
        Set_button.onClick.AddListener(Set);
        Wujin_button.onClick.AddListener(wujin);
    }
    /// <summary>
    /// 退出
    /// </summary>
    public void ESC()
    {
        PlayerPrefs.Save();
        Application.Quit();
        
    }
    /// <summary>
    ///设置
    /// </summary>
    public void Set()
    {
        set_panel.SetActive(true);
    }
    /// <summary>
    /// 无尽模式
    /// </summary>
    public void wujin()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

}
