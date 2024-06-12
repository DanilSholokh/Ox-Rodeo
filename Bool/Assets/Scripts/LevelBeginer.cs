using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBeginer : MonoBehaviour
{
    [SerializeField] BarGamePlay barGamePlay;
    [SerializeField] CircleManager circle;
    [SerializeField] BullRiderController bullRiderController;
    [SerializeField] BullRiderController riderController;

    [SerializeField] GoldGenerate gold;

    [SerializeField] GameObject magazine;
    
    private TimerDisplay timerDisplay;
    private bool isStart = false;



    private void Start()
    {
        timerDisplay = GetComponent<TimerDisplay>();
    }

    private void Update()
    {
        if (isStart)
        {
            timerDisplay.strtTimer();

            if (timerDisplay.currentTime >= 0)
            {
                barGamePlay.IsTouch = circle.isTouch();

                barGamePlay.sliderValueUpdate();
                
                circle._movement.strtCircle();
                circle._CircleEvent.strtCircleEvent();

                gold.updateGoldGanarate();

                bullRiderController.bullUpdate(2);
                riderController.bullUpdate(1f);
                
            }

        }  

    }

    public void firstFrameStartLevel()
    {
        isStart = true;
        barGamePlay.getStartStatSlider();

        circle.gameObject.SetActive(true);
        timerDisplay.timerText.gameObject.SetActive(true);

        magazine.SetActive(false);


    }

    public void lastFrameStartLevel()
    {
        isStart = false;
        circle.gameObject.SetActive(false);
        timerDisplay.zeroTime();
        timerDisplay.timerText.gameObject.SetActive(false);

        bullRiderController.FallRider();

        magazine.SetActive(true);
    }



}
