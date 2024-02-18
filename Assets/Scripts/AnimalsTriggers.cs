using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    public bool interactable = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            interactable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }
}
