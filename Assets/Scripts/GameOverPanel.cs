using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{

    [SerializeField] private SOChannelEvent _onPlayerWin;
    [SerializeField] private SOChannelEvent _onPlayerLose;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private Button _reloadButton;
    private void Start()
    {
        _onPlayerWin.Event.AddListener(OnPlayerWin);
        _onPlayerLose.Event.AddListener(OnPlayerLose);
        _reloadButton.onClick.AddListener(OnReloadClicked);
        this.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        _onPlayerWin.Event.RemoveListener(OnPlayerWin);
        _onPlayerLose.Event.RemoveListener(OnPlayerLose);
        _reloadButton.onClick.RemoveListener(OnReloadClicked);

    }
    private void OnPlayerLose() 
    {
        this.gameObject.SetActive(true);
        _message.text = "You Lose";
    }
    private void OnPlayerWin() 
    {
        this.gameObject.SetActive(true);
        _message.text = "You Win";

    }
    private void OnReloadClicked() 
    {
        SceneManager.LoadScene(0);
    }
}
