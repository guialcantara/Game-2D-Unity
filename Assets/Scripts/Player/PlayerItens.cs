using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{
    [Header("Amount")]
     [SerializeField] private int totalWood;
     [SerializeField] private int carrots;
     [SerializeField] private float currentWater;
     [SerializeField] private int fishes;

    [Header("Limits")]
     public float waterLimit = 50f;
     public float woodLimit = 5f;
     public float carrotsLimit = 10f;
     public float fishesLimit = 5f;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public int Carrots { get => carrots; set => carrots = value; }
    public float CurrentWater { get => currentWater; set => currentWater = value; }
    public int Fishes { get => fishes; set => fishes = value; }

    public void WaterLimit(float water)
    {
        if(currentWater < waterLimit) 
        {
            currentWater += water;
        }
    }
}
