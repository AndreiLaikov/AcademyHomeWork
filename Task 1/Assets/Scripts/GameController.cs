using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public CharController charPrefab;
    public Transform SpawnPoint;
    public Button RespawnButton;
        

    [SerializeField]private CharController currentChar;

    private Camera charCamera;
    [SerializeField] private Vector3 camOffset;
    public float camSpeed;

    [SerializeField]private float charHealth;

    private void Start()
    {
        Respawn();
        charCamera = Camera.main;
        
    }

    public void Respawn()
    {
        if (currentChar == null)
        {
            currentChar = Instantiate(charPrefab, SpawnPoint.position, Quaternion.identity);
            RespawnButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (currentChar == null)
        {
            RespawnButton.gameObject.SetActive(true);
            return;
        }

        charHealth = currentChar.GetComponent<HealthSystem>().CurrentHealth;
        CameraMove();
    }

    void CameraMove()
    {
        var charPos = currentChar.transform.position;

        charCamera.transform.position = Vector3.Lerp(charCamera.transform.position, charPos + camOffset, camSpeed * Time.deltaTime);
    }

}
