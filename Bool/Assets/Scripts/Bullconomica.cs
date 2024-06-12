using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullconomica : MonoBehaviour
{

    private int gold;

    [SerializeField] private TextMeshProUGUI goldText;

    public int Gold { get => gold; set => gold = value; }

    private void Start()
    {
        Gold = PlayerPrefs.GetInt("Gold", 1000);
        saveGold();
    }

    public void addGold(int _gold)
    {
        gold += _gold;
        saveGold();
    }

    public bool minusGold(int _gold)
    {
        if (gold >= _gold)
        {
            gold -= _gold;
            saveGold();

            return true;
        }
        
        return false;
    }


    private void saveGold()
    {
        goldText.text = "" + Gold;
        PlayerPrefs.SetInt("Gold", Gold);
    }


}
