using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMoveCorner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CameraMove X;
    public CameraMove Y;
    public void OnPointerEnter(PointerEventData eventData)
    {
        X.Enable = true;
        Y.Enable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        X.Enable = false;
        Y.Enable = false;
    }
}