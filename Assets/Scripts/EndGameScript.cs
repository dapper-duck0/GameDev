uning UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameScript : MonoBehaviour
{
    public void LoadNextSceneByName()
    {
        
        // Replace "SceneName" with the exact name of your target scene
        SceneManager.LoadScene("EndScene");
    }
}