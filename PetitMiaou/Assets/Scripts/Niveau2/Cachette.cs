using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cachette : MonoBehaviour
{
    public Niveau2 niveau;

    //Index de l'objet
    public int index;

    //Animation
    public Animator animator;

    //Détect l'objet cliqué
    public void AuClic(BaseEventData eventData)
    {
        Debug.Log("Objet cliqué: " + gameObject.name);
        niveau.VerificationClic(index, this);
    }

    //Appelé si bonne réponse
    public void BonneReponse()
    {
        animator.SetTrigger("Bulle");
    }

    //Appelé si mauvaise réponse
    public void MauvaiseReponse()
    {
        animator.SetTrigger("Erreur");
    }
}