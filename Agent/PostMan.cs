using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{

    //Class handling sending and eventually receiving data between agent and database
    class PostMan
    {
        static public void SendMessanges(List<string> messanges)
        {
            //Need to be implemented by OloFasolo
            //All messanges are send by this machine so
            var Sender = StationInformation.StudentFirstAndLastName;
            var SendFrom = StationInformation.HostName;

            foreach (string msg in messanges)
            {
              //Send it !  
            }
        }

        public void Send(object Something)
        {
            //Just to show idea, need to implement
        }

        public object Receive(object WhatToReceive)
        {
            //Just to show idea, need to implement
            return null;
        }
    }
}
