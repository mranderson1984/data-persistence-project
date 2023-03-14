using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public void StartClicked()
    {
        GameDataManager.instance.SetPlayerName(nameInput.text);
        SceneManager.LoadScene(1);
    }

    public void ExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
