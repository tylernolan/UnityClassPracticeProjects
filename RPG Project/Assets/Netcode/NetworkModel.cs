using UnityEngine;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;

public class NetworkModel : MonoBehaviour {
	public static string ipAddress = "54.186.104.201";
	public const int portNum = 9999;
	public static TcpClient cli = new TcpClient(ipAddress, portNum);
	public static NetworkStream stream = cli.GetStream();
	public static string lastMessageProcessed = "";
	private static Queue<string> buffer = new Queue<string>();
	public static void sendConnRequest()
	{
		send("supersecretpassword");//top tier security password 10/10
	}
	public static void send(string msgData)
	{
		if (cli == null)
		{
			return;
		}
		else
		{
			Debug.Log("SENDING: "+ msgData);
			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
			byte[] sendData = encoding.GetBytes(msgData + "\r\n");
			stream.Write(sendData, 0, sendData.Length);
			//Debug.Log("Data Sent!");
		}
	}
	
	public static string readFromSocket(bool persistence)
	{
		do
		{
			if (buffer.Count != 0)
			{
				lastMessageProcessed = buffer.Dequeue();
				Debug.Log("From Buffer: "+ lastMessageProcessed);
				return lastMessageProcessed;
			}
			else if (stream.DataAvailable)
			{
				byte[] data = new byte[512];
				string respData = string.Empty;
				int bytes = stream.Read(data, 0, data.Length);
				respData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
				//Debug.Log(respData);
				string[] commands = respData.Split(new char[1] {'\n'});
				lastMessageProcessed = commands[0];
				for (int i = 1; i < commands.Length; i++)
				{
					var stripped = commands[i].Trim();
					if (stripped != "")
					{
						buffer.Enqueue(commands[i]);
					//	Debug.Log("Buffered: " + commands[i]);
					}
				}
				//Debug.Log("REC: "+lastMessageProcessed);
				return lastMessageProcessed;
			}
		}
		while(persistence);
		return null;
	}
	public static void closeConnection()
	{
		cli.Close();
		cli = null;
	}

}
