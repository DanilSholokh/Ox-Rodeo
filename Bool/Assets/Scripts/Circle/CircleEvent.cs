using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEvent : MonoBehaviour
{

    private Vector3 startScale;
    private Vector3 scaleIncrease = new Vector3(0.0003f, 0.0003f, 0.0003f);

    private bool isTouch;
    private float timer = 0;

    private float endEventTime = 7f;
    private float sliederStep = 0.3f;

    private float powerRotation = 500f;
    private float antipowerRotate = 0.9f;

    private float currentAntipowerRatate;

    [SerializeField] BarGamePlay barStamina;

    private bool isPaused;

    public bool IsTouch { get => isTouch; set => isTouch = value; }
    public BarGamePlay BarStamina { set => barStamina = value; }
    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private void Start()
    {
        startScale = transform.localScale;
        currentAntipowerRatate = antipowerRotate;
    }

    public void strtCircleEvent()
    {
        if (isPaused)
        {
            return;
        }

        timer += Time.deltaTime;
        transform.localScale += scaleIncrease;

        rotateObject();

        if (timer >= endEventTime)
        {
            if (!IsTouch)
            {
                barStamina.tikSlider(sliederStep * -1);
            }

            removeChange();
            timer = 0;
        }
    }

    private void removeChange()
    {
        transform.localScale = startScale;
    }

    private void rotateObject()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        float speed = currentRotation + powerRotation / currentAntipowerRatate * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, speed);
        currentAntipowerRatate += 0.0006f;

        if (timer >= endEventTime)
        {
            currentAntipowerRatate = antipowerRotate;
        }
    }


}
