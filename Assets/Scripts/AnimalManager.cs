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
    public GameObject bulbasaurGameObject;

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
        bulbasaurGameObject = Object.Instantiate(bulbasaurPrefab, spawnPosition, Quaternion.identity);
        rb = bulbasaurGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = bulbasaurGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }

      
        monoBehaviourReference.StartCoroutine(NPCMovement(bulbasaurGameObject));

    }

    
    public override void speak()
    {
        Debug.Log("bulba!");
    }

    public override void eat()
    {
        // we will have the animals eat eachother LOL
    }


    //we going to randomly switch states here. and also  we will also control movement
    public IEnumerator NPCMovement(GameObject animateMe)
    {
        Animator animDirection = animateMe.GetComponent<Animator>();
        // Keep the coroutine running indefinitely
        while (true)
        {
            direction = Random.Range(0, 5);  // Adjusted to include case 4
            animDirection.ResetTrigger("Idle");
            switch (direction)
            {
                case 0:
                   
                    animDirection.SetTrigger("Roam1");
                    rb.velocity = Vector2.left;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 1:
                    
                    animDirection.SetTrigger("Roam2");
                    rb.velocity = Vector2.right;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 2:
                    
                    animDirection.SetTrigger("Roam3");
                    rb.velocity = Vector2.up;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 3:
                    
                    animDirection.SetTrigger("Roam4");
                    rb.velocity = Vector2.down;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 4:
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle"); // Trigger the "Idle" animation
                    break;
            }
           yield return new WaitForSeconds(Random.Range(1f, 3f));
            animDirection.ResetTrigger("Roam1");
            animDirection.ResetTrigger("Roam2");
            animDirection.ResetTrigger("Roam3");
            animDirection.ResetTrigger("Roam4");
            animDirection.ResetTrigger("Idle");
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}










public class Charmander: Animal
{
    public GameObject charmanderGameObject;

    public Charmander(GameObject charmanderPrefab, Vector3 spawnPosition, MonoBehaviour monoBehaviourReference)
    {

        //we need a coroutine baby :(
        this.monoBehaviourReference = monoBehaviourReference;








        name = "Bulbasaur";
        type = "Grass";
        age = Random.Range(1, 20);
        hunger = 100;
        home = Biomes.PEN;
        // Instantiate the Bulbasaur GameObject at the specified spawn position
        charmanderGameObject = Object.Instantiate(charmanderPrefab, spawnPosition, Quaternion.identity);
        rb = charmanderGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = charmanderGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }


        monoBehaviourReference.StartCoroutine(NPCMovement(charmanderGameObject));

    }


    public override void speak()
    {
        Debug.Log("bulba!");
    }

    public override void eat()
    {
        // we will have the animals eat eachother LOL
    }



    public IEnumerator NPCMovement(GameObject animateMe)
    {
        Animator animDirection = animateMe.GetComponent<Animator>();
        // Keep the coroutine running indefinitely
        while (true)
        {
            direction = Random.Range(0, 5);  // Adjusted to include case 4
            animDirection.ResetTrigger("Idle");
            switch (direction)
            {
                case 0:

                    animDirection.SetTrigger("Roam1");
                    rb.velocity = Vector2.left;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 1:

                    animDirection.SetTrigger("Roam2");
                    rb.velocity = Vector2.right;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 2:

                    animDirection.SetTrigger("Roam3");
                    rb.velocity = Vector2.up;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 3:

                    animDirection.SetTrigger("Roam4");
                    rb.velocity = Vector2.down;
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle");
                    break;
                case 4:
                    rb.velocity = Vector2.zero;
                    animDirection.SetTrigger("Idle"); // Trigger the "Idle" animation
                    break;
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            animDirection.ResetTrigger("Roam1");
            animDirection.ResetTrigger("Roam2");
            animDirection.ResetTrigger("Roam3");
            animDirection.ResetTrigger("Roam4");
            animDirection.ResetTrigger("Idle");
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
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



    }

    void Update()
    {
        foreach (Bulbasaur bulb in bulbasaurInstances)
        {
           //probably the speak stuff
        }
    }



}
