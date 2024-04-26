using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitScene : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public float Animation;
    public int Scene;
    private void Start()
    {
        StartCoroutine(Waiting());
        
    }
    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Animation);
        sceneChanger.ChangeScene(Scene);
        
    }
}
