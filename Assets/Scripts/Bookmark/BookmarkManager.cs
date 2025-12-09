using UnityEngine;

public class BookmarkManager : MonoBehaviour
{
    [SerializeField] private GameObject bookmarkPrefab;
    private GameObject bookmark;

    public void OpenBookmarks()
    {
        bookmark = Instantiate(bookmarkPrefab, Vector3.zero, Quaternion.identity);
        bookmark.transform.SetParent(transform.parent.gameObject.transform, false);
    }
}