using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    

    public int num = 1;
    public bool hit = false;
    public int a = 1;
    public event UnityAction Enmeyevent;
    public void num_change()
    {
        num++;
    }
    public void hit_enemy()
    {
        hit = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            
            Enmeyevent.Invoke();
        }
    }
}
