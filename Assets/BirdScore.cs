using System.Collections;
using UnityEngine;
using TMPro;

public class BirdScore : MonoBehaviour
{
    public LayerMask pipeLayer; // Assure-toi de d�finir ce masque de calque pour qu'il corresponde aux tuyaux
    public float rayLength = 30f;
    private int score = 0;
    private bool canScore = true; // Un flag pour contr�ler quand le score peut �tre incr�ment�
    public TextMeshProUGUI scoreTxt;
    public AudioSource scoreSound;

    void Update()
    {
        if (canScore)
        {
            // Lance un raycast devant l'oiseau
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, rayLength, pipeLayer);

            if (hit.collider != null)
            {
                score++;
                scoreSound.Play();
                Debug.Log(score);
                scoreTxt.text = score.ToString();
                StartCoroutine(PauseScoring()); // Lance une coroutine pour arr�ter le score pendant un certain temps
            }
        }

        // Optionnel: Dessiner le raycast dans l'�diteur
        Debug.DrawRay(transform.position, Vector2.up * rayLength, Color.red);
    }

    IEnumerator PauseScoring()
    {
        canScore = false; // D�sactive le score
        yield return new WaitForSeconds(1f); // Attend 1 seconde
        canScore = true; // R�active le score
    }
}
