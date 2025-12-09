using UnityEngine;
using UnityEngine.UI;

public class BookmarkManager : MonoBehaviour
{
    [SerializeField] private GameObject bookmarkPrefab;
    private GameObject bookmark;

    private void Start()
    {
        if (GameManager.TutorialActive)
        {
            this.GetComponent<Button>().enabled = false;
            return;
        }
    }

    public void OpenBookmarks()
    {
        AudioManager.PlayPageTurn();
        bookmark = Instantiate(bookmarkPrefab, Vector3.zero, Quaternion.identity);
        bookmark.transform.SetParent(transform.parent.gameObject.transform, false);
    }
}