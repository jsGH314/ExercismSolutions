using System;
using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    { 
        // Stacks are FILO, so when we pop() from stack we get the last added element (top of stack)
        Stack<char> stack = new Stack<char>();

        foreach(char ch in input)
        {
            // Check for opening brackets
            if (ch == '{' || ch == '(' || ch == '[')
                // If bracket is found, add to stack (count != 0)
                stack.Push(ch);
            // Check for closing brackets
            else if (ch == '}' || ch == ')' || ch == ']') 
            {
                // Returns false if no opening brackets have been added to stack
                // (Not balanced/paired)
                if (stack.Count == 0) 
                    return false;
                // If a closing bracket is found, pop last added element from stack 
                // and set as 'top/start' bracket
                char top = stack.Pop();

                // If conditions are not met here, it means brackets are not nested properly
                if ((ch == '}' && top != '{') || (ch == ')' && top != '(') || (ch == ']' && top != '['))
                    return false;
            }
        }
        // If all goes well, the stack will have a count of zero
        return stack.Count == 0;       
    }
}
