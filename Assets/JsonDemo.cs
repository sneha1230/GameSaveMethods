using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;

public class JsonDemo : MonoBehaviour
{
    public string Name;
    public int Age;
    public string[] Friends;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }
    void SavePlayerData()
    {
        string filePath = Application.persistentDataPath +"/JsonDemo.sav";
        JObject jobj = new JObject();
        jobj.Add("componentName", this.Name);

        JObject jdataDemo = new JObject();
        jobj.Add("data", jdataDemo);
        jdataDemo.Add("name", "abcd");
        jdataDemo.Add("_curHp",this.Age);

        JArray jarraydata = JArray.FromObject(Friends);
        jdataDemo.Add("_friends", jarraydata);

        StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(jobj.ToString());
        //print(jdataDemo.ToString());
        sw.Close();
        
        
    }

    void GetPlayerData()
    {
        string filePath = Application.persistentDataPath +"/JsonDemo.sav";
        print(filePath);
        StreamReader sr = new StreamReader(filePath);
        string data = sr.ReadToEnd();
        sr.Close();
        print(data);

        JObject dataDemo = JObject.Parse(data);
        Name=dataDemo["componentName"].Value<string>();
        Age=dataDemo["data"]["_curHp"].Value<int>();
        Friends=dataDemo["data"]["_friends"].ToObject<string[]>();
    }
}
