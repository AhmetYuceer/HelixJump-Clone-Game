using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour , IDragHandler
{
    [SerializeField] private Transform rotateObject;
    [SerializeField] private float rotateSpeed;

    public void OnDrag(PointerEventData eventData)
    {
        var rotation = rotateObject.rotation;
        var current = rotation.eulerAngles.y;
        current += eventData.delta.x * rotateSpeed * Time.deltaTime;
        rotateObject.eulerAngles = new Vector3(0,current,0);
    }

}
