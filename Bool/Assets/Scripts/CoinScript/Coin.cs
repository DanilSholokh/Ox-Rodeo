using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IPointerDownHandler
{

    private int coinPrice = 10;

    private Animator _animator;
    private Bullconomica bullconomica;

    public Bullconomica _bullconomica { get => bullconomica; set => bullconomica = value; }

    public void OnPointerDown(PointerEventData eventData)
    {
        takeCoin();
        Destroy(transform.parent.gameObject);
    }

    private void takeCoin()
    {
        _bullconomica.addGold(coinPrice);
    }


}
