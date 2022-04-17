using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obschee : MonoBehaviour
{

    public Vector3 mousePos; // позиция мыши
    public Vector3 startMousePos; // начальная позиция

    public Vector3 det1; // следители треугольника
    public Vector3 det2;

    public GameObject sphere; // круг
    public GameObject cube; // квадрат
    public GameObject triangle;

    public Vector3 et2Cpos; // позиции для квадрата
    public Vector3 et3Cpos;
    public Vector3 et4Cpos;

    public Vector3 et2Tpos; // позиции для треугольника
    public Vector3 et3Tpos;
    public Vector3 et4Tpos;

    public Vector3 et1Spos; // позиция первого этапа круга, нужная для отличия круга от треугольника




    public bool etS1; // этапы круга
    public bool etS2;
    public bool etS3;
    public bool etS4;

    public bool etC1; // этапы квадрата
    public bool etC2;
    public bool etC3;
    public bool etC4;
    public bool etC5;

    public bool etT1; // этапы треугольника
    public bool etT2;
    public bool etT3;


    
    void Update() // рисование
    {
        if (Input.GetKey(KeyCode.Mouse0)) // НАЧАЛО СЧИТЫВАНИЯ С НАЖАНИЕМ МЫШИ
        {
            scanSphere();
            scanCube();
            scanTriangle();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) // ВЫПОЛНЕНИЕ ДЕЙСТВИЯ ПРИ ОТПУСКАНИИ МЫШИ
        {
            print("нажми лкм");
            Sphera();
            Cub();
            Triangle();

            etS1 = false;
            etS2 = false;
            etS3 = false;
            etS4 = false;

            etC1 = false;
            etC2 = false;
            etC3 = false;
            etC4 = false;
            etC5 = false;

            etT1 = false;
            etT2 = false;
            etT3 = false;

            et2Cpos = new Vector3(0, 0, 0);
            et3Cpos = new Vector3(0, 0, 0);
            et4Cpos = new Vector3(0, 0, 0);

            et2Tpos = new Vector3(0, 0, 0);
            et3Tpos = new Vector3(0, 0, 0);

            startMousePos = new Vector3(0, 0, 0);
            det1 = new Vector3(0, 0, 0);
            det2 = new Vector3(0, 0, 0);
            et1Spos = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    //////////////////////////////////////////////////////////////////////////////////////// РИСОВАНИЕ КРУГА

    public void Sphera()
    {
        if ((etS1 == true) && (etS2 == true) && (etS3 == true) && (etS4 == true))
            Instantiate(sphere);
    }

    public void scanSphere()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Debug.Log(startMousePos);
        }

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.y > Screen.height / 2 - 5 && mousePos.y < Screen.height / 2 + 5 && mousePos.x < startMousePos.x)
        {
            etS1 = true;
            et1Spos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        if (etC2 == true)
        {
            etS1 = false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.x > startMousePos.x - 10 && mousePos.x < startMousePos.x + 10 && mousePos.y < startMousePos.y - 100)
        {
            etS2 = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.y > Screen.height / 2 - 5 && mousePos.y < Screen.height / 2 + 5 && mousePos.x > startMousePos.x)
        {
            etS3 = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.y > startMousePos.y - 10 && mousePos.y < startMousePos.y + 10 && mousePos.x > startMousePos.x - 10 && mousePos.x < startMousePos.x + 10 && etS3 == true && etT2 == false)
        {
            etS4 = true;
        }


    }

    // РИСОВАНИЕ КВАДРАТА

    public void Cub()
    {
        if ((etC1 == true) && (etC2 == true) && (etC3 == true) && (etC4 == true) && (etC5 == true))
            Instantiate(cube);
    }

    public void scanCube()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Debug.Log(startMousePos);
        }

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.y < startMousePos.y - 20 && mousePos.y > startMousePos.y - 30)
        {
            et2Cpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            etC1 = true;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (etC1 == true && mousePos.x > et2Cpos.x + 20 && mousePos.x < et2Cpos.x + 30 && et2Cpos.x < et1Spos.x + 10 && et2Cpos.x > et1Spos.x - 10)
        {
            et3Cpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            etC2 = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.y > et3Cpos.y + 20 && mousePos.y < et3Cpos.y + 30)
        {
            et4Cpos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            etC3 = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.x < et4Cpos.x - 20 && mousePos.x > et4Cpos.y - 30)
        {
            etC4 = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (mousePos.y > startMousePos.y - 20 && mousePos.y < startMousePos.y + 20 && mousePos.x > startMousePos.x - 20 && mousePos.x < startMousePos.x + 20 && etC4 == true)
        {
            etC5 = true;
        }
    }

    // РИСОВАНИЕ ТРЕУГОЛЬНИКА

    public void Triangle()
    {
        if (etT1 == true && etT2 == true && etT3 == true)
            Instantiate(triangle);
    }

    public void scanTriangle()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Debug.Log(startMousePos);
            det1 = startMousePos;
            det2 = det1;
        }

        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);


        /////////////////////////////////////////////////////////////////////////////////////////////////////////// ВТОРОЙ ЭТАП ТРЕУГОЛЬНИКА

        if (mousePos.x < det1.x - 10 && mousePos.x > det1.x - 20)
        {
            det1 = mousePos;
        }
        if (mousePos.x > det1.x)
        {
            et2Tpos = det1;
            etT1 = true;

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////// ТРЕТИЙ ЭТАП ТРЕУГОЛЬНИКА

        if (mousePos.x >= det2.x)
        {
            etT2 = false;
        }
        if (mousePos.x > det2.x + 10 && mousePos.x < det2.x + 20)
        {
            det2 = mousePos;
        }

        if (mousePos.x < det2.x && mousePos.y > det2.y - 10 && mousePos.y < det2.y + 10 && etC2 == false && et2Tpos.x < et1Spos.x - 10)
        {
            etT2 = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////// ФИНАЛЬНЫЙ ЭТАП ТРЕУГОЛЬНИКА

        if (etT2 == true && etT1 == true && mousePos.x < startMousePos.x + 10 && mousePos.x > startMousePos.x - 10 && mousePos.y > startMousePos.y - 10 && mousePos.y < startMousePos.y + 10)
        {
            etT3 = true;
        }


    }

}