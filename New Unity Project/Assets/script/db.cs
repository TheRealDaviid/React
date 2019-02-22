using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.Threading;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class db : MonoBehaviour {
    string conn;
    string sqlQuery;
    IDbConnection dbconnect;
    IDbCommand dbcmd;
    string spielzeitalt = "";
    Stopwatch stopwatch = new Stopwatch();
    // Use this for initialization
    public void Start () {
       
        conn = "URI=file:" + Application.dataPath + "/Plugins/Reactdb.db"; //Path to database
        
        spielzeitalt = readers();
        stopwatch.Start();

        
        


    }
   

    void OnDestroy()
    {
        
        if (spielzeitalt != "") // weitere Male inserten
        {


            //DateTime myDate = DateTime.ParseExact(spielzeitalt, "hh:mm:ss.ff", System.Globalization.CultureInfo.CurrentCulture);
            //DateTime myDate = Convert.ToDateTime(spielzeitalt);
            //DateTime d;
            TimeSpan tsold = TimeSpan.Parse(spielzeitalt);
            UnityEngine.Debug.Log("Insgesamte Spielzeit: " + tsold.ToString());
            UnityEngine.Debug.Log("Zeit vergangen: " + stopwatch.Elapsed.Seconds.ToString() + " Sekunden");
            stopwatch.Stop();
            TimeSpan tsnew = new TimeSpan(stopwatch.Elapsed.Days+tsold.Days,stopwatch.Elapsed.Hours+tsold.Hours,stopwatch.Elapsed.Minutes+tsold.Minutes,stopwatch.Elapsed.Seconds+tsold.Seconds);
            
            
            //tsold.Add(tsnew);            
            //myDate.AddHours(stopwatch.Elapsed.Hours);
            //myDate.AddMinutes(stopwatch.Elapsed.Minutes);
            //myDate.AddSeconds(stopwatch.Elapsed.Seconds);
            //d = new DateTime(myDate.Year,myDate.Month,myDate.Day,myDate.Hour+stopwatch.Elapsed.Hours,myDate.Minute+stopwatch.Elapsed.Minutes,myDate.Second+stopwatch.Elapsed.Seconds);
            insertvalue(tsnew.ToString());

            UnityEngine.Debug.Log("insgesammte Spielzeit: " + tsnew.ToString());
           // UnityEngine.Debug.Log("insgesammte Spielzeit: " + myDate.ToString());
        }
        else //erstes mal inserten
        {
            stopwatch.Stop();
            TimeSpan a = new TimeSpan(stopwatch.Elapsed.Days, stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds);
            UnityEngine.Debug.Log("Zeit vergangen: " + a.ToString() + " Sekunden");
            insertvalue(a.ToString());
        }
        
        UnityEngine.Debug.Log("Das Programm wurde beendet");

    }




    //public void insertvalue(string name, string spielzeitgsm, int richtigegsm, int falschegsm, int punktegsm)
    //{
    //    using (mdonnect = new SqliteConnection(conn))
    //    {
    //        dbconnect.Open(); //Open connection to the database.
    //        dbcmd = dbconnect.CreateCommand();
    //        sqlQuery = string.Format("insert into User (name, spielzeitgsm, richtigegsm, falschegsm, punktegsm) values (\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", name, spielzeitgsm, richtigegsm, falschegsm, punktegsm);// table name
    //        dbcmd.CommandText = sqlQuery;
    //        dbcmd.ExecuteScalar();
    //        dbconnect.Close();
    //    }
    //}
    //private void Deletvalue(int id)
    //{
    //    using (dbconnect = new SqliteConnection(conn))
    //    {
    //        dbconnect.Open(); //Open connection to the database.
    //        dbcmd = dbconnect.CreateCommand();
    //        sqlQuery = string.Format("Delete from User WHERE ID=\"{0}\"", id);// table name
    //        dbcmd.CommandText = sqlQuery;
    //        dbcmd.ExecuteScalar();
    //        dbconnect.Close();
    //    }
    //}

    public void insertvalue( string spielzeitgsm)
    {
        using (dbconnect = new SqliteConnection(conn))
        {
            dbconnect.Open(); //Open connection to the database.
            dbcmd = dbconnect.CreateCommand();
            sqlQuery = string.Format("insert into Spielzeit (spielzeitgsm) values (\"{0}\")", spielzeitgsm);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconnect.Close();
        }
    }

    public string readers()
    {
        using (dbconnect = new SqliteConnection(conn))
        {

            dbconnect = (IDbConnection)new SqliteConnection(conn);
            dbconnect.Open(); //öffne die Verbindung zur Datenbank
            IDbCommand dbcommand = dbconnect.CreateCommand();
            string sqlQuery = "SELECT * " + "FROM Spielzeit";
            dbcommand.CommandText = sqlQuery;
            IDataReader reader = dbcommand.ExecuteReader();
            string spielzeitgsm = "";
            while (reader.Read())
            {
                spielzeitgsm = reader.GetString(0);
               
            }
            reader.Close();

            reader = null;
            dbcommand.Dispose();
            dbcommand = null;
            dbconnect.Close();
            dbconnect = null;
            return spielzeitgsm;
        }
    }

    //public void readers()
    //{
    //    using (dbconnect = new SqliteConnection(conn))
    //    {

    //        dbconnect = (IDbConnection)new SqliteConnection(conn);
    //        dbconnect.Open(); //öffne die Verbindung zur Datenbank
    //        IDbCommand dbcommand = dbconnect.CreateCommand();
    //        string sqlQuery = "SELECT * " + "FROM User";
    //        dbcommand.CommandText = sqlQuery;
    //        IDataReader reader = dbcommand.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            int id = reader.GetInt32(0);
    //            string Name = reader.GetString(1);
    //            int zeitgsm = reader.GetInt32(2);
    //            int richtigegsm = reader.GetInt32(3);
    //            int falschgsm = reader.GetInt32(4);
    //            int punktegsm = reader.GetInt32(5);

    //            UnityEngine.Debug.Log("\n id = " + id + "\t name = " + Name + "\t Zeit gesamt = " + zeitgsm + "\t Richtige gesamt = " + richtigegsm + "\t Falsche gesamt = " + falschgsm + "\t Punkte gesamt = " + punktegsm);
    //        }
    //        reader.Close();

    //        reader = null;
    //        dbcommand.Dispose();
    //        dbcommand = null;
    //        dbconnect.Close();
    //        dbconnect = null;
    //    }
    //}

    // Update is called once per frame
    void Update () {
		
	}
}
