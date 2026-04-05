using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace GameOfLife.Data {
    public class GameRepository {
        private static GameRepository _instance = null!; 
        private string _connStr = "Server=localhost;Database=GameLifeDB;Trusted_Connection=True;Encrypt=False";
        private GameRepository() { }

        public static GameRepository Instance {
            get {
                if (_instance == null) {
                    _instance = new GameRepository();
                }
                return _instance;
            }
        }

        public void SaveState(string gridData) {
            using (SqlConnection conn = new SqlConnection(_connStr)) {
                SqlCommand cmd = new SqlCommand("INSERT INTO InitialStates (State) VALUES (@s)", conn);
                cmd.Parameters.AddWithValue("@s", gridData);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> LoadSavedStates() {
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connStr)) {
                SqlCommand cmd = new SqlCommand("SELECT State FROM InitialStates", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    string data = reader["State"]?.ToString() ?? "";
                    list.Add(data);
                }
            }
            return list;
        }
    }
}