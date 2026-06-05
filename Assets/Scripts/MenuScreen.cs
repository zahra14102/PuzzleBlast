using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gamesceen");
    }
}