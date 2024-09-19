using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour{

    public GameObject Regis;
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;
    public Button RegisterButton;

    // Start is called before the first frame update
    void Start(){
        
        LoginButton.onClick.AddListener(() => {

            StartCoroutine(main.Instance.Web1.Login(UsernameInput.text,PasswordInput.text));

        });

        RegisterButton.onClick.AddListener(() => {

            Regis.SetActive(true);

        });

    }

}