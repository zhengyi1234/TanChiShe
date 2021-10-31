using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Accelerate : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
      //  GameManager.instance.threshold = 0.03f;
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.instance.act = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // GameManager.instance.threshold = 0.1f;
        GameManager.instance.act = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
