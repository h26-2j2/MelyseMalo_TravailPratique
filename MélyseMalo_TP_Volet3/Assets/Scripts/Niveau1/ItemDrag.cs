using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    //Audio
    public AudioSource audio;
    public AudioClip son;

    //Zone de Drop (Gamelle)
    public ZoneDrop zoneDrop = null;

    //Repas associer
    public GameObject repas;

    void Start()
    {
        //Initialisation des variables
        audio = GetComponent<AudioSource>();
        repas.SetActive(false);
    }

    //Début du drag
    public void OnBeginDrag(BaseEventData eventData)
    {
        transform.SetParent(null);
        GetComponent<Collider2D>().enabled = false;
        audio.PlayOneShot(son); //Son de l'aliment choisit
        //Debug.Log("Debut Drag");
    }

    //Drag
    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        Vector3 positionPointeur = Camera.main.ScreenToWorldPoint(pointerData.position);
        positionPointeur.z = 0;
        transform.position = positionPointeur;
        //Debug.Log("Drag");
    }

    //Fin du drag
    public void OnEndDrag(BaseEventData eventData)
    {
        GetComponent<Collider2D>().enabled = true;
        repas.SetActive(true); //Visuel du repas dans la gamelle
        //Debug.Log("Fin Drag");
    }
    
}
