using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetPanelScript : MonoBehaviour
{
    public Toggle tog;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        int on_off=PlayerPrefs.GetInt("music_on/off");
        if (on_off==1)
        {
            tog.isOn = true;
        }
        else
        {
            tog.isOn =false;
        }
        tog.onValueChanged.AddListener(delegate(bool select)
        {
          
            if (!select)
            {
                isOns(0);
            }
            else
            {
                isOns(1);
            }
        });

        btn.onClick.AddListener(delegate()
        {
            this.gameObject.SetActive(false);
        });

    }
    public void isOns(int a)
    {
   
        PlayerPrefs.SetInt("music_on/off",a);
       

    }
}
