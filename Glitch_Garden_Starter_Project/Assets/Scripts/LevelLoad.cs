using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

	void Start () {
        //This is how the tutorial sets up the splash screen/start menu
        //sequence. I've disabled it because I don't want to hear the
        //splash screen sound 20 times when I grade the homework.

        //But try to understand what it's doing. To see it in action,
        //un-comment this block, then go to Build Settings and
        //check the box next to Splash Screen.
        //Don't forget to un-check it again!

        //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if (currentSceneIndex == 0)
        //{
        //    StartCoroutine(WaitForTime());
        //}
	}

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }
	
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

	void Update () {
		
	}
}
