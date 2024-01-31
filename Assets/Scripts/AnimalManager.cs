using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum States
{
    IDLE,
    ROAMING
}
public enum Hungry
{
    HUNGRY,
    FULL
}

public enum Biomes
{
    ROCK,
    PEN
}
public class Animal
{
    public string name;
    public int age;
    public int hunger;
    public States movementType;
    public Hungry hungerState;
    public Biomes home;

}





public class AnimalManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
