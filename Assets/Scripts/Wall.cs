﻿using System.Collections;
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
    }
}
