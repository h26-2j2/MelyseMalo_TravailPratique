using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public void ChargerNiveau1()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Niveau 1 chargé");
        
    }

    public void ChargerNiveau2()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Niveau 2 chargé");
    }

    public void ChargerNiveau3()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Niveau 3 chargé");
    }

    public void RetourAccueil()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Menu chargé");
    }

    public void RechargerCourant()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log("Scène rechargée : " + scene.name);
    }
    public void Muet()
    {
        Debug.Log("Muet");
    }

    //https://www.youtube.com/watch?v=DX7HyN7oJjE
}
