using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScreen : MonoBehaviour
{
    public GameObject playButton;

    bool isLoading = false;

    public void PlayGame()
    {
        if (!isLoading)
        {
            StartCoroutine(LoadGame());
        }
    }

    IEnumerator LoadGame()
    {
        isLoading = true;

        float timer = 0;

        while (timer < 2f)
        {
            playButton.transform.Rotate(0, 0, -300 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("Gamesceen");
    }
}