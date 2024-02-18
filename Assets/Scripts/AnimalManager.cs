using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEditor.U2D.Aseprite;
using UnityEngine;


public interface IInteractable
{
    public void Interact();
}

public interface IEat
{
    public void Eat();
}

public enum HungerState
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
public abstract class Animal : IInteractable, IEat
{

    public Transform chatBubble;
    public Transform hungerIcon;
    public TextMeshPro voiceBox;
    public GameObject animalGameObject;
    public int direction;
    public Rigidbody2D rb;
    public string name;
    public int level;
    public int hunger;
    public string type;
    public HungerState hungerState;
    public Biomes home;


    public MonoBehaviour monoBehaviourReference;


    public abstract void speak();
    public virtual void Eat()
    {
        Debug.Log("BAse called");
        hunger = 100;
        hungerState = HungerState.FULL;
        hungerIcon.gameObject.SetActive(false);
    }
 
    public abstract void isHungry();

    public void Interact()
    {
        Debug.Log("KK");
    }

}

public class Bulbasaur : Animal
{
    

    public Bulbasaur(GameObject bulbasaurPrefab, Vector3 spawnPosition, MonoBehaviour monoBehaviourReference)
    {
        
       
        //we need a coroutine baby :(
        this.monoBehaviourReference = monoBehaviourReference;
       

        name = "Bulbasaur";
        type = "Grass";
        level = Random.Range(1, 20);
        hunger = Random.Range(60,100);
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

        hungerIcon = animalGameObject.transform.Find("hunger");

        hungerIcon.gameObject.SetActive(false);
        Transform chatBubble = animalGameObject.transform.Find("chatBubble");

        voiceBox = chatBubble.GetComponent<TextMeshPro>();
        
        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));

    }

    
    public override void speak()
    {
        monoBehaviourReference.StartCoroutine(AnimalManager.RandomChitter(name, voiceBox));


    }

   

    public override void isHungry()
    {
        hungerIcon.gameObject.SetActive(true);
        
    }

    public override void Eat()
    {
        base.Eat(); 
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
        level = Random.Range(1, 20);
        hunger = Random.Range(60, 100);
        home = Biomes.ROCK;
        // Instantiate the GameObject at the specified spawn position
        animalGameObject = Object.Instantiate(charmanderPrefab, spawnPosition, Quaternion.identity);
        animalGameObject.AddComponent<FoodFInder>();
        rb = animalGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = animalGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }
        Transform chatBubble = animalGameObject.transform.Find("chatBubble");
        voiceBox = chatBubble.GetComponent<TextMeshPro>();
       
        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));
        hungerIcon = animalGameObject.transform.Find("hunger");

        hungerIcon.gameObject.SetActive(false);
    }


    public override void speak()
    {
        monoBehaviourReference.StartCoroutine(AnimalManager.RandomChitter(name, voiceBox));
    }

 
    public override void isHungry()
    {
        hungerIcon.gameObject.SetActive(true);
    }
    public override void Eat()
    {
        base.Eat();
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
        level = Random.Range(1, 20);
        hunger = Random.Range(60, 100);
        home = Biomes.FOREST;
        // Instantiate the GameObject at the specified spawn position
        animalGameObject = Object.Instantiate(pikachuPrefab, spawnPosition, Quaternion.identity);
        rb = animalGameObject.GetComponent<Rigidbody2D>();
        animalGameObject.AddComponent<FoodFInder>();
        if (rb == null)
        {
            rb = animalGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }

        Transform chatBubble = animalGameObject.transform.Find("chatBubble");
        voiceBox = chatBubble.GetComponent<TextMeshPro>();
        
        //send off some info to Animations script
        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));
        hungerIcon = animalGameObject.transform.Find("hunger");

        hungerIcon.gameObject.SetActive(false);
    }


    public override void speak()
    {
        
        monoBehaviourReference.StartCoroutine(AnimalManager.RandomChitter(name, voiceBox));
    }




    public override void isHungry()
    {
        hungerIcon.gameObject.SetActive(true);
    }
    public override void Eat()
    {
        base.Eat();
        Debug.Log("It worked!" + hunger);
    }

}


public class Squirtle: Animal
{


    public Squirtle(GameObject squirtlePrefab, Vector3 spawnPosition, MonoBehaviour monoBehaviourReference)
    {

        //we need a coroutine baby :(
        this.monoBehaviourReference = monoBehaviourReference;

        name = "Squirtle";
        type = "Water";
        level = Random.Range(1, 20);
        hunger = Random.Range(60, 100);
        home = Biomes.FOREST;
        // Instantiate the GameObject at the specified spawn position
        animalGameObject = Object.Instantiate(squirtlePrefab, spawnPosition, Quaternion.identity);
        animalGameObject.AddComponent<FoodFInder>();
        rb = animalGameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = animalGameObject.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
        }
        //init our voicey box
        Transform chatBubble = animalGameObject.transform.Find("chatBubble");
        voiceBox = chatBubble.GetComponent<TextMeshPro>();
        
        //send off some info to Animations script
        monoBehaviourReference.StartCoroutine(Animations.NPCMovement(animalGameObject, rb, direction));
        hungerIcon = animalGameObject.transform.Find("hunger");

        hungerIcon.gameObject.SetActive(false);
    }


    public override void speak()
    {

        monoBehaviourReference.StartCoroutine(AnimalManager.RandomChitter(name, voiceBox));
    }




    public override void isHungry()
    {
        hungerIcon.gameObject.SetActive(true);
    }
    public override void Eat()
    {
        Debug.Log("Sub called");
        base.Eat();
        Debug.Log("It worked!" + hunger);
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

    //store list of water spawns for my BOY SQUIRTLEEEE

    public List<Squirtle> squirtleInstances = new List<Squirtle>();
    public List<GameObject> waterSpawns = new List<GameObject>(4);
    public GameObject squirtlePrefab;

    

    //hunger reduction Logic
    public float interval = 5f; // Set the interval in seconds
    public float elapsedTime;


  

    void Start()
    {




        //timer logic
        elapsedTime = 0f;
        



        // Loop through the pens and spawn a Bulbasaur
        foreach (GameObject penSpawn in penSpawns)
        {
            Bulbasaur bulbasaurInstance = new Bulbasaur(bulbasaurPrefab, penSpawn.transform.position, this);
            bulbasaurInstances.Add(bulbasaurInstance);  // Add the instance to the list
            bulbasaurInstance.speak();
        }

        foreach (GameObject rockSpawn in rockSpawns)
        {
            Charmander charmanderInstance = new Charmander(charmanderPrefab, rockSpawn.transform.position, this);
            charmanderInstances.Add(charmanderInstance);
            charmanderInstance.speak();
        }

        foreach (GameObject forestSpawn in forestSpawns)
        {
            Pikachu pikachuInstance = new Pikachu(pikachuPrefab, forestSpawn.transform.position, this);
            pikachuInstances.Add(pikachuInstance);
            pikachuInstance.speak();
        }

        foreach (GameObject waterSpawn in waterSpawns)
        {
            Squirtle squirtleInstance = new Squirtle(squirtlePrefab, waterSpawn.transform.position, this);
            squirtleInstances.Add(squirtleInstance);
            squirtleInstance.speak();
        }


        

    }


    public void Update()
    {
        elapsedTime += Time.deltaTime;
       
        if (elapsedTime >= interval)
        {
            Debug.Log("reduce!");
            foreach (Bulbasaur animal in bulbasaurInstances)
            {
                
                animal.hunger -= Random.Range(3,7);
                //Debug.Log(animal.level + " " + animal.hunger + " " + animal.name);
                if(animal.hunger <= 0)
                {
                    animal.hungerState = HungerState.HUNGRY;
                    animal.isHungry();

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        animal.Eat();
                    }

                } 

             }
            foreach (Charmander animal in charmanderInstances)
            {

                animal.hunger -= Random.Range(5, 6);
                //Debug.Log(animal.level + " " + animal.hunger + " " + animal.name);
                if (animal.hunger <= 0)
                {
                    animal.hungerState = HungerState.HUNGRY;
                    animal.isHungry();
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        animal.Eat();
                    }
                }

            }

            foreach (Squirtle animal in squirtleInstances)
            {

                animal.hunger -= Random.Range(6, 9);
               // Debug.Log(animal.level + " " + animal.hunger + " " + animal.name);
                if (animal.hunger <= 0)
                {
                    animal.hungerState = HungerState.HUNGRY;
                    animal.isHungry();
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        animal.Eat();
                    }
                }

            }

            foreach (Pikachu animal in pikachuInstances)
            {

                animal.hunger -= Random.Range(5, 8);
               // Debug.Log(animal.level + " " + animal.hunger +" "+ animal.name);
                if (animal.hunger <= 0)
                {
                    Debug.Log("PIKA HUNGERS");
                    animal.hungerState = HungerState.HUNGRY;
                    animal.isHungry();
                    
                        
                    
                }

            }

            elapsedTime = 0f;
            interval = Random.Range(5, 8);
        }






        
    }



    public static IEnumerator RandomChitter(string name, TextMeshPro voice)
    {
       
       
        // Keep the coroutine running indefinitely
        while (true)
        {

            switch (name)
            {

                case "Bulbasaur":
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    voice.text = "Bulba!";
                    yield return new WaitForSeconds(Random.Range(1f, 2f));
                    voice.text = "";
                    break;

                case "Charmander":
                    yield return new WaitForSeconds(Random.Range(1f, 2f));
                    voice.text = "Char! Char! :(";
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    voice.text = "";
                    break;

                case "Squirtle":
                    yield return new WaitForSeconds(Random.Range(1f, 2f));
                    voice.text = "Squirt!";
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    voice.text = "";
                    break;

                case "Pikachu":
                    yield return new WaitForSeconds(Random.Range(1f, 2f));
                    voice.text = "Pika!";
                    yield return new WaitForSeconds(Random.Range(1f, 3f));
                    voice.text = "";
                    break;

            }
        }
    }

   

}
