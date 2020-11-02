using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField txtLogin;
    public InputField txtSenha;
    public GameObject lblError;

    public void PlayGame()
    {
        SceneManager.LoadScene("play");
    }

    public void Logar()
    {
        if (txtLogin.text == "demo" && txtSenha.text == "demo")
        {
            lblError.SetActive(false);
            SceneManager.LoadScene("main");
        } else
        {
            lblError.SetActive(true);
            Debug.Log("erro");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
