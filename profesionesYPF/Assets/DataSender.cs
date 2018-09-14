using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSender : MonoBehaviour {

	public class VoteData
	{
		public string url = "http://ypf.reweb.com.ar:8080/store-and-forward-0.0.1/experiencias";
		public string atraccion = "http://ypf.reweb.com.ar:8080/store-and-forward-0.0.1/experiencias/5";
		public string puntaje;
		public string mensaje = "Registrar Calificación de Experiencia";
	}
	public class EmailData
	{
		public string url = "http://ypf.reweb.com.ar:8080/store-and-forward-0.0.1/fotos-email";
		public string email;
		public string nombreArchivo;
		public string mensaje = "Registrar Foto para compartir por E-mail";
	}
	public class WhatsAppData
	{
		public string url = "http://ypf.reweb.com.ar:8080/store-and-forward-0.0.1/fotos-whatsapp";
		public string telefono;
		public string nombreArchivo;
		public string mensaje = "Registrar Foto para compartir por Whatsapp";
	}
	public void Send()
	{
		SendVote ();
		if (Data.Instance.email.Length > 4)
			SendEmail ();
		if (Data.Instance.whatsapp.Length > 4)
			SendWhatsApp ();
	}
	void SendVote()
	{
		VoteData data = new VoteData ();

		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");

		data.puntaje = Data.Instance.vote.ToString();
		var formData = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson (data));

		www = new WWW(data.url, formData, postHeader);
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

		www = new WWW(data.url, formData, postHeader);
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

		www = new WWW(data.url, formData, postHeader);
	}
	IEnumerator WaitForRequest(WWW data)
	{
		yield return data; // Wait until the download is done
		if (data.error != null)
		{
			Debug.Log ("OK");
		}
		else
		{
			Debug.Log ("Not sended");
		}
	}


}
