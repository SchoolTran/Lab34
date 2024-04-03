using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrangPhucController : MonoBehaviour
{
    public GameObject trangPhuc;
    // Start is called before the first frame update
    void Start()
    {
        // Đăng ký sự kiện
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ShowMenu();
        // Viết mã xử lý bạn muốn thực hiện khi nút được nhấn ở đây
    }
    public void ShowMenu()
    {
        trangPhuc.SetActive(true); // Hiển thị Menu
    }
}
