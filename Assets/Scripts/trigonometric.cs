using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class trigonometric : MonoBehaviour
{
    public InputField a;
    public InputField b;
    public InputField c;
    public InputField angleA;
    public InputField angleB;
    public static string m_aContent;
    public static string m_bContent;
    public static string m_cContent;
    public static string m_angleAContent;
    public static string m_angleBContent;
    // Start is called before the first frame update

    string aContent = "";
    string bContent = "";
    string cContent = "";
    string angleAContent = "";
    string angleBContent = "";

    public void Clear()
    {
        a.text = "";
        b.text = "";
        c.text = "";
        angleA.text = "";
        angleB.text = "";
        m_aContent = "" ;
        m_bContent = "" ;
        m_cContent = "" ;
        m_angleAContent = "" ;
        m_angleBContent = "" ;
        aContent = "";
        bContent = "";
        cContent = "";
        angleAContent = "";
        angleBContent = "";
        a.enabled = true;
        b.enabled = true;
        c.enabled = true;
        angleA.enabled = true;
    

    }
    public void ShowResult()
    {
        a.text = m_aContent;
        b.text = m_bContent;
        c.text = m_cContent;
        angleA.text = m_angleAContent;
        angleB.text = m_angleBContent;
    }
    public void Test()
    {
        aContent = a.GetComponent<InputField>().text;
        bContent = b.GetComponent<InputField>().text;
        cContent = c.GetComponent<InputField>().text;
        angleAContent = angleA.GetComponent<InputField>().text;
        angleBContent = angleB.GetComponent<InputField>().text;
        
        
        angleB.enabled = false;
        if (aContent.Length > 0)
        {
            
            // if (angleAContent.Length >0) 
            // {
            //     b.text = (Convert.ToDouble(aContent) * Math.Tan(Convert.ToDouble(angleAContent))).ToString();
            // }
            if (bContent.Length > 0) 
            {
                cContent = (Math.Sqrt(Math.Pow(Convert.ToDouble(aContent),2) + Math.Pow(Convert.ToDouble(bContent),2))).ToString();
                angleAContent = (Math.Atan(Convert.ToDouble(bContent)/Convert.ToDouble(aContent)) * 180 / Math.PI).ToString();
                m_aContent = aContent;
                m_cContent = cContent;
                m_bContent = bContent;
                m_angleAContent = angleAContent;
                m_angleBContent = angleBContent;
                c.enabled = false;
                angleA.enabled = false;
                
            }

            if (cContent.Length > 0)
            {
                bContent = (Math.Sqrt(Math.Pow(Convert.ToDouble(cContent),2) - Math.Pow(Convert.ToDouble(aContent),2))).ToString();
                angleAContent = (Math.Acos(Convert.ToDouble(aContent)/Convert.ToDouble(cContent)) * 180 / Math.PI).ToString();
                m_aContent = aContent;
                m_cContent = cContent;
                m_bContent = bContent;
                m_angleAContent = angleAContent;
                m_angleBContent = angleBContent;
                b.enabled = false;
                angleA.enabled = false;
            }

            if (angleAContent.Length > 0)
            {
                bContent = (Convert.ToDouble(aContent) * Math.Tan(Convert.ToDouble(angleAContent)*Math.PI/180)).ToString();
                cContent = (Convert.ToDouble(aContent) / Math.Cos(Convert.ToDouble(angleAContent)*Math.PI/180)).ToString();
                m_aContent = aContent;
                m_cContent = cContent;
                m_bContent = bContent;
                m_angleAContent = angleAContent;
                m_angleBContent = angleBContent;
              
                c.enabled = false;
                b.enabled = false;
            }
        }

    

        if (bContent.Length > 0)
        {
        

            if (angleAContent.Length > 0)
            {
                aContent = (Convert.ToDouble(bContent) / Math.Tan(Convert.ToDouble(angleAContent)*Math.PI/180)).ToString();
                cContent = (Convert.ToDouble(bContent) / Math.Sin(Convert.ToDouble(angleAContent)*Math.PI/180)).ToString();
                m_aContent = aContent;
                m_cContent = cContent;
                m_bContent = bContent;
                m_angleAContent = angleAContent;
                m_angleBContent = angleBContent;
                a.enabled = false;
                c.enabled = false;
            }

            if (cContent.Length > 0)
            {
                aContent = (Math.Sqrt(Math.Pow(Convert.ToDouble(cContent),2) - Math.Pow(Convert.ToDouble(bContent),2))).ToString();
                angleAContent = (Math.Asin(Convert.ToDouble(bContent)/Convert.ToDouble(cContent)) * 180 / Math.PI).ToString();
                m_aContent = aContent;
                m_cContent = cContent;
                m_bContent = bContent;
                m_angleAContent = angleAContent;
                m_angleBContent = angleBContent;
                a.enabled = false;
                angleA.enabled = false;
            }
        }

        if (cContent.Length > 0)
        {
            if (angleAContent.Length > 0)
            {
                aContent = (Convert.ToDouble(cContent) * Math.Cos(Convert.ToDouble(angleAContent)*Math.PI/180)).ToString();
                bContent = (Convert.ToDouble(cContent) * Math.Sin(Convert.ToDouble(angleAContent)*Math.PI/180)).ToString();
                m_aContent = aContent;
                m_cContent = cContent;
                m_bContent = bContent;
                m_angleAContent = angleAContent;
                m_angleBContent = angleBContent;
                a.enabled = false;
                b.enabled = false;
            }
        }

    
       
        
    }
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
