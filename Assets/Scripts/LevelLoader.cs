using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public void LoadLevel(int levelIndex)
    {
       StartCoroutine(LoadLevelCoroutine(levelIndex));
    }


    IEnumerator LoadLevelCoroutine(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

    }
}
