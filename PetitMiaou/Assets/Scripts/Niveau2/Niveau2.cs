using UnityEngine;

public class Niveau2 : MonoBehaviour
{
    //Objet du jeu
    public GameObject visuelChat;
    public GameObject elemennts;
    public GameObject boutonMenu;
    public GameObject boutonFermer;
    public GameObject pannelMenu;

    //Position des objets
    public Transform chat;
    public Transform bain;
    public Transform brosse;
    public Transform canard;
    public Transform savon;
    public Transform shampoing;
    public Transform revitalisant;

    //Liste des objets
    private Transform[] positionsChat;

    //Variables int
    public int nombreChance = 3;
    private int positionChat;

    //Audio
    public AudioSource audio;
    public AudioClip miaou;
    public AudioClip bravo;
    public AudioClip perte;

    //Page cliquable
    public bool clic = false;

    void Awake()
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

    void Start()
    {
        //Empêche les cliques avant la fin des instructions
        clic = false;

        //Mise en place du visuel
        boutonMenu.SetActive(true);
        boutonFermer.SetActive(true);
        pannelMenu.SetActive(false);
        visuelChat.SetActive(false);
        elemennts.SetActive(true);

        //Début de la partie après les instructions
        Invoke("NouvellePartie", 4f);
    }

    public void NouvellePartie()
    {
        //Réactive le clic
        clic = true;

        //Affiche le chat caché
        visuelChat.SetActive(true);

        //Réinitialisation des chances
        nombreChance = 3;

        //Remise du chat à l'arrière
        chat.GetComponent<SpriteRenderer>().sortingOrder = 2; //https://docs.unity3d.com/ScriptReference/SpriteRenderer.html

        //Cachette aléatoire
        positionChat = Random.Range(0, positionsChat.Length);

        //Déplace le chat
        chat.position = positionsChat[positionChat].position;

        //Debug.Log("Nouvelle position : " + positionChat);
    }

    //Vérifie la cachette cliquée
    public void VerificationClic(int index, Cachette cache)
    {
        //Si le chat est trouvé
        if (index == positionChat)
        {
            cache.BonneReponse();
            Gagner();
        }
        //Si le chat n'est pas trouvé, le joueur à encore 3 chances
        else
        {
            nombreChance--;
            cache.MauvaiseReponse();
            audio.PlayOneShot(perte);
            //Debug.Log("Mauvaise cachette - Chances restantes : " + nombreChance);
            if (nombreChance <= 0)
            {
                Perdu();
            }
        }
    }

    public void Perdu()
    {
        //Désactive le clic
        clic = false;

        //Debug.Log("Perdu!");
        //Le chat sort de sa cachette
        chat.GetComponent<SpriteRenderer>().sortingOrder = 4;

        //Et fait miaou
        audio.PlayOneShot(miaou);

        //Puis une autre partie commence
        Invoke("NouvellePartie", 2f);
    }

    public void Gagner()
    {
        //Désactive le clic
        clic = false;

        //Debug.Log("Gagné!");
        //Le chat sort de sa cachette
        chat.GetComponent<SpriteRenderer>().sortingOrder = 4;

        //Et fait miaou
        audio.PlayOneShot(miaou);

        //Un message de bravo est annoncé avant d'appeler le menu de fin
        audio.PlayOneShot(bravo);
        Invoke("Fin", 3f);
    }

    public void Fin()
    {
        //Mise en place du visuel de fin
        boutonMenu.SetActive(false);
        boutonFermer.SetActive(false);
        pannelMenu.SetActive(true);
        visuelChat.SetActive(false);
        elemennts.SetActive(false);
    }
}