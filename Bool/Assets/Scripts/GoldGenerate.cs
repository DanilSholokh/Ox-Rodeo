using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGenerate : MonoBehaviour
{
    [SerializeField] private Bullconomica bullconomica;
    [SerializeField] private BarGamePlay barGamePlay;
    
    [SerializeField] private List<Transform> goldPlace;
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private EnergyBooster energyBooster;

    private float time = 0;

    public float spawnTime = 4f;


    public void updateGoldGanarate()
    {

        time += Time.deltaTime;

        if(time >= spawnTime)
        {
            createGold();
            time = 0;
        }

    }

    private void createGold()
    {

        if (Random.Range(0, 100) >= 50)
        {
            Coin coinInGame = Instantiate(coinPrefab, getTransform());

            coinInGame._bullconomica = bullconomica;

        }
        else
        {
            EnergyBooster booster = Instantiate(energyBooster, getTransform());

            booster.BarGamePlay = barGamePlay;
        }
        
    }    

    private Transform getTransform()
    {
        int r_num = Random.Range(0, goldPlace.Count);

        return goldPlace[r_num];


    }

}
