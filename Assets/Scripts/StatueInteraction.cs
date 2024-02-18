using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatueInteraction : MonoBehaviour, IInteractable
{


    public bool interactable = false;

    public GameObject buttonPrompt;
    public GameObject messageCanvas;
    public TextMeshProUGUI messageText;

    public BiomeInfo infos;

    public void Interact(string name)
    {
        messageCanvas.SetActive(true);
        switch (name)
        {
            case "Statue1":
                messageText.text = infos.water;
                break;
            case "Statue2":
                messageText.text = infos.forest;
                break;
            case "Statue3":
                messageText.text = infos.rock;
                break;
            case "Statue4":
                messageText.text = infos.pen;
                break;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        buttonPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable & Input.GetKeyDown(KeyCode.E))
        {
            Interact(gameObject.name);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactable = true;
            buttonPrompt.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
        buttonPrompt.SetActive(false);
    }

}
