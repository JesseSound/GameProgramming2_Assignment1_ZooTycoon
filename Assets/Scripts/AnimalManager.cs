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
    PEN,
    WATER,
    FOREST
}
public abstract class Animal
{
    public string name;
    public int age;
    public int hunger;
    public States movementType;
    public Hungry hungerState;
    public Biomes home;

    public void animate() { }
    public void speak() { }
}

public class Bulbasaur : Animal
{
    public GameObject bulbasaurGameObject;

    public Bulbasaur(GameObject bulbasaurPrefab, Vector3 spawnPosition)
    {
        name = "Bulbasaur";
        age = Random.Range(1, 20);
        hunger = 100;
        home = Biomes.PEN;
        Debug.Log(age);
        // Instantiate the Bulbasaur GameObject at the specified spawn position
        bulbasaurGameObject = Object.Instantiate(bulbasaurPrefab, spawnPosition, Quaternion.identity);

       
    }



}




public class AnimalManager : MonoBehaviour
{
    
    //store a list of penspawns, choose bulbasaur i guess 
    public List<GameObject> penSpawns = new List<GameObject>(4);
    public Bulbasaur bulby;
    //set the bulbasaur prefab to be passed to the class later 
    public GameObject bulbasaurPrefab;



    void Start()
    {
        //loop through the pens and spawn a bulbasaur
        foreach (GameObject penSpawn in penSpawns)
        {
            Bulbasaur bulbasaurInstance = new Bulbasaur(bulbasaurPrefab, penSpawn.transform.position);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
