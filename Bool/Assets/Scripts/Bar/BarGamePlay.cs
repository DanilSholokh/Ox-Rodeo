using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGamePlay : MonoBehaviour
{

    [SerializeField] Slider slider_AngryBull;

    private GameManager gameManager;

    private float tikValue = 0.03f;
    private int plusFine = 3;

    private float timer = 0;


    private bool isTouch = false;

    public bool IsTouch { get => isTouch; set => isTouch = value; }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }


    public void sliderValueUpdate()
    {

        timer += Time.deltaTime;

        if (timer > 1f)
        {
            if (IsTouch)
            {
                plusSliderValue();
            }
            else
            {
                minusSliderValue();
            }

            timer = 0f;
        }

        
    }

    public void getStartStatSlider()
    {
        slider_AngryBull.value = 1;
    }

    public void tikSlider(float value) // увеличить церкл и отнять больше значение если не нажата при максимум увеоличении церкла
    {
        slider_AngryBull.value += value;
    }    

    private void minusSliderValue()
    {
        if (slider_AngryBull.value > 0)
        {
            tikSlider(-tikValue);
        }
        else 
        {
            gameManager.looseGame();

        }
       

    }

    private void plusSliderValue()
    {
        if (slider_AngryBull.value < 100)
        {
            tikSlider(tikValue / plusFine);

        }
    }
    


}
