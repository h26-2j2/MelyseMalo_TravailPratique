using UnityEngine;
using UnityEngine.EventSystems;

public class InstructionNiveau1 : MonoBehaviour
{
    //Audio
    public AudioSource audio;
    public AudioClip instructions;

    //Temps et délais
    public float delaiInactif = 15f;
    float tempsInactif = 0f;

    //Position de la souris
    Vector3 positionSouris;
    void Start()
    {
        //Initialisation des variables
        audio = GetComponent<AudioSource>();
        positionSouris = Input.mousePosition;

        //Premier lancement des instructions (après l'animation qui dure 3.5seconde)
        Invoke("Instructions", 3.5f);
    }
    
    void Update()
    {
        //Verifie si la souris bouge
        if (Input.mousePosition != positionSouris) 
        {
            tempsInactif = 0f;
            //Debug.Log("La souris a bougé");
        }

        else
        {
            tempsInactif += Time.deltaTime;
            //Debug.Log("Temps inactif : " + tempsInactif);
        }

        //Mise à jour de la position de la souris
        positionSouris = Input.mousePosition;
        //Debug.Log("Position de la souris : " + positionSouris);

        //Si le temps est écouler, relancer les instructions
        if (tempsInactif >= delaiInactif)
        {
            Instructions();
            tempsInactif = 0f;
            //Debug.Log("Instructions données. Temps inactif : " + tempsInactif);
        }
    }

    //Instructions audio
    void Instructions()
    {
        audio.PlayOneShot(instructions);
        //Debug.Log("Audio joué");

    }
}
