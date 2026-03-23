using UnityEngine;
using Unity;
using System.Collections;
using TMPro;
using System;

public class InteractableNPC : MonoBehaviour
{
    private bool PlayerInRange = false;
    public TextMeshProUGUI TGUI;
    public string[] lines;
    private int index = 0;
    private float speed = 0.3f;
    public GameObject panel;

    void Awake()
    {
        panel.SetActive(false);   
    }

    void Update()
    {
        Interact();
    }
    public void Interact()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(true);
            StartDia();
        }
    }
    void StartDia()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    void NewDia()
    {
        if (index < lines.Length - 1)
        {
            index++;
            TGUI.text = String.Empty;
            StartCoroutine(TypeLine());
        }
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            TGUI.text += c;
            yield return new WaitForSeconds(speed);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}