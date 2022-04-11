using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionaryNS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> commandArgs = new();
            Console.WriteLine("Welcome to the MultiValueDictionary App!");
            Console.WriteLine("Use command HELP to see available commands");
            while (true)
            {
                Console.Write(">");
                commandArgs.AddRange(Console.ReadLine().Split());

                if (commandArgs[0].ToLower() == "exit")
                {
                    break;
                }
                Input input = new(commandArgs);
                Commands(input);
                commandArgs.Clear();
            }
        }
        /// <summary>
        /// Command function to handle all user input. If this solution was to be scaled up, error handling would be pulled out and delt with separately  
        /// </summary>
        /// <param name="input"></param>
        public static void Commands(Input input)
        {
            MultiValueDictionary multiValueDictionary = new();
            switch (input.command.ToLower())
            {
                case "keys":
                    multiValueDictionary.Keys();
                    break;
                case "members":
                    if (string.IsNullOrEmpty(input.key))
                    {
                        Console.WriteLine("ERROR, a key must be entered");
                    }
                    else
                    {
                        multiValueDictionary.Members(input.key);
                    }
                    break;
                case "add":
                    if (string.IsNullOrEmpty(input.key))
                    {
                        Console.WriteLine("ERROR, a key must be entered");
                    }
                    else if (input.values == null || !input.values.Any())
                    {
                        Console.WriteLine("ERROR, a value must be entered");
                    }
                    else
                    {
                        multiValueDictionary.Add(input.key, input.values);
                    }
                    break;
                case "remove":
                    if (string.IsNullOrEmpty(input.key))
                    {
                        Console.WriteLine("ERROR, a key must be entered");
                    }
                    else if (input.values == null || !input.values.Any())
                    {
                        Console.WriteLine("ERROR, a value must be entered");
                    }
                    else
                    {
                        multiValueDictionary.Remove(input.key, input.values[0]);
                    }
                    break;
                case "removeall":
                    if (string.IsNullOrEmpty(input.key))
                    {
                        Console.WriteLine("ERROR, a key must be entered");
                    }
                    else
                    {
                        multiValueDictionary.RemoveAll(input.key);
                    }
                    break;
                case "clear":
                    multiValueDictionary.Clear();
                    break;
                case "keyexists":
                    if (string.IsNullOrEmpty(input.key))
                    {
                        Console.WriteLine("ERROR, a key must be entered");
                    }
                    else
                    {
                        multiValueDictionary.KeyExists(input.key);
                    }
                    break;
                case "memberexists":
                    if (string.IsNullOrEmpty(input.key))
                    {
                        Console.WriteLine("ERROR, a key must be entered");
                    }
                    else if (input.values == null || !input.values.Any())
                    {
                        Console.WriteLine("ERROR, a value must be entered");
                    }
                    else
                    {
                        multiValueDictionary.MemberExists(input.key, input.values[0]);
                    }
                    break;
                case "allmembers":
                    multiValueDictionary.AllMembers();
                    break;
                case "items":
                    multiValueDictionary.Items();
                    break;
                case "help":
                    Console.WriteLine("Commands: \nKEYS \nMEMBERS \nADD \nREMOVE \nREMOVEALL \nCLEAR \nKEYEXISTS \nMEMBEREXISTS \nALLMEMBERS \nITEMS");
                    break;
                default:
                    Console.WriteLine("ERROR, invalid command");
                    break;
            }
        }
    }
}
