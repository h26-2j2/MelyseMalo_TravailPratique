using UnityEngine;
using UnityEngine.EventSystems;

public class Cachette : MonoBehaviour
{
    public Niveau2 niveau;
    //Index de l'objet
    public int index;

    //Détect l'objet cliqué
    public void AuClic(BaseEventData eventData)
    {
        Debug.Log("Objet cliqué: " + gameObject.name);
        niveau.VerificationClic(index);
    }
}