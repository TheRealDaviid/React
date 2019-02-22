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

public class GetData : MonoBehaviour
{
    string conn;
    string sqlQuery;
    IDbConnection dbconnect;
    IDbCommand dbcmd;
    string spielzeitalt = "";
    Stopwatch stopwatch = new Stopwatch();
    // Use this for initialization
    public void Start()
    {

        conn = "URI=file:" + Application.dataPath + "/Plugins/Reactdb.db"; //Path to database

     


        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;



    }
    private void SubmitName(string name)
    {
        UnityEngine.Debug.Log(name);
    }

    

    //public void insertvalue(string name, string spielzeitgsm, int richtigegsm, int falschegsm, int punktegsm)
    //{
    //    using (dbconnect = new SqliteConnection(conn))
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

    public void insertvalue(string spielzeitgsm)
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
    void Update()
    {

    }
}
