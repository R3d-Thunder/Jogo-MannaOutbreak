using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour{

    public GameObject Regis;
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField ConfirmPassInput;
    public Button RegisButton;
    public Button ReturnButton;

    // Start is called before the first frame update
    void Start(){
        
        RegisButton.onClick.AddListener(() => {

            if(PasswordInput.text == ConfirmPassInput.text){
           
                StartCoroutine(main.Instance.Web1.GetLogin(UsernameInput.text,PasswordInput.text));

            }else{

                Debug.Log("Verificar Senha");

            }

        });

        ReturnButton.onClick.AddListener(() => {

            Regis.SetActive(false);

        });

    }

}
