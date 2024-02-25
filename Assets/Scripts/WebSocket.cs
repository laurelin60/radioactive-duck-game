using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket _ws;
    private string _clientId;

    public GameObject circle;

    private readonly Queue<string> _messageQueue = new();

    private void Start()
    {
        SetCircleColor(Color.white);
        const string url = "ws://localhost:8080";

        Debug.Log("Connecting to " + url);

        _ws = new WebSocket(url);

        _ws.OnMessage += OnMessage;
        _ws.OnOpen += OnOpen;
        _ws.OnError += OnError;
        _ws.OnClose += OnClose;

        _ws.Connect();
    }

    private void OnDestroy()
    {
        _ws?.Close();
    }

    private void Update()
    {
        while (_messageQueue.Count > 0)
        {
            ProcessMessage(_messageQueue.Dequeue());
        }
    }

    private void OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("WebSocket connection opened");
        // Set circle color to green when WebSocket is connected
        SetCircleColor(Color.green);
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        _messageQueue.Enqueue(e.Data);
    }

    private void OnError(object sender, ErrorEventArgs e)
    {
        Debug.LogError("WebSocket error: " + e.Message);
        // Set circle color to red on error
        SetCircleColor(Color.red);
    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("WebSocket connection closed with reason: " + e.Reason);
        // Set circle color to red on close
        SetCircleColor(Color.red);
    }

    private void ProcessMessage(string data)
    {
        try
        {
            Debug.Log("WebSocket message received: " + data);
            // Set circle color to yellow temporarily when message is received

            //parse the message as a JSON object
            var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            switch (json["type"])
            {
                case "id":
                    Debug.Log("Set Client ID: " + _clientId);
                    _clientId = json["id"];
                    break;
                case "killDuck":
                    Debug.Log("Received killDuck message");
                    GameManager.ShootDuck();
                    break;
            }

            SetCircleColor(Color.yellow);
            // Reset circle color after 0.25 second
            Invoke(nameof(ResetCircleColor), 0.25f);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to parse WebSocket message: " + ex.Message);
        }
    }

    private void SetCircleColor(Color color)
    {
        if (circle == null) return;
        var component = circle.GetComponent<Renderer>();
        if (component != null)
        {
            component.material.color = color;
        }
    }

    private void ResetCircleColor()
    {
        SetCircleColor(Color.green);
    }
}
