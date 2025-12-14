using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public TMP_Text feedbackText;

    private int currentQuestionIndex = 0;
    private int correctAnswersCount = 0;

    private string[] questions = {
        "What is 6 * 7?",
        "What is 20 * 5?",
        "Consider a complete graph of order n; that is, there are n vertices and each vertex is connected to every other vertex by an angle. A complete graph of order 3 is called a triangle. Now colour each edge either red or blue. How large must n be to ensure that there is either a blue triangle or red triangle?",
        "What is the 60th perfect number?",
        "What is the first weakly compact cardinal number?",
        "What is the exact value of the riemann zeta function at 2^100, ζ(2^100)?",
        "Given three celestial bodies with masses m1 , m2 , and m3  located at initial positions (x1 ,y1 ,z1 ), (x2 ,y2 ,z2 ), and (x3 ,y3 ,z3 ) in a three-dimensional space, and with initial velocities (v1x ,v1y ,v1z ), (v2x ,v2y ,v2z ), and (v3x ,v3y ,v3z ), predict the position of the third mass m3  after 10 years, taking into account the gravitational interactions among the three bodies?",
        "What is the xaplorgulus prime number? {10,10(2)2}",
        "If we color the edges of a n-dimensional hypercube using two colors, what is the smallest value of n such that we are guarenteed to find a complete subgraph K₄ (a set of all vertices all connected by edges) that is monochromatic? Express grahams number in decimal",
        "What is the exact value of Chaitin's constant, Ω, the real number representing the probability that a randomly chosen Turing machine will halt? Provide the full decimal expansion of Ω."
    };

    void Start()
    {
        LoadNextQuestion();
    }

    void LoadNextQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            answerInput.text = "";
        }
        else
        {
            questionText.text = "Math quiz Complete! You got " + correctAnswersCount + " out of " + questions.Length + " correct. This means you have " + correctAnswersCount + " lives.";
            answerInput.gameObject.SetActive(false);

            PlayerPrefs.SetInt("correctAnswersCount", correctAnswersCount);
            PlayerPrefs.Save();
            StartCoroutine(EndQuizAfterDelay());
        }
    }

    public void CheckAnswer()
    {
        string playerAnswer = answerInput.text.Trim();

        if (currentQuestionIndex == 0)
        {
            if (playerAnswer == "42")
            {
                feedbackText.text = "Correct!";
                correctAnswersCount++;
            }
            else
            {
                feedbackText.text = "i'll give you pity points- ";
                correctAnswersCount++;
            }
        }
        else if (currentQuestionIndex == 1)
        {
            if (playerAnswer == "100")
            {
                feedbackText.text = "Correct!";
                correctAnswersCount++;
            }
            else
            {
                feedbackText.text = "how'd you get this wrong";
            }
        }
        else if (currentQuestionIndex == 2)
        {
            if (playerAnswer == "6")
            {
                feedbackText.text = "Correct!";
                correctAnswersCount++;
            }
            else
            {
                feedbackText.text = "this is a little complicated but its really just the ramsey number for ensuring a monochromatic triangle in a 2 color graph";
            }
        }
        else if (currentQuestionIndex == 3)
        {
            feedbackText.text = "imperfect";
        }
        else if (currentQuestionIndex == 4)
        {
            feedbackText.text = "the first weakly compact cardinal number represents my height";
        }
        else if (currentQuestionIndex == 5)
        {
            feedbackText.text = "didn't you learn this in calculus";
        }
        else if (currentQuestionIndex == 6)
        {
            feedbackText.text = "the show is fires";
        }
        else if (currentQuestionIndex == 7)
        {
            feedbackText.text = "gugology is study of very big numbers (like numbers that describe my height)";
        }
        else if (currentQuestionIndex == 8)
        {
            feedbackText.text = "it's literally just coloring the edges of a hypercube";
        }
        else if (currentQuestionIndex == 9)
        {
            feedbackText.text = "turing machines are useless anyways-";
        }

        currentQuestionIndex++;
        LoadNextQuestion();
    }

    IEnumerator EndQuizAfterDelay()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
