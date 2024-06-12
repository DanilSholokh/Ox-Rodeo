using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    private RandomMovement movement;
    private TouchDetector touchDetector;
    private CircleEvent circleEvent;

    private GameManager gameManager;

    public RandomMovement _movement { get => movement; private set => movement = value; }
    public TouchDetector _touchDetector { get => touchDetector; private set => touchDetector = value; }
    public CircleEvent _CircleEvent { get => circleEvent; private set => circleEvent = value; }

    private void Start()
    {
        movement = GetComponent<RandomMovement>();
        touchDetector = GetComponent<TouchDetector>();
        circleEvent = GetComponent<CircleEvent>();

        gameManager = GameManager.Instance;
    }


    public bool isTouch()
    {
        circleEvent.IsPaused = gameManager.IsPaused;

        circleEvent.IsTouch = touchDetector.isTouched;
        return touchDetector.isTouched;
    }


}
