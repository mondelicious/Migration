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
            createEmployee();
            insertDT();
        }

        //check database command
        public static void checkDB()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost; Uid=root; Pwd=vans;");

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
                }
                conn.Close();
            }
            catch
            {
                Console.WriteLine("Check if the sql engine is running, if not then start it!");
            }
        }

        //create database command
        public static void createDB()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost; port=3306;Uid=root;Pwd=vans;");

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

        //create table command
        public static void createTBL()
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost; Database=db_pldt; Uid=root; Pwd=vans;");

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
                    MySqlConnection connection = new MySqlConnection("Server=localhost; Database=db_pldt; Uid=root; Pwd=vans;");

                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandText = "CREATE TABLE tbl_account(Employee_ID INT NOT NULL, First_name VARCHAR(250), Last_name VARCHAR(250), Email VARCHAR(250), Username VARCHAR(250), Password VARCHAR(250), UserType VARCHAR(250), Contact_number VARCHAR(250), Position VARCHAR(250) PRIMARY KEY(Employee_ID))";
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

        //public static void createtblAccount()
        //{
        //    try
        //    {
        //        MySqlConnection connection = new MySqlConnection("Server=localhost; port=3306; Uid=root; Pwd=vans;");

        //        connection.Open();
        //        MySqlCommand command = new MySqlCommand();
        //        command.Connection = connection;
        //        command.CommandText = "USE db_pldt CREATE TABLE tbl_account(Employee_ID INT NOT NULL, First_name VARCHAR(250), Last_name VARCHAR(250), Email VARCHAR(250), Username VARCHAR(250), Password VARCHAR(250), UserType VARCHAR(250), Contact_number VARCHAR(250), Position VARCHAR(250) PRIMARY KEY(Employee_ID))";
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

       
        //insert actual data to the table
        public static void insertDT()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost; Database=db_pldt; port=3306;Uid=root;Pwd=vans;");

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

        //creating table tbl_employee
        public static void createEmployee()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server=localhost;Database=db_pldt; port=3306; Uid=root; Pwd=vans;");

                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE tbl_employee(Telephone_number VARCHAR(250), Service_Order VARCHAR(250), Type_of_Service VARCHAR(250), Time VARCHAR(250), Clrm_dispatch VARCHAR(250), Ok_no INT(11), Primary_cable VARCHAR(250), Secondary_cable VARCHAR(250), No_of_Span VARCHAR(250), Instrument_Modem VARCHAR(250), Paralleled_wire VARCHAR(250), Jacketed_wire VARCHAR(250), Protector VARCHAR(250), P_clamp VARCHAR(250), Ground_rod VARCHAR(250), Ground_wire VARCHAR(250), Connecting_block VARCHAR(250), Splitter VARCHAR(250), Subscriber_name VARCHAR(250), Address VARCHAR(250), Remarks VARCHAR(250), Installer_technician VARCHAR(250), Immediate_supervisor VARCHAR(250), Csoz_supervisor VARCHAR(250), Customer_service_Operation_zone VARCHAR(250), Submitted_by VARCHAR(250), Noted_by VARCHAR(250), Received_by VARCHAR(250))";
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

    }
}
