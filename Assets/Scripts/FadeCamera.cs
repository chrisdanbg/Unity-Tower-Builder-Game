using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FadeCamera : MonoBehaviour
{
	[Range (0f, 1f)]
	public float opacity = 1;
	public Color color = Color.black;

	private Material material;
	private float startTime = 0;
	private float startOpacity = 1;
	private int endOpacity = 1;
	private float duration = 0;
	private bool isFading = false;

	public void FadeIn (float duration = 1)
	{
		this.duration = duration;
		this.startTime = Time.time;
		this.startOpacity = opacity;
		this.endOpacity = 1;
		this.isFading = true;
	}

	public void FadeOut (float duration = 1)
	{
		this.duration = duration;
		this.startTime = Time.time;
		this.startOpacity = opacity;
		this.endOpacity = 0;
		this.isFading = true;
	}

	void Awake ()
	{
		material = new Material (Shader.Find ("Hidden/FadeCameraShader"));
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if (isFading && duration > 0) {
			opacity = Mathf.Lerp (startOpacity, endOpacity, (Time.time - startTime) / duration);
			isFading = opacity != endOpacity;
		}

		if (opacity == 1f) {
			Graphics.Blit (source, destination);
			return;
		}

		material.color = color;
		material.SetFloat ("_opacity", opacity);
		Graphics.Blit (source, destination, material);
	}
}
