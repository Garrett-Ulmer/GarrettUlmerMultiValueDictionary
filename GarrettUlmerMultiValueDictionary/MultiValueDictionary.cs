using System;
using System.Collections.Generic;

namespace MultiValueDictionaryNS
{
    /// <summary>
    /// This class provides additional methods for the Dictionary type. 
    /// In a scalable solution, this class would inherit from a IMultiValueDictionary Interface
    /// </summary>
    public class MultiValueDictionary
    {
        private static Dictionary<string, List<string>> _multiValueDictionary = new();


        /// <summary>
        /// Returns all the keys in the dictionary.  Order is not guaranteed.
        /// </summary>
        /// <returns></returns>
        public List<string> Keys()
        {
            List<string> keys = new List<string>();
            int count = 0;
            if (_multiValueDictionary.Keys.Count == 0)
            {
                Console.WriteLine("ERROR, no keys exist");
            }
            else
            {
                foreach (var key in _multiValueDictionary.Keys)
                {
                    ++count;
                    Console.WriteLine(count + ") " + key);
                    keys.Add(key);
                }
            }
            return keys;
        }
        /// <summary>
        /// Returns the collection of strings for the given key.  Return order is not guaranteed.  Returns an error if the key does not exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>List of members</returns>
        public List<string> Members(string key)
        {
            List<string> values = new List<string>();
            int count = 0;
            if (!_multiValueDictionary.ContainsKey(key))
            {
                Console.WriteLine("ERROR, key does not exist");
            }
            else
            {
                foreach (var value in _multiValueDictionary[key])
                {
                    ++count;
                    Console.WriteLine("{0}) {1}", count, value);
                    values.Add(value);
                }
            }
            return values;
        }

        /// <summary>
        /// Adds a member to a collection for a given key. Displays an error if the member already exists for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void Add(string key, List<string> values)
        {
            if (_multiValueDictionary.ContainsKey(key))
            {
                foreach (string value in values)
                {
                    if (_multiValueDictionary[key].Contains(value))
                    {
                        Console.WriteLine("ERROR, {0} member already exists for {1} key", value, key);
                    }
                    else
                    {
                        _multiValueDictionary[key].Add(value);
                        Console.WriteLine("{0} member added to {1} key", value, key);
                    }
                }
            }
            else
            {
                _multiValueDictionary.Add(key, values);
                foreach (string value in values)
                {
                    Console.WriteLine("{0} member added to {1} key", value, key);
                }
            }
            return;
        }
        /// <summary>
        /// Removes a member from a key.  If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, displays an error.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Remove(string key, string value)
        {
            if (_multiValueDictionary.ContainsKey(key))
            {
                if (_multiValueDictionary[key].Contains(value))
                {
                    _multiValueDictionary[key].Remove(value);
                    Console.WriteLine("{0} member removed from {1} key", value, key);
                    if (_multiValueDictionary.Count == 0)
                    {
                        _multiValueDictionary.Remove(key);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR, member does not exist");
                }
            }
            else
            {
                Console.WriteLine("ERROR, key does not exist");
            }
            return;

        }
        /// <summary>
        /// Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveAll(string key)
        {
            if (_multiValueDictionary.ContainsKey(key))
            {
                _multiValueDictionary.Remove(key);
                Console.WriteLine("Removed {0} key and all its members", key);
            }
            else
            {
                Console.WriteLine("ERROR, key does not exist");
            }
            return;
        }

        /// <summary>
        /// Removes all keys and all members from the dictionary.
        /// </summary>
        public void Clear()
        {
            _multiValueDictionary.Clear();
            Console.WriteLine("Cleared");
            return;
        }
        /// <summary>
        /// Returns whether a key exists or not.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            bool keyExistsBool = _multiValueDictionary.ContainsKey(key);
            Console.WriteLine(keyExistsBool);
            return keyExistsBool;
        }

        /// <summary>
        /// Returns whether a member exists within a key.  Returns false if the key does not exist.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool MemberExists(string key, string value)
        {
            bool memberExistsBool;
            if (!_multiValueDictionary.ContainsKey(key))
            {
                return false;
            }
            memberExistsBool = _multiValueDictionary[key].Contains(value);
            Console.WriteLine(memberExistsBool);
            return memberExistsBool;

        }

        /// <summary>
        /// Returns all the members in the dictionary.  Returns nothing if there are none. Order is not guaranteed.
        /// </summary>
        /// <returns></returns>
        public List<string> AllMembers()
        {
            int count = 0;
            List<string> members = new List<string>();
            if (_multiValueDictionary.Values.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                foreach (List<string> value in _multiValueDictionary.Values)
                {
                    members.AddRange(value);
                }
                foreach (string member in members)
                {
                    count++;
                    Console.WriteLine("{0}) {1}", count, member);
                }
            }
            return members;
        }

        /// <summary>
        /// Returns all keys in the dictionary and all of their members.  Returns nothing if there are none.  Order is not guaranteed.
        /// </summary>
        /// <returns></returns>
        public List<(string, string)> Items()
        {
            int count = 0;
            List<(string, string)> items = new List<(string, string)>();
            if (_multiValueDictionary.Values.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                foreach (string key in _multiValueDictionary.Keys)
                {
                    foreach (string value in _multiValueDictionary[key])
                    {
                        count++;
                        Console.WriteLine("{0}) {1}: {2}", count, key, value);
                        (string, string) tuple = (key, value);
                        items.Add(tuple);
                    }
                }
            }
            return items;
        }
    }
}