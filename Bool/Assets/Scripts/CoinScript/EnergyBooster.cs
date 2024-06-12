using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnergyBooster : MonoBehaviour, IPointerDownHandler
{
    private float energyPower = 0.15f;

    private Animator _animator;
    
    private BarGamePlay barGamePlay;

    public BarGamePlay BarGamePlay { get => barGamePlay; set => barGamePlay = value; }

    public void OnPointerDown(PointerEventData eventData)
    {
        giveEnergy();
        Destroy(transform.parent.gameObject);
    }

    private void giveEnergy()
    {
        BarGamePlay.tikSlider(energyPower);
    }

}
