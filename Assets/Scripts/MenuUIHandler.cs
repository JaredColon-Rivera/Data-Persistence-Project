using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField field;
   
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void NameEntered()
    {
        Debug.Log(field.text);
        GameControl.Instance._playerName = field.text;
    }

    public void ExitGame()
    {
  
#if (UNITY_EDITOR)
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
  
    }

}
