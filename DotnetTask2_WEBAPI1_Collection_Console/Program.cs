using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DemoWebAPI_ClientDemo;
using DotnetTask2_WEBAPI1_Collection_Console;

namespace DemoWebAPI_ClientDemo

{

    internal class Program

    {

        static async Task Main(string[] args)

        {

            // Base URL of the ASP.NET Core Web API

            string apiBaseUrl = " http://localhost:5103/api/Employee"; //you need to change url according to your web api

            HttpClient client = new HttpClient();

            try

            {

                Console.WriteLine("Fetching products from the Web API...");

                // Make an HTTP GET request

                List<Employee> Emps = await client.GetFromJsonAsync<List<Employee>>(apiBaseUrl);

                if (Emps != null && Emps.Count > 0)

                {

                    //Console.WriteLine("List of Products from SQL Server Products Table:");

                    Console.WriteLine("List of Products from Products Collection:");

                    foreach (var e in Emps)

                    {

                        Console.WriteLine("Employee ID:" + e.Id + ",  Name:" + e.Name + "  Department:" + e.Department+" Mobile No:-"+e.MobileNo+" EMail:-"+e.Email);

                    }

                }

                else

                {

                    Console.WriteLine("No products found.");

                }

            }

            catch (HttpRequestException ex)

            {

                Console.WriteLine("Exception from API:" + ex.Message);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Unknown Exception Occurred..!!:" + ex.Message);

            }

        }

    }

}

