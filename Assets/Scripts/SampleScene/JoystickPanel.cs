using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class JoystickPanel : MonoBehaviour,IPointerUpHandler,IDragHandler,IPointerDownHandler
{
    public static JoystickPanel instance;
    //属性值
    public Image joystick;
    public Image imgControl;
    public float x;
    public float y ;

    private void Awake()
    {
        instance = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform,(eventData as PointerEventData).position,(eventData as PointerEventData).pressEventCamera,out localPos);
        imgControl.transform.localPosition = localPos;
        if (localPos.magnitude>799)
        {
            imgControl.transform.localPosition = localPos.normalized * 799;
        }
        x = imgControl.transform.localPosition.x / 799;
        y = imgControl.transform.localPosition.y / 799;


        
       

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        imgControl.transform.localPosition = Vector3.zero;       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
}
