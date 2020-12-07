
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
public class UnityWebRequestHW : MonoBehaviour
{
    string uri = "https://jsonplaceholder.typicode.com/posts";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadWeb(uri));
        }
    }


    IEnumerator LoadWeb(string uri) {

    

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] Context = uri.Split('}');

            Debug.Log(Context.Length);


            int page = Context.Length -1 ;

            if (webRequest.isNetworkError)
            {
                Debug.Log(Context[page] + ": Error: " + webRequest.error);

            }
            else
            {
                Debug.Log(Context[page] + ":\n Recieved : " + webRequest.downloadHandler.text);
                
            }
        }
    
    }
}
