using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;

    }
    public event UnityAction gameEvent;
    //贪吃蛇长度
    public int num_len=1;

    public int kill = 0;
    //是否撞到墙
    public bool hit_wall=false;

    public float threshold=0.1f;
    public bool act = false;


    public void kill_add()
    {
        kill+=1;
    }


}
