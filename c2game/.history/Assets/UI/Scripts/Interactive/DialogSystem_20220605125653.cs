using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("场景跳转")]
    public GameObject loadingscene;
    public int sceneindex;

    [Header("UI组件")]
    public Text TextLablel;
    public Image FaceImage;

    [Header("文本文件")]
    public TextAsset TextFile;
    public int index;
    public float textspeed;

    [Header("头像")]
    public List<Sprite> faces;

    bool linefinished;
    bool canceltyping;

    List<string> textList= new List<string>();

    // Start is called before the first frame update
    private void Awake() {
      GetTextFromFile(TextFile);
      index=0;
    }

    private void OnEnable() {
      // TextLablel.text=textList[index];
      // index++;
      linefinished=true;
      StartCoroutine(setTextUI());
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.R)&&index==textList.Count)
      {
        gameObject.SetActive(false);
        index=0;
        return;
      }
      if(Input.GetKeyDown(KeyCode.R))
      {
        // TextLablel.text=textList[index];
        // index++;
        if(linefinished&& !canceltyping)
        {
          StartCoroutine(setTextUI());
        }
        else if(!linefinished)
        {
          canceltyping=true;
        }
      }
    }

    void GetTextFromFile(TextAsset file)
    {
      textList.Clear();
      index=0;

      //切割文本
      var lineData= file.text.Split('\n');
      foreach (var line in lineData)
      {
        textList.Add(line);
      }
    }

    IEnumerator setTextUI()
    {
      linefinished=false;
      TextLablel.text="";

      //切换头像
      switch(textList[index])
      {
        case "旁白\r":
          FaceImage.sprite=faces[0];
          index++;
          break;
        case "杨凌\r":
          FaceImage.sprite=faces[1];
          index++;
          break;
        case "大仙\r":
          FaceImage.sprite=faces[2];
          index++;
          break;
        case "梦魔\r":
          FaceImage.sprite=faces[3];
          index++;
          break;
        case "魇魔\r":
          FaceImage.sprite=faces[4];
          index++;
          break;
        case "同学A\r":
          FaceImage.sprite=faces[5];
          index++;
          break;
        case "同学B\r":
          FaceImage.sprite=faces[6];
          index++;
          break;
      }

      for(int i=0;i<textList[index].Length&&!canceltyping;i++)
      {
        TextLablel.text+=textList[index][i];

        yield return new WaitForSeconds(textspeed);
      }
      TextLablel.text=textList[index];
      canceltyping=false;
      linefinished=true;
      index++;
      // if(linefinished!=true)
      // {
      //   linefinished=true;
      //   index++;
      // }
    }
}
