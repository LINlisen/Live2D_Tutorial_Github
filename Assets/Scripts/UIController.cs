using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private bool canvasToggle;
    [SerializeField]
    private GameObject buttonLists;

    public List<AnimationClip> motionLists;
    public GameObject buttonPrefab;
    public Animator animator;

    private Color originalButtonColor = Color.white;
    private Color highlightButtonColor = Color.yellow;
    private Button currentlyPlayingButton;
    private Button idleButton;
    // Start is called before the first frame update
    void Start()
    {
        canvasToggle = false;
        buttonLists.SetActive(canvasToggle);
        for (int i = 0; i < motionLists.Count; i++)
        {
            //依照動作檔List
            GameObject newButton = Instantiate(buttonPrefab, buttonLists.transform);
            newButton.GetComponentInChildren<Text>().text = motionLists[i].name;
            newButton.name = motionLists[i].name;
            RectTransform buttonRectTransform = newButton.GetComponent<RectTransform>();
            buttonRectTransform.anchoredPosition = new Vector2(buttonRectTransform.anchoredPosition.x, -i * 100 + 20);

            string animationName = motionLists[i].name;
            Button button = newButton.GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClick(animationName, button));
            if (i == 0)
            {
                idleButton = button;
                idleButton.image.color = highlightButtonColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            canvasToggle = !canvasToggle;
            buttonLists.SetActive(canvasToggle);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    private void OnButtonClick(string animationName, Button clickedButton)
    {
        idleButton.image.color = originalButtonColor;
        if (currentlyPlayingButton != null)
        {
            currentlyPlayingButton.image.color = originalButtonColor;
        }

        animator.SetTrigger(animationName);
        clickedButton.image.color = highlightButtonColor;
        currentlyPlayingButton = clickedButton;

        StartCoroutine(ResetButtonColor(animationName, clickedButton));
    }

    private IEnumerator ResetButtonColor(string animationName, Button button)
    {
        // 等待動畫播放完成
        yield return new WaitForSeconds(GetAnimationLength(animationName));

        if (currentlyPlayingButton == button)
        {
            button.image.color = originalButtonColor;
            currentlyPlayingButton = null;
        }
        idleButton.image.color = highlightButtonColor;
    }

    private float GetAnimationLength(string animationName)
    {
        AnimationClip clip = motionLists.Find(x => x.name == animationName);
        return clip != null ? clip.length : 0f;
    }
}
