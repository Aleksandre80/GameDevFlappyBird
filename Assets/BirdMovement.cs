using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float jumpForce = 2f;
    public float speedForce = 1f;
    private Rigidbody2D rb;
    private bool isDead = false;
    public GameObject StartFrame;
    public bool isStart;
    public AudioSource scoreSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartFrame.SetActive(true);
        rb.isKinematic = true;
        isStart = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isDead)
        {
            isStart = true;
            rb.isKinematic=false;
            rb.velocity = Vector2.up * jumpForce;
            StartFrame.SetActive(false);
            scoreSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rb.velocity = Vector2.zero;
        // Ici, tu peux ajouter un code pour gérer ce qui se passe quand l'oiseau meurt (comme afficher un écran de Game Over).
    }
}
