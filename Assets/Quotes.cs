using TMPro;
using UnityEngine;
using System.Collections;

public class RandomQuoteDisplay : MonoBehaviour
{
    public TextMeshProUGUI quoteText;
    public float displayInterval = 5f;
    public float typingSpeed = 0.05f;
    public float backspaceSpeed = 0.03f;

    public float colorChangeSpeed = 1f;

    private string[] quotes = {
        "someone get dr. carpenter a pork pie hat",
        "mr joseph = demure + cutesy",
        "ave atque vale",
        "ad aspera per astra",
        "do not go gentle into that good night",
        "fortune favors the bold",
        "rage, rage against the dying of the light",
        "hello and welcome to creative writing corner",
        "dur a cure",
        "as a warrior you were born a life without worth",
        "then to death i will have no grudge",
        "to climb a mountain of swords",
        "the time to die is now, do not disgrace yourself with delay",
        "heaven will not forgive your rebellion",
        "wrathful deities may shake you but your courage must be unwavering",
        "only at death is the final chapter of our lives written",
        "surya's tall btw",
        "there is nothing we can do",
        "oh say can you see",
        "give me liberty or give me death",
        "god bless america",
        "why'd he call it macaroni",
        "the violins of death",
        "votre enterrement",
        "for whom the bell tolls",
        "a new genesis",
        "non video",
        "alea iacta est",
        "eddies really not that tall",
        "memento mori",
        "sic transit gloria mundi",
        "vita brevis, ars longa",
        "mors omni aequat",
        "pulvis et umbra sumus",
        "non omnis moriar",
        "vae victis",
        "timor moris conturbat me",
        "dulce et decorum est pro patri mori",
        "do not be far from me for trouble is near",
        "god is our refuge and strength",
        "the righteous cry out, and the lord hears them",
        "the lord is near to all who call on him, to all who call on him in truth",
        "μαθ sucks",
        "i am the eclipse",
        "this generation is cursed",
        "are you the biggest bird?",
        "there is no such thing as justice without sacrifice",
        "contest your death",
        "to infinity, and beyond",
        "abandoning one's uniqueness is equivalent to dying",
        "i believed, if only for a second, i could fly",
        "as long as it gets the point across"
    };

    private void Start()
    {
        if (quoteText == null)
        {
            quoteText = GetComponent<TextMeshProUGUI>();
        }

        StartCoroutine(DisplayQuoteRoutine());
        StartCoroutine(ChangeTextColorRoutine());
    }

    private IEnumerator DisplayQuoteRoutine()
    {
        while (true)
        {
            string selectedQuote = quotes[Random.Range(0, quotes.Length)];

            yield return StartCoroutine(TypeQuote(selectedQuote));

            yield return new WaitForSeconds(displayInterval);

            yield return StartCoroutine(BackspaceQuote(selectedQuote.Length));
        }
    }

    private IEnumerator TypeQuote(string quote)
    {
        quoteText.text = "";

        foreach (char letter in quote)
        {
            quoteText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private IEnumerator BackspaceQuote(int length)
    {
        for (int i = length; i >= 0; i--)
        {
            quoteText.text = quoteText.text.Substring(0, i);
            yield return new WaitForSeconds(backspaceSpeed);
        }
    }

    private IEnumerator ChangeTextColorRoutine()
    {
        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime * colorChangeSpeed)
            {
                float r = Mathf.Sin(t * 2 * Mathf.PI) * 0.5f + 0.5f;
                float g = Mathf.Sin(t * 2 * Mathf.PI + (2 * Mathf.PI / 3)) * 0.5f + 0.5f;
                float b = Mathf.Sin(t * 2 * Mathf.PI + (4 * Mathf.PI / 3)) * 0.5f + 0.5f;

                quoteText.color = new Color(r, g, b);
                yield return null;
            }
        }
    }
}
