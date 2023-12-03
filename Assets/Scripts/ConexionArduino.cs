//using System.Collections;
//using System.Collections.Generic;
//using System.IO.Ports;
//using UnityEngine;

//public class ConexionArduino : MonoBehaviour
//{
//    SerialPort serialPort = new SerialPort("COM4", 115200);
//    public string TextIn;
//    public GameObject Bate;
//    public GameObject Launcher;
//    BatAnimations A;

//    // Start is called before the first frame update
//    void Start()
//    {
//        serialPort.Open();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        TextIn = serialPort.ReadLine();
//        string[] data = TextIn.Split("|");

//        string[] Acel = data[1].Split(",");
//        string[] Angle = data[2].Split(",");   /*  */

//        // Debug.Log(data[0]);
//        A = Bate.GetComponent<BatAnimations>();

//        if (data[0].Contains('A'))
//        {
//            A.Batazo();


//        }
//        if (data[0].Contains('B'))
//        {


//        }




//    }
//}