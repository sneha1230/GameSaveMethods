using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Windows;

public class DemoSaveMethods : MonoBehaviour
{
    string SystemName=Environment.MachineName.ToString();
    string systemResolutionInFloat;
    float systemMemory;
    // Start is called before the first frame update
    void Start()
    {
        Resolution systemResolution=Screen.currentResolution;
        systemResolutionInFloat=systemResolution.ToString();
        systemMemory =SystemInfo.systemMemorySize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SetPlayerData();
        }
         if(Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }


    void SetPlayerData()
    {
        /*PlayerPrefs.SetInt("Score",1000);
        PlayerPrefs.SetString("Name","XYZ");
        PlayerPrefs.SetString("Time","3:00");
        print("saved the player score");
        print("saved the player Name");
        print("saved the player Time");*/

        string filePath=Application.persistentDataPath+"/Myfile.file";
        //StreamWriter sw=new StreamWriter(filePath);
        FileStream fs=new FileStream (filePath,FileMode.OpenOrCreate);
        BinaryWriter sw=new BinaryWriter(fs);
        sw.Write(SystemName);
        sw.Write(systemResolutionInFloat);
        sw.Write((double)systemMemory);
        fs.Close();
        sw.Close();
    }

    void GetPlayerData()
    {
        /*int score=PlayerPrefs.GetInt("Score");
        print("the player score is"+score);
        string name=PlayerPrefs.GetString("Name");
        print("the player name is"+name);
        string time=PlayerPrefs.GetString("Time");
        print("the player time is"+time);*/

        string filePath=Application.persistentDataPath+"/Myfile.file";
       // StreamReader sr=new StreamReader(filePath);
        FileStream fs=new FileStream (filePath,FileMode.Open);
        BinaryReader sw=new BinaryReader(fs);
        SystemName=sw.ReadString();
        systemResolutionInFloat=sw.ReadString();
        systemMemory=((float)sw.ReadDouble());
        Debug.Log("System Name: "+SystemName+ "System Resolution: "+systemResolutionInFloat+ "System Memory: "+systemMemory);
        //print(line);
        fs.Close();
        sw.Close();
    }
}
