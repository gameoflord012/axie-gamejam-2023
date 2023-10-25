using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapViewer : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Camera mainCam;
    public Vector2 boundary = new Vector2();

    private Vector2 originalCamPos = Vector2.zero;
    private Vector3 originalMousePos = Vector2.zero;

    private void Awake()
    {
        originalCamPos = mainCam.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 distance = originalMousePos - mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = mainCam.transform.position + distance;

        mainCam.transform.position = new Vector3(Mathf.Clamp(newPos.x, originalCamPos.x - boundary.x, originalCamPos.x + boundary.x),
                                                 Mathf.Clamp(newPos.y, originalCamPos.y - boundary.y, originalCamPos.y + boundary.y),
                                                 -10);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalMousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
