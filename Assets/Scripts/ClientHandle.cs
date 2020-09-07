using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();
        Debug.Log($"Message from server: {_msg}");
        Client.instance.myid = _myId;
        ClientSend.WelcomeReceived();

        Debug.Log("commit test");

        //TODO: Send welcome packet receive
    }
}
