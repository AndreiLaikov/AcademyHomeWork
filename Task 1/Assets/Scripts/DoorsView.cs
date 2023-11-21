using UnityEngine;

public class DoorsView : MonoBehaviour
{
    public float DoorsSpeed;
    private DoorsModel model;
    private DoorsController controller;

    private void Start()
    {
        model = new DoorsModel();
        model.SetSpeed(DoorsSpeed);

        controller = GetComponent<DoorsController>();
        controller.model = model;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.Open(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        controller.Close();
    }
}
