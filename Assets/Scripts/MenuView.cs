using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _pauseText;
    [SerializeField] private GameObject _startText;

    private void Start()
    {
        _pauseButton.onClick.AddListener(Pause);
        _restartButton.onClick.AddListener(Restart);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveListener(Pause);
        _restartButton.onClick.RemoveListener(Restart);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

    private void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        _pauseText.gameObject.SetActive(!_pauseText.gameObject.activeSelf);
        _startText.gameObject.SetActive(!_startText.gameObject.activeSelf);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
