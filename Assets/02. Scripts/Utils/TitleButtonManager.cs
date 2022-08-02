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
        // �񵿱������� Scene�� �ҷ����� ���� Coroutine�� ����Ѵ�.
        StartCoroutine(LoadMyAsyncScene());
    }

    IEnumerator LoadMyAsyncScene()
    {
        // AsyncOperation�� ���� Scene Load ������ �� �� �ִ�.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

        // Scene�� �ҷ����� ���� �Ϸ�Ǹ�, AsyncOperation�� isDone ���°� �ȴ�.
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
