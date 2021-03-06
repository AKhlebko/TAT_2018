﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DEV_8
{
    /// <summary>
    /// Event argument which stores info about namesakes
    /// </summary>
    public class NamesakeEventArg : EventArgs
    {
        public List<Person> Namesakes { get; set; }

        public NamesakeEventArg()
        {
            Namesakes = new List<Person>();
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();
            foreach(Person person in Namesakes)
            {
                response.Append(person + "\n");
            }
            return response.ToString();
        }
    }
}
