using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class ZoneDrop : MonoBehaviour
{
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

    Vector3 positionInitialChat;
    Vector3 positionInitialeLait;
    Vector3 positionInitialeEau;
    Vector3 positionInitialePate;
    Vector3 positionInitialeCroquettes;


    void Start()
    {
        positionInitialChat = chat.transform.position;
        positionInitialeLait = verreLait.transform.position;
        positionInitialeEau = verreEau.transform.position;
        positionInitialePate = cannePate.transform.position;
        positionInitialeCroquettes = sacCroquettes.transform.position;
    }
    void Update()
    {
        //Debug.Log("ZoneDrop actif");
    }

    public void OnDrop(BaseEventData eventData)
    {
        PointerEventData data = eventData as PointerEventData;
        GameObject objet = data.pointerDrag;

        if (objet != null)
        {
            objet.transform.position = pointSnap.transform.position;
        }
        Invoke("DeplacementChat", 1f);

    }
    public void DeplacementChat()
    {
        chat.transform.position = new Vector3(0, -1f, 0);
        Invoke("Replacer", 1f);
    }
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