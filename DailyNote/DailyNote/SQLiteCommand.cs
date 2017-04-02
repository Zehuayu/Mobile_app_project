

using SQLite.Net;
using System;


namespace DailyNote
{
    internal class SQLiteCommand
    {
        private SQLiteConnection conn;
        private string sql;

        public SQLiteCommand(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        public SQLiteCommand(string sql, SQLiteConnection conn)
        {
            this.sql = sql;
            this.conn = conn;
        }

        public string CommandText { get; internal set; }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}