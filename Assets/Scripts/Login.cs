using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	public string Name;
	private string Password;
	public string[] lines;
	private string decryptedPass;
	
	public void LoginButton(){
		bool N = false;
		bool P = false;

        string Path = @"D:\unity\LoginPanel\Assets\";

        /*
        if (Name != ""){
			if (System.IO.File.Exists(Path+Name+".txt")){
				lines = File.ReadAllLines(Path+Name+".txt");
				N = true;
			} else {
				Debug.LogWarning("Username Field is Incorrect");
			}
		} else {
			Debug.LogWarning("Username Field is empty");
		}
		if (Password != ""){
			if (System.IO.File.Exists(Path+Name+".txt")){
				int i = 1;
				foreach(char c in lines[2]){
					i++;
					char decrypted = (char)(c / i);
					decryptedPass += decrypted.ToString();
				}
				if (Password == decryptedPass){
					P = true;
				} else {
					Debug.LogWarning("Password Field is Incorrect");
					decryptedPass = "";
				}
			} else {
				Debug.LogWarning("Password Field is Incorrect");
				decryptedPass = "";
			}
		} else {
			Debug.LogWarning("Password Field is empty");
			decryptedPass = "";
		}
		if (N == true&& P == true){
			print("Login Successful");
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			Application.LoadLevel("StartMenu");
		}
        */
        if (Name == "admin" && Password == "123456")
        {
            print("Login Successful");
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            Application.LoadLevel("StartMenu");
        }
    }
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if (Password != ""&&Name != ""){
				LoginButton();
			}
		}
		Name = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
	}
}
