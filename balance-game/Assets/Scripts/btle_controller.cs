using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class btle_controller : MonoBehaviour
{

    // ----------------------------------------------------------------- 
    // change these to match the bluetooth device you're connecting to: 
    // ----------------------------------------------------------------- 
    // private string _FullUID = "713d****-503e-4c75-ba94-3148f18d941e"; // redbear module pattern 
    private string _FullUID = "6e40****-b5a3-f393-e0a9-e50e24dcca9e";     // BLE-CC41a module pattern 
    
    private string _serviceUUID = "0001";
    private string _readCharacteristicUUID = "0003";
    private string _writeCharacteristicUUID = "0002";
    private string deviceToConnectTo = "Adafruit Bluefruit LE";

    public bool isConnected = false;
    private bool _readFound = false;
    private bool _writeFound = false;
    private string _connectedID = null;

    private Dictionary<string, string> _peripheralList;
    private float _subscribingTimeout = 0f;

    public Text txtDebug;
    public GameObject uiPanel;
    public Text txtSend;
    public Text txtReceive;
    public Button btnSend;

    public static string sensorInfo;
    public static int[] SensorArray;
    public static int FSR0;
    public static int FSR1;
    public static int FSR2;
    public static int FSR3;


    // Use this for initialization 
    void Start()
    {
        btnSend.onClick.AddListener(sendData);
        //uiPanel.SetActive(false);
        txtDebug.text = "Please wait.\nConnecting to sensors.\n";
        BluetoothLEHardwareInterface.Initialize(true, false, () => { },
                                      (error) => { }
        );
        Invoke("scan", 1f);
    }

    // Update is called once per frame 
    void Update()
    {
        if (_readFound && _writeFound)
        {
            _readFound = false;
            _writeFound = false;
            _subscribingTimeout = 1.0f;
        }

        if (_subscribingTimeout > 0f)
        {
            _subscribingTimeout -= Time.deltaTime;
            if (_subscribingTimeout <= 0f)
            {
                _subscribingTimeout = 0f;
                BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(
                   _connectedID, FullUUID(_serviceUUID), FullUUID(_readCharacteristicUUID),
                   (deviceAddress, notification) => {
                   },
                   (deviceAddress2, characteristic, data) => {
                       BluetoothLEHardwareInterface.Log("id: " + _connectedID);
                       if (deviceAddress2.CompareTo(_connectedID) == 0)
                       {
                           BluetoothLEHardwareInterface.Log(string.Format("data length: {0}", data.Length));
                           if (data.Length == 0)
                           {
                               
                               // do nothing 
                           }
                           else
                           {
                               string sensorInfo = ASCIIEncoding.UTF8.GetString(data);
                               BluetoothLEHardwareInterface.Log("data: " + sensorInfo);
                               receiveText(sensorInfo);
                           }
                       }
                   });

            }
        }
    }

    void receiveText(string sensorInfo)
    {
        txtDebug.text = "Connected to sensors";
        txtReceive.text = sensorInfo;
        SensorArray = System.Array.ConvertAll(sensorInfo.Split(','), int.Parse);
        FSR0 = SensorArray[0];
        FSR1 = SensorArray[1];
        FSR2 = SensorArray[2];
        FSR3 = SensorArray[3];
    }

    void sendDataBluetooth(string sData)
    {
        if (sData.Length > 0)
        {
            byte[] bytes = ASCIIEncoding.UTF8.GetBytes(sData);
            if (bytes.Length > 0)
            {
                sendBytesBluetooth(bytes);
            }
        }
    }

    void sendBytesBluetooth(byte[] data)
    {
        BluetoothLEHardwareInterface.Log(string.Format("data length: {0} uuid {1}", data.Length.ToString(), FullUUID(_writeCharacteristicUUID)));
        BluetoothLEHardwareInterface.WriteCharacteristic(_connectedID, FullUUID(_serviceUUID), FullUUID(_writeCharacteristicUUID),
           data, data.Length, true, (characteristicUUID) => {
               BluetoothLEHardwareInterface.Log("Write succeeded");
           }
        );
    }


    void scan()
    {

        // the first callback will only get called the first time this device is seen 
        // this is because it gets added to a list in the BluetoothDeviceScript 
        // after that only the second callback will get called and only if there is 
        // advertising data available 
        txtDebug.text += ("Starting scan \r\n");
        BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, (address, name) => {
            AddPeripheral(name, address);
        }, (address, name, rssi, advertisingInfo) => { });

    }

    void AddPeripheral(string name, string address)
    {
        txtDebug.text += ("Found " + name + " \r\n");

        if (_peripheralList == null)
        {
            _peripheralList = new Dictionary<string, string>();
        }
        if (!_peripheralList.ContainsKey(address))
        {
            _peripheralList[address] = name;
            if (name.Trim().ToLower() == deviceToConnectTo.Trim().ToLower())
            {
                //txtDebug.text += "Found our device, stop scanning \n"; 
                //BluetoothLEHardwareInterface.StopScan (); 

                txtDebug.text += "Connecting to " + address + "\n";
                connectBluetooth(address);
            }
            else
            {
                txtDebug.text += "Not what we're looking for \n";
            }
        }
        else
        {
            txtDebug.text += "No address found \n";
        }
    }

    void connectBluetooth(string addr)
    {
        BluetoothLEHardwareInterface.ConnectToPeripheral(addr, (address) => {
        },
           (address, serviceUUID) => {
           },
           (address, serviceUUID, characteristicUUID) => {

             // discovered characteristic 
             if (IsEqual(serviceUUID, _serviceUUID))
               {
                   _connectedID = address;
                   isConnected = true;

                   if (IsEqual(characteristicUUID, _readCharacteristicUUID))
                   {
                       _readFound = true;
                   }
                   if (IsEqual(characteristicUUID, _writeCharacteristicUUID))
                   {
                       _writeFound = true;
                   }

                   txtDebug.text += "Connected";
                   BluetoothLEHardwareInterface.StopScan();
                   uiPanel.SetActive(true);

               }
           }, (address) => {

             // this will get called when the device disconnects 
             // be aware that this will also get called when the disconnect 
             // is called above. both methods get call for the same action 
             // this is for backwards compatibility 
             isConnected = false;
           });

    }


    void sendData()
    {
        string s = txtSend.text.ToString();
        sendDataBluetooth(s);
    }

    // ------------------------------------------------------- 
    // some helper functions for handling connection strings 
    // ------------------------------------------------------- 
    string FullUUID(string uuid)
    {
        return _FullUID.Replace("****", uuid);
    }

    bool IsEqual(string uuid1, string uuid2)
    {
        if (uuid1.Length == 4)
        {
            uuid1 = FullUUID(uuid1);
        }
        if (uuid2.Length == 4)
        {
            uuid2 = FullUUID(uuid2);
        }
        return (uuid1.ToUpper().CompareTo(uuid2.ToUpper()) == 0);
    }

}