using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Время удаления объекта
    const float timeToDelete = 1f;
    [SerializeField] ParticleSystem blowEffect;
    private Animator coinAnimator;

    private void Awake()
    {
        coinAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshCollider>().enabled = false;
        coinAnimator.SetBool("Alive", false);
        coinAnimator.SetTrigger("Collect");
        Destroy(transform.parent.gameObject, timeToDelete);
        if(blowEffect != null) 
            blowEffect.Play();
    }
}
