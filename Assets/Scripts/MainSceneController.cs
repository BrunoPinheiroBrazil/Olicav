using UnityEngine;

public class MainSceneController : MonoBehaviour
{
  public GameObject pauseMenu;

  private void Start()
  {
    SetupInitialConfig();
  }

  private void SetupInitialConfig()
  {
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = true;
    pauseMenu.SetActive(false);
  }

  private void Update()
  {
    ValidatePauseGame();
  }

  private void ValidatePauseGame()
  {
    var escape = Input.GetButtonDown("Cancel");

    if (!escape)
      return;

    var isActive = !pauseMenu.activeSelf;

    pauseMenu.SetActive(isActive);

    if (isActive)
    {
      Time.timeScale = 0.0f;
    }
    else
    {
      Time.timeScale = 1.0f;
    }
  }

  public void ExitGame()
  {
    Application.Quit();
  }
}
