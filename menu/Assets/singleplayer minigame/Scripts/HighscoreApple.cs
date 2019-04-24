using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class HighscoreApple : MonoBehaviour
{

    static string conn;
    static string sqlQuery;
    static IDbConnection dbconnect;
    static IDbCommand dbcmd;
    private List<HighScoreManager> highScores = new List<HighScoreManager>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    // Use this for initialization
    public static void Start()
    {

        DateTime theDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

        // {MM:DD:YY}
        string Zeit = theDate.ToString();

        conn = "URI=file:" + Application.dataPath + "/Plugins/Reactdb.db"; //Path to database


        // InsertScore("888", 125, Zeit, 5, 10, 2, 2);
        //  InsertScore("120", 187,  Zeit, 5, 10, 2, 2);
        //  getScore();
        // DeleteScore(5);
        //ShowScores();

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void getScore()
    {
        using (dbconnect = new SqliteConnection(conn))
        {
            highScores.Clear();

            dbconnect = new SqliteConnection(conn);
            dbconnect.Open(); //öffne die Verbindung zur Datenbank
            IDbCommand dbcommand = dbconnect.CreateCommand();
            string sqlQuery = "SELECT  ScoreID, Name, Score, Datum, richtigeanz, falscheanz FROM Scoreliste JOIN USER ON Scoreliste.UserID= USER.UserID WHERE User.UserID = Scoreliste.UserID Order by Score desc;";
            dbcommand.CommandText = sqlQuery;
            IDataReader reader = dbcommand.ExecuteReader();

            while (reader.Read())
            {

                highScores.Add(new HighScoreManager(reader.GetString(0), reader.GetString(1).ToString(), reader.GetInt32(2), reader.GetString(3).ToString(), reader.GetInt32(4), reader.GetInt32(5)));
                Debug.Log("LevelNr: " + reader.GetString(0) + " Name: " + reader.GetString(1) + " Score: " + reader.GetInt32(2) + " Datum: " + reader.GetString(3) + " Anzahl der Richtigen: " + reader.GetInt32(4) + " Anzahl der Falschen: " + reader.GetInt32(5));

            }
            reader.Close();

            reader = null;
            dbcommand.Dispose();
            dbcommand = null;
            dbconnect.Close();
            dbconnect = null;

        }
    }
    public static void InsertScore(string ScoreID, int newScore, string datum, int AnzR, int AnzF, int UserID, int LevelID)
    {


        using (dbconnect = new SqliteConnection(conn))
        {
            dbconnect.Open(); //Open connection to the database.

            using (dbcmd = dbconnect.CreateCommand())
            {

                sqlQuery = string.Format("INSERT INTO Scoreliste(ScoreID, Score, Datum, richtigeanz, falscheanz, UserID, LevelID) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\")", ScoreID, newScore, datum, AnzR, AnzF, UserID, LevelID);// table name
                // Probleme mit dem Foreign Key von LevelID
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconnect.Close();
            }
        }

    }
    public static int GetLastID()
    {

        IDataReader reader;
        int i = 0;
        using (dbconnect = new SqliteConnection(conn))
        {
            dbconnect.Open(); //Open connection to the database.

            using (dbcmd = dbconnect.CreateCommand())
            {
                sqlQuery = string.Format("Select MAX(ScoreID) FROM Scoreliste");
               
                dbcmd.CommandText = sqlQuery;
                
                reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    i = int.Parse(reader.GetString(0));
                }
                reader.Close();
                dbcmd.Dispose();
                dbconnect.Close();

            }
        }
        return i;

    }
    private void DeleteScore(int ID)
    {
        dbconnect.Open(); //Open connection to the database.

        using (dbcmd = dbconnect.CreateCommand())
        {

            sqlQuery = string.Format("DElETE FROM Scoreliste WHERE ScoreID = \"{0}\")", ID);
            // Probleme mit dem Foreign Key von LevelID
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconnect.Close();
        }
    }
    private void ShowScores()
    {
        getScore();
        for (int i = 0; i < highScores.Count; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab); //create run through every single score we have in our highscorelist

            HighScoreManager tmpScore = highScores[i];

            tmpObject.GetComponent<HighScoreScript>().SetScore("#" + (i + 1), tmpScore.Name, tmpScore.Score, tmpScore.Datum, tmpScore.richtiganz, tmpScore.falscheanz); //der name über die tabelle User herausfinden und hineinschreiben

            tmpObject.transform.SetParent(scoreParent);

            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
