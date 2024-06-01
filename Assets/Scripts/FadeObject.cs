using UnityEngine;
using System.Collections;

public class FadeObject : MonoBehaviour {
    public float fadeSpeed = 1.0f;
    public float desiredAlpha = 0.0f;

    void Start() {
    }

    void Update() {
        if (GetComponent<SpriteRenderer>().color.a != desiredAlpha) {
            float alpha = Mathf.MoveTowards(GetComponent<SpriteRenderer>().color.a, desiredAlpha, fadeSpeed * Time.deltaTime);
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
        }
    }

    public void FadeOut() {
        desiredAlpha = 0.0f;
    }

    public void FadeIn() {
        desiredAlpha = 1.0f;
    }
}