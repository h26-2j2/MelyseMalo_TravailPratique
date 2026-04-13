using UnityEngine;
using UnityEngine.EventSystems;

public class JeuNiveau1 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public AudioSource audio;
    public AudioClip son;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void OnBeginDrag (PointerEventData eventData)
    {
        Debug.Log("Début Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Début Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Début Drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Début Drag");
    }
}
