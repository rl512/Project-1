using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Startover : MonoBehaviour
{
   public void Button_Click ()
    {
        SceneManager.LoadScene(0);
        Debug.Log("HEllo"); 

    }
}
