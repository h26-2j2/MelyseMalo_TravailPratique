using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneDrop : MonoBehaviour
{
    //Game object
    public GameObject pointSnap;
    public GameObject chat;
    public GameObject verreLait;
    public GameObject verreEau;
    public GameObject sacCroquettes;
    public GameObject cannePate;
    public GameObject lait;
    public GameObject eau;
    public GameObject croquettes;
    public GameObject pate;

    //Position initial des objets
    Vector3 positionInitialChat;
    Vector3 positionInitialeLait;
    Vector3 positionInitialeEau;
    Vector3 positionInitialePate;
    Vector3 positionInitialeCroquettes;

    //Audio
    public AudioSource audio;
    public AudioClip miaou;

    void Start()
    {
        //Initialisation des variables
        positionInitialChat = chat.transform.position;
        positionInitialeLait = verreLait.transform.position;
        positionInitialeEau = verreEau.transform.position;
        positionInitialePate = cannePate.transform.position;
        positionInitialeCroquettes = sacCroquettes.transform.position;
    }

    //Objet déposé dans la zone
    public void OnDrop(BaseEventData eventData)
    {
        PointerEventData data = eventData as PointerEventData;

        //Recupere l'objet drag pour le mettre au milieu de la gamelle
        GameObject objet = data.pointerDrag;
        if (objet != null)
        {
            objet.transform.position = pointSnap.transform.position;
        }

        //Appel de la Fonction DeplacementChat() après 1 seconde
        Invoke("DeplacementChat", 1f);

    }

    //Mini animation du déplacement du chat avec effet sonore.
    public void DeplacementChat()
    {
        //Deplacement du chat et effet sonore
        chat.transform.position = new Vector3(0, -1f, 0);
        audio.PlayOneShot(miaou);

        //Appel de la Fonction Replacer() après 1 seconde
        Invoke("Replacer", 1f);
    }

    //Retour au stade initial
    public void Replacer()
    {
        //Enlève le parent
        chat.transform.SetParent(null);
        verreLait.transform.SetParent(null);
        verreEau.transform.SetParent(null);
        cannePate.transform.SetParent(null);
        sacCroquettes.transform.SetParent(null);

        //Remet les objets à leur position initiale
        chat.transform.position = positionInitialChat;
        verreLait.transform.position = positionInitialeLait;
        verreEau.transform.position = positionInitialeEau;
        cannePate.transform.position = positionInitialePate;
        sacCroquettes.transform.position = positionInitialeCroquettes;
        
        //Désactive le visuel de la nourriture
        lait.SetActive(false);
        eau.SetActive(false);
        pate.SetActive(false);
        croquettes.SetActive(false);
    }
}