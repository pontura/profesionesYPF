using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSender : MonoBehaviour {

	public class VoteData
	{
		public string url = "experiencias";
		public string atraccion = "experiencias/5";
		public string puntaje;
		public string mensaje = "Registrar Calificación de Experiencia";
	}
	public class EmailData
	{
		public string url = "fotos-email";
		public string email;
		public string nombreArchivo;
		public string mensaje = "Registrar Foto para compartir por E-mail";
	}
	public class WhatsAppData
	{
		public string url = "fotos-whatsapp";
		public string telefono;
		public string nombreArchivo;
		public string mensaje = "Registrar Foto para compartir por Whatsapp";
	}
	public void Send()
	{
		SendVote ();
		if (Data.Instance.email.Length > 6)
			SendEmail ();
		if (Data.Instance.whatsapp.Length > 9)
			SendWhatsApp ();
	}
	void SendVote()
	{
		VoteData data = new VoteData ();

		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");

		data.puntaje = Data.Instance.vote.ToString();
		data.atraccion = Data.Instance.dataConfig.settings.ip_server + data.atraccion;
		var formData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson (data));

		www = new WWW(Data.Instance.dataConfig.settings.ip_server +data.url, formData, postHeader);
		StartCoroutine (WaitForRequest(www));
	}
	void SendEmail()
	{
		EmailData data = new EmailData ();

		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");


		data.email = Data.Instance.email.ToString();
		data.nombreArchivo = Data.Instance.imageName;
		var formData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson (data));

		www = new WWW(Data.Instance.dataConfig.settings.ip_server + data.url, formData, postHeader);
		StartCoroutine (WaitForRequest(www));
	}
	void SendWhatsApp()
	{
		WhatsAppData data = new WhatsAppData ();

		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");

		data.telefono = Data.Instance.whatsapp.ToString();
		data.nombreArchivo = Data.Instance.imageName;
		var formData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson (data));

		www = new WWW(Data.Instance.dataConfig.settings.ip_server + data.url, formData, postHeader);
		StartCoroutine (WaitForRequest(www));
	}
	IEnumerator WaitForRequest(WWW data)
	{
		yield return data; // Wait until the download is done
		if (data.error != null)
		{
			Debug.Log ("OK" + data.text);
		}
		else
		{
			Debug.Log ("Not sended" +  data.text);
		}
	}


}
