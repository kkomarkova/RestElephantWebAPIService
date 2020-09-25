using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCustomerServiceSample1.Model
{
    public class FakeDbList
    {
        public static List<Elephants> elephants = new List<Elephants>()
        {
            new Elephants(1,"POMMY" , 1000 , "ASIAN"),
            new Elephants(2,"Tony" , 4009 , "African"),
            new Elephants(3,"Jony" , 5000 , "South-ASIAN"),
            new Elephants(4,"Lilly" , 6000 , "South-african"),
            new Elephants(5,"Danny" , 7000 , "North-america")
        };
    }
}
