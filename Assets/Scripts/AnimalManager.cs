using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEditor.U2D.Aseprite;
using UnityEngine;




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

    
    public GameObject animalGameObject;
    public int direction;
    public Rigidbody2D rb;
    public string name;
    public int age;
    public int hunger;
    public string type;
    public Hungry hungerState;
    public Biomes home;
    public MonoBehaviour monoBehaviourReference;
  
    public abstract void speak();
    public abstract void eat();
}

public class Bulbasaur : Animal
{
    

    public Bulbasaur(GameObject bulbasaurPrefab, Vector3 spawnPosition, MonoBehaviour monoBehaviourReference)
    {

        //we need a coroutine baby :(
        this.monoBehaviourReference = monoBehaviourReference;
        


        




        name = "Bulbasaur";
        type = "Grass";
        age = Random.Range(1, 20);
        hunger = 100;
        home = Biomes.PEN;
        // Instantiate the Bulbasaur GameObject at the specified spawn position
        animalGameObject = Object.Instantiate(bulbasaurPrefab, spawnPosition, Quaternion.identity);
        rb = animalGameObject.GetComponent<Rigidbody2D>(); 
        if (rb == null)
        {
            rb = animalGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }

      
        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));

    }

    
    public override void speak()
    {
        Debug.Log("bulba!");
    }

    public override void eat()
    {
        // we will have the animals eat eachother LOL
    }


    
   
}










public class Charmander: Animal
{
    

    public Charmander(GameObject charmanderPrefab, Vector3 spawnPosition, MonoBehaviour monoBehaviourReference)
    {

        //we need a coroutine baby :(
        this.monoBehaviourReference = monoBehaviourReference;








        name = "Charmander";
        type = "Fire";
        age = Random.Range(1, 20);
        hunger = 100;
        home = Biomes.ROCK;
        // Instantiate the GameObject at the specified spawn position
        animalGameObject = Object.Instantiate(charmanderPrefab, spawnPosition, Quaternion.identity);
        rb = animalGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = animalGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }


        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));

    }


    public override void speak()
    {
        Debug.Log("bulba!");
    }

    public override void eat()
    {
        // we will have the animals eat eachother LOL
    }



   
}



public class Pikachu : Animal
{

    
    public Pikachu(GameObject pikachuPrefab, Vector3 spawnPosition, MonoBehaviour monoBehaviourReference)
    {

        //we need a coroutine baby :(
        this.monoBehaviourReference = monoBehaviourReference;

        name = "Pikachu";
        type = "Electric";
        age = Random.Range(1, 20);
        hunger = 100;
        home = Biomes.FOREST;
        // Instantiate the GameObject at the specified spawn position
        animalGameObject = Object.Instantiate(pikachuPrefab, spawnPosition, Quaternion.identity);
        rb = animalGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = animalGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }


        //send off some info to Animations script
        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));

    }


    public override void speak()
    {
        Debug.Log("bulba!");
    }

    public override void eat()
    {
        // we will have the animals eat eachother LOL
    }



   
}



















    public class AnimalManager : MonoBehaviour
{

    //store a list of penspawns, choose bulbasaur i guess 
    public List<Bulbasaur> bulbasaurInstances = new List<Bulbasaur>();
    public List<GameObject> penSpawns = new List<GameObject>(4);
    public GameObject bulbasaurPrefab;


    //store a list of rock spawns, for charmander
    public List<Charmander> charmanderInstances = new List<Charmander>();
    public List<GameObject> rockSpawns = new List<GameObject>(4);
    public GameObject charmanderPrefab;

    //store a list of forest spawns for pikachu

    public List<Pikachu> pikachuInstances = new List<Pikachu>();
    public List<GameObject> forestSpawns = new List<GameObject>(4);
    public GameObject pikachuPrefab;
    void Start()
    {
        // Loop through the pens and spawn a Bulbasaur
        foreach (GameObject penSpawn in penSpawns)
        {
            Bulbasaur bulbasaurInstance = new Bulbasaur(bulbasaurPrefab, penSpawn.transform.position, this);
            bulbasaurInstances.Add(bulbasaurInstance);  // Add the instance to the list
          
        }

        foreach (GameObject rockSpawn in rockSpawns)
        {
            Charmander charmanderInstance = new Charmander(charmanderPrefab, rockSpawn.transform.position, this);
            charmanderInstances.Add(charmanderInstance);
        }

        foreach (GameObject forestSpawn in forestSpawns)
        {
            Pikachu pikachuInstance = new Pikachu(pikachuPrefab, forestSpawn.transform.position, this);
            pikachuInstances.Add(pikachuInstance);
        }

    }

    void Update()
    {
        foreach (Bulbasaur bulb in bulbasaurInstances)
        {
           //probably the speak stuff
        }
    }



}
