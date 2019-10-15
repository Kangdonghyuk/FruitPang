using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    public int maxValue;
    public int value;
    public Vector2 rectFullSizeDelta;
    public Vector2 rectSizeDelta;
    public Vector3 clockInitPosition;
    public Vector3 clockPosition;

    public RectTransform clock;
    public RectTransform rectTransform;
    public Transform backTransform;
    public RectTransform backRectTransform;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();

        clock = transform.GetChild(1).GetComponent<RectTransform>();
        backTransform = transform.GetChild(0);
        backRectTransform = backTransform.GetComponent<RectTransform>();
    }

    void Start()
    {
        clockInitPosition = clock.anchoredPosition;
        clockPosition = clockInitPosition;

        rectFullSizeDelta = rectTransform.sizeDelta;
        rectSizeDelta = rectFullSizeDelta;
        rectSizeDelta.x = (rectFullSizeDelta.x - rectSizeDelta.x);
        backRectTransform.sizeDelta = rectSizeDelta;

        maxValue = 60;
        value = 60;
    }

    void Update() {
        if(Input.GetKey(KeyCode.UpArrow))
            SetValue(value + 1);
        if(Input.GetKey(KeyCode.DownArrow))
            SetValue(value - 1);
    }

    public void SetValue(float value) {
        if(value > 1)
            value = 1;
        if(value < 0)
            value = 0;

        clockPosition.x = clockInitPosition.x * value;
        clock.anchoredPosition = clockPosition;

        rectSizeDelta.x = -rectFullSizeDelta.x * (1 - value);
        
        backRectTransform.sizeDelta = rectSizeDelta;
    }

    public void SetValue(int value) {
        if(value > maxValue)
            value = maxValue;
        if(value < 0)
            value = 0;
        this.value = value;

        clockPosition.x = clockInitPosition.x * ((float)value / (float)maxValue);
        clock.anchoredPosition = clockPosition;
        
        rectSizeDelta.x = -rectFullSizeDelta.x * ((float)(maxValue - value) / (float)maxValue);

        /*if(rectSizeDelta.x < -rectFullSizeDelta.x)
            rectSizeDelta.x = -rectFullSizeDelta.x;
        if(rectSizeDelta.x > 0)
            rectSizeDelta.x = 0;*/

        backRectTransform.sizeDelta = rectSizeDelta;
    }

}