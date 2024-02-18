using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalFeeding : MonoBehaviour
{
    // Start is called before the first frame update


    public bool canInteract;
    public AnimalManager animalLists;


    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Squirtle animal in animalLists.squirtleInstances )
            {
                if (animal.hungerState == HungerState.HUNGRY && animal.isColliding )
                {
                    animal.Eat();
                }
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("animals"))
        {
            canInteract = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}
