using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;


namespace Hangman
{
   public class DatabaseManager
    {
        public SQLiteConnection dbconn;
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public DatabaseManager()
        {
            dbconn = new SQLiteConnection(System.IO.Path.Combine(folder, "Game.db"));


            dbconn.CreateTable<Player>();
            if(dbconn.Table<Player>().Count()==0)
            {
                DemoData();
            }

        }
        public List<Player> ViewAllSortByName()
        {
            try
            {
                return dbconn.Query<Player>("SELECT * FROM Player ORDER BY PlayerName");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }
        public void DemoData()
        {
            Player p = new Player();
            p.PlayerName = "Guest";
            p.BestScore = 0;
            dbconn.Insert(p);
        }
        public void add(string pname)
        {
            Player nplayer = new Player();
            nplayer.PlayerName = pname;
            dbconn.Insert(nplayer);
        }
        public bool checkPlayer(String name)
        {
            List<Player> player = dbconn.Query<Player>("Select PlayerName from Player ");
            for(int i=0;i<player.Count;i++)
            {
                if(player[i].Equals(name))
                {
                    return true;
                }
              
            }
            return false;
        }
    }
}