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

    //Détecte l'objet cliqué
    public void AuClic(BaseEventData eventData)
    {
        //Empêche de cliquer n'importe quand
        if (!niveau.clic)
        {
            return;
        }

        //Debug.Log("Objet cliqué: " + gameObject.name);
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