using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    public float speed = 200f;
    public float changeDirectionTime = 2f;
    public float smoothingTime = 0.5f; // Time it takes to smoothly transition to the new direction

    private RectTransform rectTransform;
    private Vector2 currentDirection;
    private Vector2 targetDirection;
    private float timer;
    private RectTransform canvasRectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        ChangeDirection();
    }

    public void strtCircle()
    {
        MoveObject();
        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0f;
            speed += 15f;
        }

        SmoothDirectionChange();
        CheckBounds();
    }

    private void MoveObject()
    {
        rectTransform.anchoredPosition += currentDirection * speed * Time.deltaTime;
    }

    private void ChangeDirection()
    {
        targetDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void SmoothDirectionChange()
    {
        currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime / smoothingTime).normalized;
    }

    private void CheckBounds()
    {
        Vector3[] canvasCorners = new Vector3[4];
        canvasRectTransform.GetWorldCorners(canvasCorners);

        Vector3[] objectCorners = new Vector3[4];
        rectTransform.GetWorldCorners(objectCorners);

        Vector2 newPosition = rectTransform.anchoredPosition;

        if (objectCorners[0].x < canvasCorners[0].x || objectCorners[2].x > canvasCorners[2].x)
        {
            currentDirection.x = -currentDirection.x;
            targetDirection.x = -targetDirection.x;
        }

        if (objectCorners[0].y < canvasCorners[0].y || objectCorners[1].y > canvasCorners[1].y)
        {
            currentDirection.y = -currentDirection.y;
            targetDirection.y = -targetDirection.y;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, canvasRectTransform.rect.min.x + rectTransform.rect.width / 2, canvasRectTransform.rect.max.x - rectTransform.rect.width / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, canvasRectTransform.rect.min.y + rectTransform.rect.height / 2, canvasRectTransform.rect.max.y - rectTransform.rect.height / 2);

        rectTransform.anchoredPosition = newPosition;
    }

}

