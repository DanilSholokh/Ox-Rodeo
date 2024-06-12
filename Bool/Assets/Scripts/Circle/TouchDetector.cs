using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDetector : MonoBehaviour
{
    public bool isTouched { get; private set; }
    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        isTouched = false;
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touch.position, canvas.worldCamera))
                {
                    isTouched = true;
                    break;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, canvas.worldCamera))
            {
                isTouched = true;
            }
        }
    }

}
