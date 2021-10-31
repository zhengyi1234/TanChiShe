using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColid : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           
            GameManager.instance.kill_add();

            GameObject father = other.transform.parent.gameObject;
            other.GetComponent<Enemy>().hit_enemy();
            GameObject chi = father.transform.GetChild(1).gameObject;
            int length = chi.GetComponent<EnemyControl>().length;
            int num_len = chi.GetComponent<EnemyControl>().num_len;


            for (int n = length - 1; n >= 0; n--)
            {
                PointManager.instance.Add_point_Enmey(chi.transform.GetChild(n).position.x, chi.transform.GetChild(n).position.z, num_len);
            }

            father.gameObject.SetActive(false);
          
        }
    }
}
