using UnityEngine;

public class Niveau2 : MonoBehaviour
{
    public Transform chat;

    public Transform bain;
    public Transform brosse;
    public Transform canard;
    public Transform savon;
    public Transform shampoing;
    public Transform revitalisant;

    private Transform[] positionsChat;

    public int nombreChance = 3;

    private int positionChat;

    private void Awake()
    {
        //Liste des positions possibles du chat [https://www.w3schools.com/cs/cs_arrays.php]
        positionsChat = new Transform[]
        {
            bain,
            brosse,
            canard,
            savon,
            shampoing,
            revitalisant
        };
    }

    private void Start()
    {
        NouvellePartie();
    }

    public void NouvellePartie()
    {
        //Réinitialisation des chances
        nombreChance = 3;

        //Remise du chat à l'arrière
        chat.GetComponent<SpriteRenderer>().sortingOrder = 2; //https://docs.unity3d.com/ScriptReference/SpriteRenderer.html

        //Cachette aléatoire
        positionChat = Random.Range(0, positionsChat.Length);

        //Déplace le chat
        chat.position = positionsChat[positionChat].position;

        Debug.Log("Nouvelle position : " + positionChat);
    }

    //Vérifie la cachette cliquée
    public void VerificationClique(int index)
    {
        if (index == positionChat)
        {
            Gagner();
        }
        else
        {
            nombreChance--;
            Debug.Log("Mauvaise cachette - Chances restantes : " + nombreChance);
            if (nombreChance <= 0)
            {
                Perdu();
            }
        }
    }

    void Perdu()
    {
        Debug.Log("Perdu!");
        chat.GetComponent<SpriteRenderer>().sortingOrder = 4;
        Invoke("NouvellePartie", 2f);
    }

    void Gagner()
    {
        Debug.Log("Gagné!");
        chat.GetComponent<SpriteRenderer>().sortingOrder = 4;
        Invoke("NouvellePartie", 2f);
    }
}