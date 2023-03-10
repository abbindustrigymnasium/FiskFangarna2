using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrottleButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField]
    CarController carController;
    

    float throttle = 0;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        throttle = 1;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    { 
        throttle = 0;
    }

    void Update()
    {
        carController.Gas(throttle);
    }
}
