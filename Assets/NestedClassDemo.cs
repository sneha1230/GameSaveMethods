using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class NestedClassDemo : MonoBehaviour
{

    string playerName="XYZ";
    int playerAge=15;
    int playerScore=100;
    string playerLocation="hyd";
    [System.Serializable]
    public class DataDemo
    {
        public string playerName;
        public  int playerAge;
        public int playerScore;
        public string playerLocation;
        public DataDemo(string _playerName,int _playerAge,int _playerScore,string _playerLocation)
        {
            this.playerName=_playerName;
            this.playerAge=_playerAge;
            this.playerScore=_playerScore;
            this.playerLocation = _playerLocation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
        }
         if(Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }

    void SavePlayerData()
    {
        string filePath=Application.persistentDataPath+"/NestedDemo.file";
        BinaryFormatter bw = new BinaryFormatter();
        FileStream fs=new FileStream(filePath,FileMode.OpenOrCreate);
        DataDemo dm=new DataDemo(playerName,playerAge,playerScore,playerLocation);
        bw.Serialize(fs,dm);
        fs.Close();
    }

    void GetPlayerData()
    {
        string filePath=Application.persistentDataPath+"/NestedDemo.file";
        BinaryFormatter bwr = new BinaryFormatter();
        FileStream fsm=new FileStream(filePath,FileMode.OpenOrCreate);
        DataDemo dataDM=bwr.Deserialize(fsm) as DataDemo;
        print("Name: " + dataDM.playerName + "Age: " + dataDM.playerAge + "Score: " + dataDM.playerScore + "Location: "+dataDM.playerLocation);
        fsm.Close();
    }
}
