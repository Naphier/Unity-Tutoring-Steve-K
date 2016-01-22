using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DBController : MonoBehaviour
{
    private Dictionary<string,SqliteDatabase> dbDictionary = new Dictionary<string,SqliteDatabase>();
    private static DBController _instance;
    public static DBController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DBController>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    private SqliteDatabase GetDatabase(string fileName)
    {
        string path = Application.dataPath + "/StreamingAssets/";

        if (Application.platform == RuntimePlatform.Android)
            path = "jar:file://" + Application.dataPath + "?/assets/";
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            path = Application.dataPath + "/Raw/";

        if (!File.Exists(path + fileName))
        {
            Debug.LogError("Failed to find db file at: " + path + fileName);
            return null;
        }


        SqliteDatabase db;
        if(!dbDictionary.TryGetValue(fileName, out db))
        {
            db = new SqliteDatabase(fileName);
            dbDictionary.Add(fileName, db);
        }    
        return db;
    }

    public void DumpDB(string fileName)
    {
        SqliteDatabase db = GetDatabase(fileName);

        if (db == null)
        {
            Debug.LogError("db not found for file name: " + fileName);
            return;
        }

        string qry = "SELECT name FROM sqlite_master WHERE type='table'";

        DataTable tableList = db.ExecuteQuery(qry);
        foreach (DataRow row in tableList.Rows)
        {
            foreach (KeyValuePair<string,object> item in row)
            {
                Debug.LogWarningFormat("Table Name: {0}", item.Value);
                string tableQry = "SELECT * FROM '" + item.Value.ToString() + "'";
                DataTable tableData = db.ExecuteQuery(tableQry);
                foreach (DataRow tableRow in tableData.Rows)
                {
                    foreach (KeyValuePair<string, object> elem in tableRow)
                    {
                        Debug.LogFormat("{0}: {1}" , elem.Key, elem.Value);
                    }
                }
            }
        }
    }

    public bool IsWordValid(string word)
    {
        return IsWordValid(word, "example_db.db");
    }

    public bool IsWordValid(string word , string dbFileName)
    {
        SqliteDatabase db = GetDatabase(dbFileName);
        if (db == null)
        {
            Debug.LogError("Cannot load database?");
            return false;
        }
        word = word.ToLower();
        string firstLetter = word.Substring(0 , 1);
        string letterCount = word.Length.ToString();
        if (word.Length < 10)
            letterCount = "0" + letterCount;

        string table = firstLetter + letterCount;

        DataTable qry = db.ExecuteQuery("SELECT * FROM '" + table + "' WHERE word='" + word + "'");
        foreach (DataRow row in qry.Rows)
        {
            foreach (KeyValuePair<string, object> kvp in row)
            {
                if (kvp.Value.ToString() == word)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
