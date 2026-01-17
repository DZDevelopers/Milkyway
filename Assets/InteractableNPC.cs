using UnityEngine;
using Unity;

public class InteractableNPC : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] private string npcDialogue;
    private bool PlayerInRange = false;
    public void Interact()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting withnpcName");
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