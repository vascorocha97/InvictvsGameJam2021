

using UnityEngine;
using System.IO.Ports;
public class ArduinoSerial : MonoBehaviour
{
    SerialPort sp;
    float next_time; int ii = 0;
    private TimeRobot timeBody;

    private bool firstTime = false;


    // Use this for initialization
    void Start()

    {
        timeBody = gameObject.GetComponent<TimeRobot>();

        string the_com = "COM4";
        next_time = Time.time;

        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM4") { the_com = mysps; break; }
        }
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
        if (!sp.IsOpen)
        {
            print("Opening " + the_com + ", baud 9600");
            sp.Open();
            sp.ReadTimeout = 100;
            sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_time)
        {
            if (!sp.IsOpen)
            {
                sp.Open();
                print("opened sp");
            }
            if (sp.IsOpen)
            {
                if (firstTime == true)
                {
                    firstTime = false;
                    ii = 7;
                    //print("Writing " + ii);
                    sp.Write(ii.ToString());
                    next_time = Time.time + (float)2;
                }
                if (timeBody._isRewinding == true)
                {
                    ii = 8;
                    //print("Writing " + ii);
                    sp.Write(ii.ToString());
                    next_time = Time.time + (float)40;
                }
                else
                {
                    // ii = 9;
                }


            }


            // if (++ii > 9) ii = 0;
        }
    }
}