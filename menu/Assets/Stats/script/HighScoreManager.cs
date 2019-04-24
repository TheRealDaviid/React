using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;



class HighScoreManager
    {
        

        
        public string ScoreID { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string Datum { get; set; }
        public int richtiganz { get; set; }
        public int falscheanz { get; set; }


        public HighScoreManager(string scoreid, string name, int score, string date, int richtige, int falsche)
        {
            ScoreID = scoreid;
            Name = name;
            Score = score;
            Datum = date;
            richtiganz = richtige;
            falscheanz = falsche;
            

        }
    }

