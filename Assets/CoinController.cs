using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Время удаления объекта
    const float timeToDelete = 1f;
    private Animator coinAnimator;

    private void Awake()
    {
        coinAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        coinAnimator.SetBool("Alive", false);
        coinAnimator.SetTrigger("Collect");
        Destroy(transform.parent.gameObject, timeToDelete);
    }
}
