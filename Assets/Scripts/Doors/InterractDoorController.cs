using UnityEngine;

public class InterractDoorController : MonoBehaviour
{
    [SerializeField] GameObject InterractPanel;
    [SerializeField] GameObject DoorOne;
    [SerializeField] GameObject DoorTwo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            InterractPanel.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<InputManager>().isInterract)
        {
            DoorOne.gameObject.GetComponent<Animator>().SetTrigger("DoorOneOpen");
            DoorTwo.gameObject.GetComponent<Animator>().SetTrigger("DoorTwoOpen");
            gameObject.SetActive(false);
            InterractPanel.SetActive(false);
            other.gameObject.GetComponent<InputManager>().isInterract = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            InterractPanel.SetActive(false);
    }
}
