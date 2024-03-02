using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
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
      if(Input.GetKeyDown(KeyCode.R)&&linefinished==true)
      {
        // TextLablel.text=textList[index];
        // index++;
        StartCoroutine(setTextUI());
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
        case "A":
          FaceImage.sprite=faces[0];
          break;
        case "B":
          FaceImage.sprite=faces[1];
          break;
      }

      for(int i=0;i<textList[index].Length;i++)
      {
        TextLablel.text+=textList[index][i];

        yield return new WaitForSeconds(textspeed);
      }
      linefinished=true;
      index++;
      // if(linefinished!=true)
      // {
      //   linefinished=true;
      //   index++;
      // }
    }
}
