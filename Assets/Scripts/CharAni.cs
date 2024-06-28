using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAni : MonoBehaviour
{
    private Animator charAnim;
    private Live2D.Cubism.Framework.Expression.CubismExpressionController expressionControl;
    // Start is called before the first frame update
    void Start()
    {
        charAnim = GetComponent <Animator>();
        expressionControl = GetComponent<Live2D.Cubism.Framework.Expression.CubismExpressionController>();
    }

    // Update is called once per frame
    void Update()
    {
        //characterMotion();
        //FacialEspressions();
        hiyoriAni();
    }

    //void characterMotion()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        charAnim.SetTrigger("mad");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        charAnim.SetTrigger("embarassed");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        charAnim.SetTrigger("m05");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        charAnim.SetTrigger("m06");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        charAnim.SetTrigger("m07");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Y))
    //    {
    //        charAnim.SetTrigger("m08");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.U))
    //    {
    //        charAnim.SetTrigger("sp01");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        charAnim.SetTrigger("sp02");
    //    }
    //}
    void hiyoriAni()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            charAnim.SetTrigger("m02");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            charAnim.SetTrigger("m03");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            charAnim.SetTrigger("m04");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            charAnim.SetTrigger("m05");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            charAnim.SetTrigger("m06");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            charAnim.SetTrigger("m07");
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            charAnim.SetTrigger("m08");
        }
    }


    void FacialEspressions()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            expressionControl.CurrentExpressionIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            expressionControl.CurrentExpressionIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            expressionControl.CurrentExpressionIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            expressionControl.CurrentExpressionIndex = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            expressionControl.CurrentExpressionIndex = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            expressionControl.CurrentExpressionIndex = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            expressionControl.CurrentExpressionIndex = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            expressionControl.CurrentExpressionIndex = 7;
        }
    }

    public void test(string name)
    {
        Debug.Log(name);
    }
}
