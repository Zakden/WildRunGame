using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private GameObject DeathMenu;
    [SerializeField] private GameObject FinishMenu;
    [SerializeField] private GameObject InterractPanel;
    [SerializeField] private Text scoreText;
    Rigidbody playerRigidBody;
    Animator playerAnimator;
    InputManager inputManager;

    public bool isDeath;
    private int score = 0;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            score++;
            scoreText.text = score.ToString();
        }

        if(other.CompareTag("DeathZone"))
            StartCoroutine(Death());

        if (other.CompareTag("Finish"))
            StartCoroutine(Finish());
    }

    private IEnumerator Death()
    {
        isDeath = true;
        playerAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        Cursor.visible = true;
        DeathMenu.SetActive(true);
        playerRigidBody.isKinematic = true;
        inputManager.isPaused = true;
    }

    private IEnumerator Finish()
    {
        Time.timeScale = 0;
        FinishMenu.SetActive(true);
        playerRigidBody.isKinematic = true;
        Cursor.visible = true;
        inputManager.isPaused = true;
        yield return null;
    }
}
