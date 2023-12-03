//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO.Ports;

//public class Bate : MonoBehaviour
//{
//    public float X; 
//    public float Y; 
//    public float Z;
//    private float AmountToMove;

//    SerialPort serial = new SerialPort("COM3", 9600);
//    public string strrec;
//    public string[] strdata = new string[3];
//    public string[] strdata_rec = new string[3];


//    // Start is called before the first frame update
//    void Start()
//    {
//        serial.Open();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        strrec= serial.ReadLine();

//        strdata=strrec.Split(',');
//        if (strdata[0]!="" && strdata[1] != "" && strdata[2] != "")
//        {
//            strdata_rec[0]= strdata[0];
//            strdata_rec[1] = strdata[1];
//            strdata_rec[2] = strdata[2];
//            X = float.Parse(strdata_rec[0]);
//            Y = float.Parse(strdata_rec[1]);
//            Z = float.Parse(strdata_rec[2]);

//        }



//        transform.localEulerAngles=new Vector3(X, Y, Z);


//    }
//}

using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Bate : MonoBehaviour
{

    public static Bate instance;
    public Raycastplayer raycastplayer;

    SerialPort stream = new SerialPort("COM4", 115200);
    public string strReceived;

    public string[] strData = new string[5];
    public string[] strData_received = new string[5];
    public float qw, qx, qy, qz;
    public int boton, cero=0;


    

    //private enum SwingStates
    //{
    //    Idle, //Intervalo de ángulos en y que son idle
    //    Charge, //Cargando a la derecha
    //    Hitting //Golpeando izquierda
    //}
    //private SwingStates states = SwingStates.Idle;

    public int carga = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Start() {

        stream.Open(); //Open the Serial Stream.
            
    }

    // Update is called once per frame
   public int Update()
   {
        strReceived = stream.ReadLine(); //Read the information  

        strData = strReceived.Split(',');
        if (strData[0] != "" && strData[1] != "" && strData[2] != "" && strData[3] != "" && strData[4] != "")//make sure data are reday
        {
            strData_received[0] = strData[0];
            strData_received[1] = strData[1];
            strData_received[2] = strData[2];
            strData_received[3] = strData[3];
            strData_received[4] = strData[4];

            qw = float.Parse(strData_received[0]);
            qx = float.Parse(strData_received[1]);
            qy = float.Parse(strData_received[2]);
            qz = float.Parse(strData_received[3]);
            boton = int.Parse(strData_received[4]);

            transform.rotation = new Quaternion(-qy, 0, qx, qw);


            if(qz < 0)
            {
                carga = 1;
            }

            if (raycastplayer.aux == 1)
            {
                Buzzer();
            }

        }
        return boton;
    }

    public void Buzzer()
    {
        stream.WriteLine("1");
    }


}