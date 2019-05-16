using UnityEngine;

public class SelectButton : MonoBehaviour/*, ISelectHandler, IDeselectHandler*/
{
    [SerializeField]
    GameObject giraffeHead;

    [SerializeField]
    pButton button;

    [SerializeField]
    GameObject leaf;

    //public static HashSet<pButton> allButtons = new HashSet<pButton>();
    //public static HashSet<pButton> currentButtons = new HashSet<pButton>();

    public GameObject counterpart;
    [HideInInspector]
    public bool counterpartSelected = false;

    private void Awake()
    {
        //allButtons.Add(this.GetComponentInParent<pButton>());
        Debug.Log(gameObject.name + " is one of them");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == giraffeHead)
        {
            if (Input.GetKeyDown(KeyCode.W))
                InvokeSelection(1);
            if (Input.GetKeyDown(KeyCode.Space))
                InvokeSelection(2);
        }
    }

    public void InvokeSelection(int grff)
    {
        DeselectAll(leaf, button);
        leaf.SetActive(true);
        //button.
    }

    public static void DeselectAll(GameObject Leaf, pButton Button)
    {
        Leaf.SetActive(false);

    }

    //public void Click(bool grffe1)
    //{
    //    if (grffe1)
    //    {
    //        button.onClick.Invoke();
    //    }
    //}

    //public void NextScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}




    //public void OnSelect(BaseEventData eventData)
    //{
    //    DeselectAll(eventData);
    //    currentButtons.Add(this.GetComponentInParent<pButton>());
    //    //here I leave the leaf (like sprite change if it were one button)
    //    Debug.Log("ok?");
    //    transform.parent.transform.Find("Right Leaf").gameObject.SetActive(true);
    //}

    //public void OnDeselect(BaseEventData eventData)
    //{
    //    //here I take off the leaf
    //    Debug.Log("ok!");
    //    transform.parent.transform.Find("Right Leaf").gameObject.SetActive(false);
    //}

    //public static void DeselectAll(BaseEventData eventData)
    //{
    //    foreach(pButton selectable in currentButtons)
    //    {
    //        selectable.OnDeselect(eventData);
    //        currentButtons.Clear();

    //    }
    //}
}
