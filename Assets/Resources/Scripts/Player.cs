using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject dialogePanel;
    [SerializeField] GameObject actionPanel;
    [SerializeField] GameObject closeButton;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject doll;
    [SerializeField] DollPosition dollPosition;
    [SerializeField] float speedText;
    private bool canMove = false;
    public bool haveDoll = false;
    

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //StartCoroutine(Dialog(initialText));
    }

    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && canMove)
        {
            Move();
            animator.Play("Move");
        }
        else
        {
            animator.Play("Static");
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        if (moveHorizontal > 0)
        {
            sprite.flipX = false;
            dollPosition?.SwitchPosition(false);
        }
        else if (moveHorizontal < 0)
        {
            sprite.flipX = true;
            dollPosition?.SwitchPosition(true);
        }
    }

    public void MoveValue(bool _canMove)
    {
        canMove = _canMove;
    }

    public void ShowActionPanel(bool isShow)
    {
        actionPanel.SetActive(isShow);
    }

    public void StartDialoge(string text)
    {
        ShowActionPanel(false);
        canMove = false;
        StartCoroutine(Dialog(text));
    }

    private IEnumerator Dialog(string str)
    {
        dialogePanel.SetActive(true);
        text.text = "";

        foreach (char c in str)
        {
            text.text += c;
            yield return new WaitForSeconds(speedText);
        }

        closeButton.SetActive(true);

        yield return new WaitForSeconds(15f);
        dialogePanel.SetActive(false);

    }

    public void ClosePanel()
    {
        closeButton.SetActive(false);
        dialogePanel.SetActive(false);

        canMove = true;
    }

    public void TakeDoll()
    {
        doll.SetActive(true);
        haveDoll = true;
    }
}
