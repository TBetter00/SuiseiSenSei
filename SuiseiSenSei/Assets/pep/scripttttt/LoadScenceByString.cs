using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenceByString : MonoBehaviour
{
    public string ScenceName;

    public void ChangeScenceByName()
    {
        SceneManager.LoadScene(ScenceName);
    }
}
