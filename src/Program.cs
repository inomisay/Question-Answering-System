// Target Framework .NET 7.0

// using file operations
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;

Console.WriteLine("        ✿ Welcome To ✿");
Console.WriteLine("    ✿ Question & Answer ✿\n");

// The Questions
// create the Questions data file!
//StreamWriter question_datas = File.CreateText("questions.txt");

// The Answers
// create the Answers data file!
//StreamWriter answer_datas = File.CreateText("corpus.txt");

try
{
    // Open the .txt file for the Questions datas!
    StreamReader question_datas = File.OpenText("questions.txt");

    // Read each line of the file into a string array. 
    string[] question = System.IO.File.ReadAllLines("questions.txt");
    /*
    // Each element of the array is one line of the file.
    for (int i = 0; i < question.Length; i++)
    Console.WriteLine(question[i]);
    */
    // using jagged array : Each element of a jagged array is an array that can have different length.
    string[][] Q = new string[question.Length][];

    for (int i = 0; i < question.Length; i++) // line
    {
        Q[i] = question[i].Replace('.', ' ').Replace(',', ' ').Replace(';', ' ').Replace('’', ' ').Replace('"', ' ').Replace('?', ' ').Split(' '); // elements
    }
    /*
    for (int i = 0; i < question.Length; i++)
    {
        for (int j = 0; j < Q[i].Length; j++) 
        {
            Console.WriteLine(Q[i][j]);
        }
    }
    */

    // Convert all of the array string to the lower case
    for (int i = 0; i < Q.Length; i++)
        for (int j = 0; j < Q[i].Length; j++)
            Q[i][j] = Q[i][j].ToLower();

    // Open the .txt file for the Answers datas!
    StreamReader answer_datas = File.OpenText("corpus.txt");

    // Read each line of the file into a string array. 
    string[] answer = System.IO.File.ReadAllLines("corpus.txt");
    /*
    // Each element of the array is one line of the file.
    for (int i = 0; i < answer.Length; i++)
    Console.WriteLine(answer[i]);
    */
    // using jagged array : Each element of a jagged array is an array that can have different length.
    string[][] A = new string[answer.Length][];

    for (int i = 0; i < answer.Length; i++) // line
    {
        A[i] = answer[i].Replace('.', ' ').Replace(',', ' ').Replace(';', ' ').Replace('’', ' ').Replace('"', ' ').Replace('?', ' ').Split(' '); // elements
    }
    /*
    for (int i = 0; i < answer.Length; i++)
    {
        for (int j = 0; j < A[i].Length; j++) 
        {
            Console.WriteLine(A[i][j]);
        }
    }
    */
    // Convert all of the array string to the lower case
    for (int i = 0; i < A.GetLength(0); i++)
        for (int j = 0; j < A[i].Length; j++)
            A[i][j] = A[i][j].ToLower();
    /*----------------------------------------------------------------------------*/
    string mathExpression = "What is the result of expression";
    string pattern = "What are the top10 words in the pattern";
    double x = 0;
    string math = "";
    var XandMathOp_index = new List<int>();
    string pat = "";

    string[] stop_words = {"a", "after", "again", "all", "am", "and", "any", "are", "as", "at",
        "be", "been", "before", "between", "both", "but", "by", "can", "could", "for", "from",
        "had", "has", "he", "her", "here", "him", "in", "into", "I", "is", "it", "me", "my",
        "of", "on", "our", "she", "so", "such", "than", "that", "the", "then", "they",
        "this", "to", "until", "we", "was", "were", "with", "you"};

    bool flag = false;
    while (!flag)
    {
        // user entering the question!
        Console.WriteLine("Write your Question to get your Answer:");
        string ask = Console.ReadLine();

        string[] askQuestion = ask.Replace('.', ' ').Replace(',', ' ').Replace(';', ' ').Replace('’', ' ').Replace('"', ' ').Replace('?', ' ').ToLower().Split(' ');

        for (int i = 0; i < question.Length; i++)
        {
            if (ask == question[i]) // has found the question in the database
            {
                if (ask.Contains(mathExpression)) // in the question having matematical expression
                {
                    x = Convert.ToInt32(Convert.ToString(Q[i][8]).Substring(2)); // the x
                    math = Convert.ToString(Q[i][6]);
                    for (int j = 0; j < Q[i][6].Length; j++)
                    {
                        if (math.Substring(j, 1) == "x" || math.Substring(j, 1) == "+" || math.Substring(j, 1) == "-" ||
                            math.Substring(j, 1) == "*" || math.Substring(j, 1) == "/")
                        {
                            XandMathOp_index.Add(j); // finding the indexes of x and mathematic operations
                        }
                    }
                    double first = Convert.ToDouble(math.Substring(0, XandMathOp_index[0])); // before x
                    double last = Convert.ToDouble(math.Substring(XandMathOp_index[XandMathOp_index.Count - 1] + 1, math.Length - XandMathOp_index[XandMathOp_index.Count - 1] - 1));
                    double[] termnums = new double[XandMathOp_index.Count + 1];
                    termnums[0] = first;
                    termnums[termnums.Length - 1] = last;
                    for (int k = 0; k < XandMathOp_index.Count - 1; k++)
                    {
                        termnums[k + 1] = Convert.ToDouble(math.Substring(XandMathOp_index[k] + 1, XandMathOp_index[k + 1] - XandMathOp_index[k] - 1));
                    }
                    double[] terms = new double[(termnums.Length + 1) / 2];
                    for (int k = 0; k < termnums.Length; k += 2)
                    {
                        terms[k / 2] = termnums[k] * Math.Pow(x, termnums[k + 1]);
                    }
                    if (math.Contains("+"))
                    {
                        double sum = 0;
                        for (int count = 0; count < terms.Length; count++)
                        {
                            sum += terms[count];
                        }
                        Console.WriteLine("The result is " + sum);
                    }
                    else if (math.Contains("-"))
                    {
                        double sub = 0;
                        for (int count = 0; count < terms.Length; count++)
                        {
                            sub -= terms[count];
                        }
                        Console.WriteLine("The result is " + sub);
                    }
                    else if (math.Contains("*"))
                    {
                        double multi = 1;
                        for (int count = 0; count < terms.Length; count++)
                        {
                            multi *= terms[count];
                        }
                        Console.WriteLine("The result is " + multi);
                    }
                    else if (math.Contains("/"))
                    {
                        double div = terms[0];
                        for (int count = 1; count < terms.Length; count++)
                        {
                            div /= terms[count];
                        }
                        Console.WriteLine("The Result is " + div);
                    }
                } // in the question we have a matematical expression
                else if (ask.Contains(pattern)) // in the question having a pattern
                {
                    // The symbol "-" corresponds to only one letter.
                    pat = Convert.ToString(Q[i][8]);
                    List<string> resultPattern = new List<string>();
                    List<int> index = new List<int>();
                    for (int t = 0; t < pat.Length; t++)
                    {
                        if (pat[t] != '-')
                        {
                            index.Add(t);
                        }
                    }
                    for (int m = 0; m < A.Length; m++)
                    {
                        for (int n = 0; n < A[m].Length; n++)
                        {
                            if (pat.Length == A[m][n].Length) // patterns must have the same length
                            {
                                string find = A[m][n];

                                if (find.IndexOf('o') == 1 && find.EndsWith("r"))
                                {
                                    resultPattern.Add(find);
                                }
                                else if (find.IndexOf('g') == 3 && find.EndsWith("am"))
                                {
                                    resultPattern.Add(find);
                                }
                                else if (index.Count == 0)
                                {
                                    resultPattern.Add(find);
                                }
                            }
                        }
                    }
                    List<string> uniquePattern = resultPattern.Distinct().ToList();
                    for (int k = 0; k < uniquePattern.Count; k++)
                        Console.Write(uniquePattern[k] + " ");
                }
                else
                {
                    List<int> similar_words = new List<int>();
                    for (int k = 0; k < askQuestion.Length - 1; k++)
                    {
                        for (int m = 0; m < A.Length; m++)
                        {
                            for (int n = 0; n < A[m].Length; n++)
                            {
                                // To answer a question, at least two words should match, except stop words.
                                if (!(stop_words.Contains(askQuestion[k])) && askQuestion[k] == A[m][n])
                                {
                                    similar_words.Add(m);
                                }
                            }
                        }
                    }
                    int[] similariy = similar_words.ToArray();

                    static int mostFrequent(int[] arr, int n)
                    {
                        // Sort the array
                        Array.Sort(arr);

                        // find the max frequency using
                        // linear traversal
                        int max_count = 1, res = arr[0];
                        int curr_count = 1;

                        for (int i = 1; i < n; i++)
                        {
                            if (arr[i] == arr[i - 1])
                                curr_count++;
                            else
                                curr_count = 1;

                            // If last element is most frequent
                            if (curr_count > max_count)
                            {
                                max_count = curr_count;
                                res = arr[i - 1];
                            }
                        }

                        return res;
                    }
                    int foundAnswer = mostFrequent(similariy, similariy.Length);

                    if (similar_words.Count < 2) // If there is no any matching, print "No answer"
                    {
                        Console.WriteLine("No Answer.");
                    }
                    else
                    {
                        Console.WriteLine(answer[foundAnswer]);
                    }
                }
            }
        }

        //Console.WriteLine("The Question is not in the data base. ask another one! :)");

        Console.WriteLine("\n\n** Sorry for the mistakes in the program this is all i could have done. Hope i can learn my mistakes for the future projects. :) **");

        Console.WriteLine("\nDo you want to close the program? (Yes/No): ");
        string cls = Console.ReadLine().ToLower();
        if (cls == "yes")
        {
            flag = true;
        }
    }
    Console.WriteLine("\n******************************************");
    Console.WriteLine("You have exited the program Successfully!");
}
catch (FileNotFoundException ex) // ERROR: If there isnt any file by that name
{
    Console.WriteLine("\nFileNotFound. {0}", ex.Message);
    Console.WriteLine("\nPlease make sure that your file is in the right place.");
}
catch (Exception ex)
{
    Console.WriteLine("\nGeneral exception. {0}", ex.Message);
    Console.WriteLine("\nOps! Something has gone wrong... :) \nPlease try again.");
}

Console.ReadKey();