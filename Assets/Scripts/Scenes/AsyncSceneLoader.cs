using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private GameObject _loaderCanvas;
    private WaitForSeconds _sleep = new WaitForSeconds(0.01f);

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadLevelCoroutine(index));
    }

    private IEnumerator LoadLevelCoroutine(int index)
    {
        _loaderCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);

        _progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(index);
        scene.allowSceneActivation = false;

        while (scene.progress != 0.9f)
        {
            _progressBar.fillAmount = scene.progress;
            yield return _sleep;
        }

        _progressBar.fillAmount = scene.progress;
        scene.allowSceneActivation = true;
        //_loaderCanvas.SetActive(false);
    }
}