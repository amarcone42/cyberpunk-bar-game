using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DrinkIsFullException : System.Exception
{
    
    public DrinkIsFullException(){}

    public DrinkIsFullException(string message) 
        : base(message){}
   
}
