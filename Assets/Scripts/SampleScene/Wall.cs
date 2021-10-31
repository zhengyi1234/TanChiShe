using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="head")
        {
            GameManager.instance.hit_wall = true;
        }
        if (other.CompareTag("Enemy"))
        {
            GameObject father = other.transform.parent.gameObject;
            other.GetComponent<Enemy>().hit_enemy();
            GameObject chi = father.transform.GetChild(1).gameObject;
            int length = chi.GetComponent<EnemyControl>().length;
            int num_len = chi.GetComponent<EnemyControl>().num_len;


            for (int n = length - 1; n >=0; n--)
            {
                PointManager.instance.Add_point_Enmey(chi.transform.GetChild(n).position.x, chi.transform.GetChild(n).position.z,num_len);
            }

            father.gameObject.SetActive(false);
            //Destroy(father.gameObject);
        }
    }
}
