using UnityEngine;
using UnityEngine.EventSystems;

public class Objet : MonoBehaviour
{
    Rigidbody2D rb;

    //Audio
    public AudioSource sourceAudio;
    public AudioClip objetClique;

    //Force du saut
    public float forceSaut = 5f;

    //Limites
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4.15f;
    public float maxY = 4.15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Limite du décor
        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }

    public void AuClic(BaseEventData eventData)
    {
        //Audio de l'objet
        sourceAudio.PlayOneShot(objetClique);

        //Réinitialise la vitesse actuelle
        rb.linearVelocity = Vector2.zero;

        //Ajoute une force vers le haut
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

        Debug.Log(gameObject.name);
    }
}