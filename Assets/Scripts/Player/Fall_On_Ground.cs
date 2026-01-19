using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall_On_Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }

}
