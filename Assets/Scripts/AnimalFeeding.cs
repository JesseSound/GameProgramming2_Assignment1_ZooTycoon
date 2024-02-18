using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalFeeding : MonoBehaviour
{
    // Start is called before the first frame update


    public bool canInteract;
    public AnimalManager animalLists;
    public AnimalsTriggers isCollided;
    public Vector3 newPos;
    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.Space))
        {
            Animal closestAnimal = null;
            float closestDistance = float.MaxValue;

            foreach (var animal in animalLists.GetAllAnimals())
            {
                if (animal.hungerState == HungerState.HUNGRY)
                {
                    float distance = Vector2.Distance(transform.position, animal.GetPosition());

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestAnimal = animal;
                    }
                }
            }

            if (closestAnimal != null)
            {
                closestAnimal.Eat();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("animals"))
        {
            canInteract = true;
            isCollided = collision.GetComponent<AnimalsTriggers>();
            newPos = collision.GetComponent<Transform>().position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}
