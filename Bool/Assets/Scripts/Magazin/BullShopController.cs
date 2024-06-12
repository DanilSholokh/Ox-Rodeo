using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullShopController : MonoBehaviour
{

    [SerializeField] private GameObject textPrice;

    public int price = 0;

    private Image bullImage;
    private bool isBuy = false;
    private int id = 0;

    public Image BullImage { get => bullImage; set => bullImage = value; }
    public bool IsBuy { get => isBuy; set => isBuy = value; }
    public int Id { get => id; set => id = value; }

    private void Start()
    {
        BullImage = GetComponent<Image>();
    }

    public void bullBuy()
    {
        if (isBuy)
        {
            if (textPrice != null)
            {
                Destroy(textPrice);
            }
        }

    }


}
