using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionaryNS
{
    public struct Input
    {
        public string command;
        public string? key;
        public List<string>? values;
        /// <summary>
        /// Input struct to handle user inputs with multiple values. 
        /// </summary>
        /// <param name="userInput"></param>
        public Input(List<string> userInput)
        {
            command = userInput[0];
            if (userInput.Count > 1)
            {
                key = userInput[1];
            }
            else
            {
                key = null;
            }
            if (userInput.Count > 2)
            {
                //Skip the first two values of user input and all remaning values to value list. This is to allow user to enter as many values as desired.
                values = new List<string>();
                values.AddRange(userInput.Skip(2));
            }
            else
            {
                values = null;
            }
        }
    }
}