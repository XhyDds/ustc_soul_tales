using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFunction : MonoBehaviour
{
    public static SaveFunction instance;

    public Button savebtn;
    public Button loadbtn;

    private void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        instance = this;
    }

    private void Start()
    {
        if(savebtn!=null)
            savebtn.onClick.AddListener(delegate { savegame(); });
        if(loadbtn!=null)
            loadbtn.onClick.AddListener(delegate { loadgame(); });
    }

    public void savegame()
    {
        Save save = Player.instance.CreateSaveGameobject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        file.Flush();
        bf.Serialize(file, save);
        file.Close();
    }
    
    public int loadgame()
    {
        if(File.Exists(Application.persistentDataPath+"/gamesave.save"))
        {
            //无需清空(因为不存即时位置,怪物全部要更新)
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);

            Player.instance.LoadSaveGameobject(save);

            file.Close();
            return 1;
        }
        else
        {
            savegame();
            return 0;
        }
    }
}
