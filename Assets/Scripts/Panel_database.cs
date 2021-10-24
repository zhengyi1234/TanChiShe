using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_database : MonoBehaviour
{
    public Text Finallen_num;
    public Text Kill_Score;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(
          NoShow
            
            ) ;
    }

    // Update is called once per frame
    void Update()
    {
        Finallen_num.text = (GameManager.instance.num_len+9).ToString();
        Kill_Score.text = GameManager.instance.kill.ToString();
    }

    public void NoShow()
    {
        GameManager.instance.hit_wall = false;
    }
}
