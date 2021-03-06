﻿using System;
using Microsoft.Data.SqlClient;

namespace _02.VillianNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Database=MinionsDB ;User Id=sa;Password=Password123@jkl#";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string query =
                    @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                    FROM Villains AS V
                    JOIN MinionsVillains AS mv
                    ON v.Id = mv.VillainId
                    GROUP BY v.Id,v.Name
                    HAVING COUNT (mv.VillainId) > 3
                    ORDER BY COUNT (mv.VillainId)";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
                string firstname = sqlReader["Name"]?.ToString();
                string countOfMinions = sqlReader["MinionsCount"]?.ToString();
                Console.WriteLine($"{firstname} - {countOfMinions}");
            }

            sqlConnection.Close();
        }
    }
}