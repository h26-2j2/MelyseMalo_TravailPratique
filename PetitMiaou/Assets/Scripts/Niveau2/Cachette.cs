using UnityEngine;

public class Cachette : MonoBehaviour
{
    public Niveau2 niveau;
    //Index de l'objet
    public int index;

    //Détect l'objet cliqué
    private void OnMouseDown()
    {
        Debug.Log("Objet cliqué: " + gameObject.name);
        niveau.VerificationClique(index);
    }
}