using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BullRiderController : MonoBehaviour
{

    public float maxRotate = 45;
    public float minRotate = -45;

    private float rotationSpeed = 50f;
    private int side = 1;

    [SerializeField] ParticleSystem particleLeft;
    [SerializeField] ParticleSystem particleRight;

    private Animator animator;


    private float timer = 0;

    public int randomChancChangeSide = 75;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }


    public void bullUpdate(float dop_rotate)
    {
        rotateRestriction();
        bullRotate(dop_rotate);
        randomChangeSide();
    }

    private void bullRotate(float dop_rotate)
    {
        float newRotation = (rotationSpeed * side) * dop_rotate * Time.deltaTime;
        transform.Rotate(0, 0, newRotation);


    }


    private void rotateRestriction()
    {

        float currentRotation = transform.localEulerAngles.z;

        if (currentRotation > 180) 
            currentRotation -= 360;

        if (currentRotation >= maxRotate)
        {
            changeSide(true);
            
            if (particleLeft != null)
            {
                particleLeft.Play();
            }


        }
        else if (currentRotation <= minRotate)
        {
            changeSide(false);

            if (particleRight != null)
            {
                particleRight.Play();
            }


        }


    }

    private void changeSide(bool isLeft)
    {
        if (isLeft)
        {
            side = -1;
        }
        else
        {
            side = 1;
        }

    }


    private void randomChangeSide()
    {

        if (timer >= 0.6f)
        {

            int r_num = Random.Range(0, 100);

            if (r_num > randomChancChangeSide)
            {
                side *= -1;
                rotationSpeed += 1.5f;
            }

            timer = 0;

        }

        timer += Time.deltaTime;


    }


    public void FallRider()
    {
        animator.SetTrigger("RiderFall");
    }


}
