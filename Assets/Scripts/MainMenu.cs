using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMenu : MonoBehaviour
{
    public void OpenLevel()
    {
        SceneManager.LoadScene("LevelScreen");
    }
}