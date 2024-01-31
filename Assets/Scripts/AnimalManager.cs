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
public class Animal
{
    public string name;
    public int age;
    public int hunger;
    public States movementType;
    public Hungry hungerState;

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
