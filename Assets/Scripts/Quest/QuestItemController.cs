using UnityEngine;

public class QuestItemController : MonoBehaviour
{
    [SerializeField] private GameObject ActivateFinishCollider;

    private void OnTriggerEnter(Collider other)
    {
        ActivateFinishCollider.SetActive(true);
    }
}
