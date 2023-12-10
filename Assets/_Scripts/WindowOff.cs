using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowOff : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] WindowController controller;

    public void OnPointerDown(PointerEventData eventData)
    {
        controller.GoMenu();
    }
}
