using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        
        SqliteDatabase db;
        if(!dbDictionary.TryGetValue(fileName, out db))
        {
            db = new SqliteDatabase(fileName);
            dbDictionary.Add(fileName, db);
        }    
        return db;
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
