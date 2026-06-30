using UnityEngine;
using UnityEngine.UI;

public class MaterialController : MonoBehaviour
{
    public Texture texture;
    public Texture normalTexture;
    public Texture bumpTexture;
    public Material newMat;
    public Material newmat2;
    Renderer render;

    Color c;
    float alpha = 0;
    float duration = 1.0f;
    float lerpValue;
    // Start is called before the first frame update
    void Start()
    {
        //Change texture to assign texture
        render = GetComponent<Renderer>();        
        render.material.mainTexture = texture;
        render.material.EnableKeyword("_NORMALMAP");
        render.material.SetTexture("_BumpMap", normalTexture);
        render.material.SetTexture("_HeightMap", bumpTexture);

        if (!newMat)
            return;
        else
        {
            render.material = newMat;
            render.material.mainTexture = texture;
        }
        if (!newmat2)
            return;
        else
        {
            render.material = newmat2;
            render.material.mainTexture = texture;
        }
    }
    /// <summary>
    /// Return Image(Texture 2D) = NormalMap(Source Image(Texture2D) , Strength of Bump(Float)
    /// </summary>
    /// <param NormalMap="Source Image(Texture2D)"></param>
    /// <param name="strength"></param>
    /// <returns></returns>
    private Texture2D NormalMap(Texture2D source, float strength)
    {
        strength = Mathf.Clamp(strength, 0.0F, 10.0F);
        Texture2D result;
        float xLeft;
        float xRight;
        float yUp;
        float yDown;
        float yDelta;
        float xDelta;
        result = new Texture2D(source.width, source.height, TextureFormat.ARGB32, true);
        for (int by = 0; by < result.height; by++)
        {
            for (int bx = 0; bx < result.width; bx++)
            {
                xLeft = source.GetPixel(bx - 1, by).grayscale * strength;
                xRight = source.GetPixel(bx + 1, by).grayscale * strength;
                yUp = source.GetPixel(bx, by - 1).grayscale * strength;
                yDown = source.GetPixel(bx, by + 1).grayscale * strength;
                xDelta = ((xLeft - xRight) + 1) * 0.5f;
                yDelta = ((yUp - yDown) + 1) * 0.5f;
                result.SetPixel(bx, by, new Color(xDelta, yDelta, 1.0f, yDelta));
            }
        }
        result.Apply();
        return result;
    }

    public void RefreshTexture()
    {
        render.material.mainTexture = texture;
    }

    // changes the value of the alpha
    public void LerpAlpha(Image someImage)
    {
        lerpValue = Mathf.PingPong(Time.time, duration) / duration;
        alpha = Mathf.Lerp(0, 1, Mathf.SmoothStep(0, 1, lerpValue));
        c = someImage.color;
        c.a = alpha;
        someImage.color = c;
    }

    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }
}
