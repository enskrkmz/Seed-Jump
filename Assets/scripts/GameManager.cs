using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject retryButton;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
        
    }
    public void Dead()
    {
        retryButton.SetActive(true);
        Time.timeScale = 0;
    }
}
