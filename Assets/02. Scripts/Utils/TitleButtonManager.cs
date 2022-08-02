using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    public bool isSettingPanel = false;

    public void NewGame()
    {
        SceneManager.LoadScene("Gaon");
    }

    public void NewGameAsync()
    {
        // 비동기적으로 Scene을 불러오기 위해 Coroutine을 사용한다.
        StartCoroutine(LoadMyAsyncScene());
    }

    IEnumerator LoadMyAsyncScene()
    {
        // AsyncOperation을 통해 Scene Load 정도를 알 수 있다.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

        // Scene을 불러오는 것이 완료되면, AsyncOperation은 isDone 상태가 된다.
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadGame()
    {

    }

    public void Setting()
    {

    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
