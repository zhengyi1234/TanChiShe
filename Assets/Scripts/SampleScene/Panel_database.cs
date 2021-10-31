using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Panel_database : MonoBehaviour
{
    public Text Finallen_num;
    public Text Kill_Score;
    public Button button;
    public Button back_button;
    public GameObject img;
    private int num_len;
    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(false);
        num_len = GameManager.instance.num_len + 9;
        button.onClick.AddListener(
          NoShow
            
            ) ;
        back_button.onClick.AddListener(
         Back

           );

        Finallen_num.text = (GameManager.instance.num_len + 9).ToString();
        Kill_Score.text = GameManager.instance.kill.ToString();
        if (num_len > PlayerPrefs.GetInt("longest"))
        {
            Longest_change();
            img.SetActive(true);
        }
    }

 

    public void NoShow()
    {
        SceneManager.LoadScene(1);

        GameManager.instance.hit_wall = false;
        PlayerPrefs.Save();
    }
    public void Back()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
        
    }
    public void Longest_change()
    {
        PlayerPrefs.SetInt("longest", num_len);
    }
}
