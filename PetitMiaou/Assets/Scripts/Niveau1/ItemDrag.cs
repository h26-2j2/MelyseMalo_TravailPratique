using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip son;
    public ZoneDrop zoneDrop = null;
    public GameObject repas;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        repas.SetActive(false);
    }

    // Fonciton OnBeginDrag : Exécutée quand on commence le drag.
    // - Enlève le parent de ce Transform.
    // - Désactive le Collider2D pour éviter des bugs de détection.
    public void OnBeginDrag(BaseEventData eventData)
    {
        transform.SetParent(null);
        GetComponent<Collider2D>().enabled = false;
        audio.PlayOneShot(son);
        Debug.Log("Debut Drag");
    }

    // Fonction OnDrag : Exécutée pendant qu'on glisse ce bloc.
    // - Récupère les infos du pointeur et le traite comme un PointerEventData.
    // - On fait la conversion d'une position du pointeur à l'écran (en pixels)
    // à une position au monde (en unités).
    // - On téléporte le bloc à la position de la souris
    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        Vector3 positionPointeur = Camera.main.ScreenToWorldPoint(pointerData.position);
        positionPointeur.z = 0;
        transform.position = positionPointeur;
        Debug.Log("Drag");
    }
    // Fonction OnEndDrag : Exécutée quand le drag est fini.
    // - On réactive le Collider.
    public void OnEndDrag(BaseEventData eventData)
    {
        GetComponent<Collider2D>().enabled = true;
        repas.SetActive(true);
        Debug.Log("Fin Drag");
    }
    
}
