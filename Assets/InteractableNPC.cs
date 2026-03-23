using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class InteractableNPC : MonoBehaviour
{
    private bool PlayerInRange = false;
    [SerializeField] private TextMeshProUGUI TGUI;
    [SerializeField] private string[] lines;
    private int index = 0;
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private GameObject panel;
    public bool isTyping;
    private Coroutine typingCoroutine;
    [SerializeField] private Movement playerMovement;

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
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !panel.activeSelf)
        {
            panel.SetActive(true);
            StartDia();
        }
        if (panel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            NewDia();
        }

    }
    void StartDia()
    {
        index = 0;
        TGUI.text = "";
        StartTyping();
        playerMovement.canMove = false;
    }
    void NewDia()
    {
        if (isTyping)
        {
           if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            TGUI.text = lines[index];
            isTyping = false;
            return; 
        }
        if (index < lines.Length - 1)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            index++;
            TGUI.text = String.Empty;
            StartTyping();
        }
        else
        {
            panel.SetActive(false);
            playerMovement.canMove = true;
        }
    }
    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in lines[index])
        {
            TGUI.text += c;
            yield return new WaitForSeconds(speed);
        }
        isTyping = false;
    }
    void StartTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeLine());
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
            panel.SetActive(false);
            playerMovement.canMove = true;
        }
    }
}