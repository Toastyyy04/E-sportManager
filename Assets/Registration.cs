using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public UnityEngine.UI.InputField UsernameInput;
    public UnityEngine.UI.InputField emailField;
    public UnityEngine.UI.InputField passwordField;

    public Button submitButton;

    public void GoToLogin()
    {
        SceneManager.LoadScene(0);
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", UsernameInput.text);
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created succesfully.");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (UsernameInput.text.Length >= 4 && passwordField.text.Length >= 8 );
    }
}
