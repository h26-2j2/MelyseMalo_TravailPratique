using UnityEngine;
using UnityEngine.EventSystems;

public class Objet : MonoBehaviour
{
    Rigidbody2D rb;

    //Audio
    public AudioSource audio;
    public AudioClip objetClique;

    //Force de l'impulsion
    public float forceX = 0f;
    public float forceY = 5f;

    //Direction de l'impulsion
    bool direction = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Réinitialise la vitesse actuelle
        rb.linearVelocity = Vector2.zero;

        //Ajoute une force vers le haut
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    public void AuClic(BaseEventData eventData)
    {
        //Debug.Log(gameObject.name);

        //Audio de l'objet
        audio.PlayOneShot(objetClique);

        //Réinitialise la vitesse actuelle
        rb.linearVelocity = Vector2.zero;

        if (direction)
        {
            //Ajoute une force
            rb.AddForce(new Vector2(forceX * 1, forceY), ForceMode2D.Impulse);

            //Change la direction de l'impulsion
            direction = false;
        }
        else
        {
            //Ajoute une force
            rb.AddForce(new Vector2(forceX * -1, forceY), ForceMode2D.Impulse);

            //Change la direction de l'impulsion
            direction = true;
        }
    }
}