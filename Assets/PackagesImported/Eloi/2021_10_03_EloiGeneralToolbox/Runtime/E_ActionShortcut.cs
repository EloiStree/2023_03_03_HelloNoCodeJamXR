using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi { 
public class E_ActionShortcut : MonoBehaviour
{
    public delegate void ClassicMethodeCallNoArgument();

    
    public static void IfElse(in bool condition, in ClassicMethodeCallNoArgument ifTrue, in ClassicMethodeCallNoArgument ifFalse)
    {
        if (condition)
        {
            if(ifTrue!=null)
                ifTrue();
        }
        else
        {
            if (ifFalse != null)
                ifFalse();
        
        }
    }
}

}