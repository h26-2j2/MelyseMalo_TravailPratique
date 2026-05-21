using UnityEngine;
using UnityEngine.EventSystems;

public class ConsignesAudio : MonoBehaviour
{
    //Audio
    public AudioSource audio;
    public AudioClip instructionsDebut;
    public AudioClip instructions;

    //Temps et délais
    public float delaiInitial = 0f; 
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
        Invoke("InstructionsDebut", delaiInitial);
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

    //Première instructions audio
    void InstructionsDebut()
    {
        audio.PlayOneShot(instructionsDebut);
        //Debug.Log("Audio joué");

    }
    
    //Instructions audio
    void Instructions()
    {
        audio.PlayOneShot(instructions);
        //Debug.Log("Audio joué");

    }
}
