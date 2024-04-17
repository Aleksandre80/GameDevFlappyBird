using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdCollision : MonoBehaviour
{
    private bool isDead = false;
    public AudioSource scoreSound;

    private void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            Debug.Log("Meurt");
            Die();
        }
    }

    private void Die()
    {
        if (!isDead)
        {
            isDead = true;
            scoreSound.Play();
            Invoke("ReloadScene", 0.001f);
        }
    }

    private void ReloadScene()
    {
        // Recharge la scène courante pour redémarrer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
