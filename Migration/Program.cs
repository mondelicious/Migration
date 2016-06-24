using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            checkDB();
            createDB();
            createTBL();
            insertDT();
        }

        public static void checkDB()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost; Uid=root; Pwd=;");

                string strCheck = "SHOW DATABASES LIKE 'db_pldt'";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strCheck, conn);
                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    Console.WriteLine("Database exists!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Database does not exist!");
                    Console.ReadLine();
                    createDB();
                }
                conn.Close();
            }
            catch
            {
                Console.WriteLine("Check if the sql engine is running, if not then start it!");

            }
        }
        

        public static void createTBL()
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost; Database=db_pldt; Uid=root; Pwd=;");

            string strCheck = "SHOW TABLES LIKE 'tbl_account'";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(strCheck, conn);
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("Table exists!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Table does not exists!");
                Console.ReadLine();
                Console.WriteLine("Creating table for the program");
                Console.ReadLine();

                try
                {
                    MySqlConnection connection = new MySqlConnection("Server=localhost; port=3306; Uid=root; Pwd=;");

                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandText = "USE db_pldt CREATE TABLE tbl_account(Employee_ID INT NOT NULL, First_name VARCHAR(250), Last_name VARCHAR(250), Email VARCHAR(250), Username VARCHAR(250), Password VARCHAR(250), UserType VARCHAR(250), Contact_number VARCHAR(250), Position VARCHAR(250) PRIMARY KEY(Employee_ID))";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Successfully created the Table");
                    Console.ReadLine();
                    connection.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Cannot Create table it's either existing already or database is not connected");
                    Console.ReadLine();
                }

            }
            conn.Close();
        }

        public static void createDB()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost; port=3306;Uid=root;Pwd=;");

                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "CREATE DATABASE db_pldt";
                command.ExecuteNonQuery();

                Console.WriteLine("Successfully created the database!");
                Console.ReadLine();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot Create Database or the database already exist?", "System");
                Console.ReadLine();
            }
        }

        public static void insertDT()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost; Database=db_pldt; port=3306;Uid=root;Pwd=;");

                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tbl_account(Employee_ID,Username,Password,UserType)VALUES('1','judes','1234','Admin')";
                command.ExecuteNonQuery();

                Console.WriteLine("Successfully added to the table!");
                Console.ReadLine();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot add data to the table.", "System");
                Console.ReadLine();
            }
        }

        //public static void createEmployee()
        //{
        //    try
        //    {
        //        MySqlConnection connection = new MySqlConnection("Server=localhost; port=3306; Uid=root; Pwd=pisokins22;");

        //        connection.Open();
        //        MySqlCommand command = new MySqlCommand();
        //        command.Connection = connection;
        //        command.CommandText = "USE db_pldt CREATE TABLE tbl_employee()";
        //        command.ExecuteNonQuery();

        //        Console.WriteLine("Successfully created the Table");
        //        Console.ReadLine();
        //        connection.Close();
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Cannot Create table it's either existing already or database is not connected");
        //        Console.ReadLine();
        //    }
        //}

    }
}
