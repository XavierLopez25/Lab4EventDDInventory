using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    [Header("Player Components to Disable")]
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private StarterAssetsInputs starterInputs;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private MonoBehaviour playerRaycastInteractor;

    [Header("Sounds")]
    [SerializeField] private AudioSource uiAudioSource;
    [SerializeField] private AudioClip pauseOpenSound;


    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        thirdPersonController.enabled = true;
        starterInputs.enabled = true;
        playerInput.enabled = true;
        playerRaycastInteractor.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        uiAudioSource.PlayOneShot(pauseOpenSound);

        thirdPersonController.enabled = false;
        starterInputs.enabled = false;
        playerInput.enabled = false;
        playerRaycastInteractor.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenu");
    }
}
