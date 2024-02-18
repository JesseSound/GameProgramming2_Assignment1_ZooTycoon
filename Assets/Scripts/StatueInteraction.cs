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
                StartCoroutine(ResetMessage());
                break;
            case "Statue2":
                messageText.text = infos.forest;
                StartCoroutine(ResetMessage());
                break;
            case "Statue3":
                messageText.text = infos.rock;
                StartCoroutine(ResetMessage());
                break;
            case "Statue4":
                messageText.text = infos.pen;
                StartCoroutine(ResetMessage());
                break;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        buttonPrompt.SetActive(false);
        messageText.text = "";
        messageCanvas.SetActive(false);
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
    IEnumerator ResetMessage()
    {
        // Wait for a short time before resetting the messageText and deactivating the canvas.
        yield return new WaitForSeconds(4f); 

        // Resetting messageText and deactivating the canvas.
        messageText.text = "";
        messageCanvas.gameObject.SetActive(false);
    }
}
