using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    //Niveau1
    public void ChargerNiveau1()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("Niveau 1 chargé");
        
    }

    //Niveau2
    public void ChargerNiveau2()
    {
        SceneManager.LoadScene(2);
        //Debug.Log("Niveau 2 chargé");
    }

    //Niveau3
    public void ChargerNiveau3()
    {
        SceneManager.LoadScene(3);
        //Debug.Log("Niveau 3 chargé");
    }

    //Accueil
    public void RetourAccueil()
    {
        SceneManager.LoadScene(0);
        //Debug.Log("Menu chargé");
    }

    //Recharger le niveau courant
    public void RechargerCourant()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //Debug.Log("Scène rechargée : " + scene.name);
    }
}
