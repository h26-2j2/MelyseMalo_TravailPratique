using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public void ChargerScene()
    {
        SceneManager.LoadScene("Niveau1");
        Debug.Log("Niveau 1 chargé");
        //SceneManager.LoadScene(1);
    }
    public void RetourMenu()
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
    public void QuitterJeu()
    {
        Application.Quit();
    }
    
    
}
