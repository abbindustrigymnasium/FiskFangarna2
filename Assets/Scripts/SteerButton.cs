using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SteerButton : MonoBehaviour,  IDragHandler, IEndDragHandler
{
    [SerializeField]
    CarController carController;
    [SerializeField]
    float maxSteering;


    float steerModifier = 0;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.x != 0)
        {
            steerModifier = eventData.delta.x;
            steerModifier = Mathf.Clamp(steerModifier, -1, 1);
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        steerModifier = 0;
    }

    void Update()
    {
        carController.Steer(steerModifier);
    }
}
