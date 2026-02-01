using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void StartGame() {
        SceneManager.LoadScene("EscapeRoom");
    }

    public void QuitGame() { 
        Application.Quit();
        Debug.Log("Quit Game");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
