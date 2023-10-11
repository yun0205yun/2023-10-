#r "nuget: System.Data.SqlClient, 4.8.5"
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HAMSTER;Integrated Security=True;";

        // 使用 using 保證資源正確釋放
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // 開啟資料庫連接
                connection.Open();

                // 執行 SQL 查詢
                string sql = "SELECT * FROM HAMSTER";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // 使用 SqlDataReader 讀取結果
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int HamsterID =reader.GetInt32(0);
                            string Name =  reader.GetString(1);
                            int Age =  reader.GetInt32(2);
                            string Color =  reader.GetString(3);

                            Console.WriteLine($"ID: {HamsterID}, Name: {Name}, Age: {Age}, Color: {Color}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
