using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public GameObject loadscene;
    public Slider slider;
    public Text text;



    public void loadassignedscene(string scenename)    
    {
        StartCoroutine(LoadScene(scenename));
    }
    public void loadassignedscene(int sceneindex=1)
    {
        StartCoroutine(LoadScene(sceneindex));
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadScene(string scenename)
    {

        loadscene.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);
        operation.allowSceneActivation=false;

        if(!MainMenu.isnewgame)
        {
            SaveFunction.instance.savegame();
        }
        if(MainMenu.isnewgame)
        {
            Boss1.islive = true;
            Boss2.islive = true;
        }
        while (!operation.isDone)
        {
            slider.value = operation.progress;

            text.text = operation.progress * 100 + "%";

            yield return null;
        }
        Time.timeScale = 1;
        operation.allowSceneActivation = true ;
        loadscene.SetActive(false);
    }

    IEnumerator LoadScene(int sceneindex=1)
    {
        loadscene.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        operation.allowSceneActivation =false;

        if (!MainMenu.ismenu)
        {
            SaveFunction.instance.savegame();
        }
        if (MainMenu.isnewgame)
        {
            Boss1.islive = true;
            Boss2.islive = true;
        }
        while (operation.progress<0.9f)
        {
            slider.value = operation.progress;

            text.text = operation.progress * 100 + "%";

            yield return null;
        }
        slider.value = 100;
        Time.timeScale = 1;
        operation.allowSceneActivation = true;
        loadscene.SetActive(false);
    }
}
