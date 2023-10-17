using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] private GameObject leverTop;
    [SerializeField] private GameObject Bridge;
    [SerializeField] private GameObject InterractPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            InterractPanel.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<InputManager>().isInterract)
        {
            Bridge.GetComponent<Animation>().Play();
            leverTop.GetComponent<Animation>().Play();
            gameObject.SetActive(false);
            InterractPanel.SetActive(false);
            other.gameObject.GetComponent<InputManager>().isInterract = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            InterractPanel.SetActive(false);
    }
}
