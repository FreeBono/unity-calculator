using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Text;

public class NewBehaviourScript : MonoBehaviour
{
    Dictionary<string,int> prec = new Dictionary<string, int>()
    {
        {"*", 3 },
        {"/", 3 },
        {"+", 2 },
        {"-", 2 },
        {"(", 1 },
        {")", 1 }
    };
    
    public int searchError(string input) 
    {
        
        Stack s = new Stack();
        char[] inputs = new char[] {'0','1','2','3','4','5','6','7','8','9','0','.','(',')','+','-','*','/'};
        char[] nums = new char[] {'0','1','2','3','4','5','6','7','8','9','0'};
        char[] operators = new char[] {'+','-','*','/'};
        
        for (int i=0; i < input.Length; i++)
        {
           
       
            if (!inputs.Contains(input[i]))  // 입력 가능한 문자가 아님
            {
                Debug.Log("입력 가능한 문자가 아님");
                return i;
            }
            else if ( i == 0 && operators.Contains(input[i])) // 연산자가 수식의 가장 앞인 경우
            {
                Debug.Log("연산자가 수식의 가장 앞인 경우");
                return i;
            }
            else if (operators.Contains(input[i])) 
            {
                if ( i+1 == input.Length ) // 수식의 마지막이 연산자 일 경우
                {
                    Debug.Log("수식의 마지막이 연산자 일 경우");
                    return i;
                }
                else                      // 연산자가 연속해서 나오는 경우
                {
                    if (operators.Contains(input[i+1])) 
                    {
                        Debug.Log("연산자가 연속해서 나오는 경우");
                        return i+1;
                    }
                }
            }
            else if (input[i] == '(')   // 수식에서 '('가 발견되었을 때 ( 앞에 숫자가 오는경우
            {
                if (nums.Contains(input[i-1]) && i != 0)
                {
                    Debug.Log("수식에서 '('가 발견되었을 때 ( 앞에 숫자가 오는경우");
                    return i;
                }
                else
                {
                    if (s.Count == 0)
                    {
                        s.Push('(');
                    }
                    else
                    {
                        Debug.Log("수식에서 '('가 발견되었을 때 ( 앞에 숫자가 오는경우 s.count >0");
                        return i;
                    }
                }
            }
            
            else if (input[i] == ')')   // 수식에서 ')'가 발견되었을 때 스택이 비어있는 경우
            {
               
                if (s.Count == 0)
                {
                    Debug.Log("수식에서 ')'가 발견되었을 때 스택이 비어있는 경우 s.count == 0");
                    return i;
                }
                else if ( i != input.Length -1 && nums.Contains(input[i+1]))
                {
                    Debug.Log("수식에서 ')'가 발견되었을 때 스택이 비어있는 경우 i != input.Length -");
                    return i+1;
                }
                else
                {
                    Debug.Log("수식에서 ')'가 발견되었을 때 스택이 비어있는 경우 else");
                    s.Push(')');
                }
                
            }
            

        }
        if (s.Count != 0)         // 수식에 '('는 존재 하지만 ')'는 존재하지 않는 경우
        {
            
            if (Convert.ToChar(s.Pop()) == '(')
            {
                return input.Length;
            }
        }
        return -1;
    }
    public List<string> GetOperands(string input) 
    {
        char[] numbers = new char[] {'0','1','2','3','4','5','6','7','8','9','0','.'};
        List<string> operands = new List<string>();

        // "123+45-79"
        int i = 0;
        while (i < input.Length) {
            int j = 1;
            if (numbers.Contains(input[i]))
            {
                while (i+j < input.Length)
                {
                    if (numbers.Contains(input[i+j]))
                    {
                        j += 1 ;
                    }
                    else
                    {
                        break;
                    }
                }
                operands.Add(input.Substring(i,j));
                i += j;
            }
            else 
            {
                operands.Add(input[i].ToString());
                i += 1;
            }
        }
        return operands;
    }
    public List<string> GetPostfix(List<string> input) {
        List<string> postfix = new List<string>();
        Stack s = new Stack();
        StringBuilder jj = new StringBuilder("", 25);
        foreach (string ii in input)
        {
            jj.Append(ii + ", ");
        }
        Debug.Log(jj);
        try
        {
            foreach (string i in input) 
            {
                if (i == "(")
                    s.Push(i);
                else if (i == ")")
                {  
                    while (s.Peek().ToString() != "(")
                    {
                        string temp = s.Pop().ToString();
                        postfix.Add(temp);
                    }
                    s.Pop();
                }
                else if (prec.ContainsKey(i))
                {
                 
                    while (s.Count != 0) 
                    {
                   

                        if (prec[s.Peek().ToString()] >= prec[i])
                        {
                           
                            postfix.Add(s.Pop().ToString());
                        }
                        else
                        {
                            break;
                        }
                    }
                    s.Push(i);
                    
                }
                else
                {
                    postfix.Add(i);
                }
            }


            while (s.Count != 0 )
            {
                postfix.Add(s.Pop().ToString());
            }        
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        
        return postfix;
        
    }
    public double GetResult(List<string> input)
    {
        Stack s = new Stack();
        foreach (string i in input)
        {
            if (prec.ContainsKey(i)) 
            {
                double num1 = Convert.ToDouble(s.Pop());
                double num2 = Convert.ToDouble(s.Pop());
                if (i == "+")
                    s.Push(num2 + num1);
                else if (i == "-")
                    s.Push(num2 - num1);
                else if (i == "*")
                    s.Push(num2 * num1);
                else if (i == "/")
                    s.Push(num2 / num1);
            }
            else
            {
                s.Push(Convert.ToDouble(i));
            }
        }
        return Convert.ToDouble(s.Pop());
    }


    public Text text;
    public Text formulaText;
    public double val = 0;
    public StringBuilder sb = new StringBuilder("");
    
    public void test() 
    {
        string[] inputs = {"0","1","2","3","4","5","6","7","8","9","0",".","(",")","+","-","*","/"};
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(sb);
        if (inputs.Contains(clickObject.GetComponentInChildren<Text>().text))
        {
            sb.Append(clickObject.GetComponentInChildren<Text>().text);
            formulaText.text = sb.ToString();
        }

        if (searchError(sb.ToString()) > -1) {
            Debug.Log(sb);
            return;
        }

        List<string> infix = GetOperands(sb.ToString());
        List<string> postfix = GetPostfix(infix);

        val = GetResult(postfix);

        text.text = val.ToString();

        // string test = "1+2/3*4+(2+5)";
      
        // int check = searchError(test);
        // if (check != -1) return;
        // List<string> infix = GetOperands(test);
        // List<string> postfix = GetPostfix(infix);
        // val = GetResult(postfix);
        // SetVal();
        // Debug.Log(val);

    }

    public void DeleteVal()
    {
        if (sb.ToString().Length <= 1)
        {
            formulaText.text ="";
            text.text ="";
            return;
        }
        sb.Length--;
        formulaText.text = sb.ToString();
        if (searchError(sb.ToString()) > -1) {
            Debug.Log(sb);
            return;
        }

        List<string> infix = GetOperands(sb.ToString());
        List<string> postfix = GetPostfix(infix);

        val = GetResult(postfix);

        text.text = val.ToString();

    }
    public void ClearVal() 
    {
        sb.Clear();
        formulaText.text = "";
        text.text = "";
    }
    public void SetVal()
    {
        if (searchError(sb.ToString()) > -1) {
            Debug.Log(sb);
            return;
        }
        formulaText.text = text.text;
        sb.Clear();
        sb.Append(text.text);
    
    }
    // Start is called before the first frame update
    void Start()
    {
        if (text != null)
            text.text = val.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(val);
    }
}
