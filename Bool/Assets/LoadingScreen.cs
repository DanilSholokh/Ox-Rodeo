using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingScreen : MonoBehaviour
{

    [SerializeField] private GameObject loadPanel;

    [SerializeField] private Slider slider;
    public AnimationCurve progressCurve;
    public float progressDuration = 2.0f;

    private float targetProgress = 0;
    private float startProgress = 0;
    private float elapsedTime = 0;
    private bool isProgressing = false;

    void Start()
    {
        if (slider != null)
        {
            slider.value = 0;
            IncrementProgress(1.1f);
        }
    }

    void Update()
    {
        if (isProgressing)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / progressDuration;

            if (t < 1.0f)
            {
                slider.value = Mathf.Lerp(startProgress, targetProgress, progressCurve.Evaluate(t));
            }
            else
            {
                slider.value = targetProgress;
                isProgressing = false;
                Destroy(loadPanel);
            }
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = Mathf.Clamp(newProgress, slider.minValue, slider.maxValue);
        startProgress = slider.value;
        elapsedTime = 0;
        isProgressing = true;
    }


}
