# Question-Answering-System

<img width="214" alt="Screen Shot 2023-05-31 at 16 31 42" src="https://github.com/inomisay/Question-Answering-System/assets/98346164/ee79d7ea-b38c-4216-9c35-dd3d50c4d27c">

# Question Answering System

Write a simple question answering program like https://www.answers.com/. This problem falls under the domain of Artificial Intelligence.

The program will read the questions from a text file (*questions.txt*), find their answers by using a corpus (*corpus.txt*), and print the answers on the screen.

The questions and corpus may contain the following **punctuation marks** and **mathematical operators**:
'.', ',', ';', '’' '"', '?', '+', '-', '*', '/'

Make sure your program works well for uppercase and lowercase English letters. The program will answer the questions according to the following three rules.

**Rule 1-** If the question starts with "What is the result of expression", the program will find the result of mathematical expression and print it on the screen.
Assume that the expression will include a single type of operator (only + or only - or only * or only /).
**Rule 2-** If the user asks a question to the computer with the phrase "What are the top10 words in the pattern", the
program will find and print the words that corresponds to this **pattern**. The symbol “-“ corresponds to only one letter.
**Rule 3-** The program should compare the words in the question with the words in the text in the corpus, and find the most similar (probable) answer. The number of common words between question and text is the fundamental criteria. If two or more texts have the same maximum count, the program will print all of them.
To answer a question, at least two words should match, except stop words. If there is no any matching, print "No answer"
string[] stop_words = {′′a′′, ′′after′′, ′′again, ′′all′′, ′′am′′, ′′and′′, ′′any′′, ′′are′′, ′′as′′, ′′at′′, ′′be′′, ′′been′′, ′′before′′, ′′between′′, ′′both′′, ′′but′′, ′′by′′, ′′can′′, ′′could′′, ′′for′′, ′′from′′, ′′had′′, ′′has′′, ′′he′′, ′′her′′, ′′here′′, ′′him′′, ′′in′′, ′′into′′, ”I”, ′′is′′, ′′it′′, ′′me′′, ′′my′′, ′′of′′, ′′on′′, ′′our′′, ′′she′′, ′′so′′, ′′such′′, ′′than′′, ′′that′′, ′′the′′, ′′then′′, ′′they′′, ′′this′′, ′′to′′, ′′until′′, ′′we′′, ′′was′′, ′′were′′, ′′with′′, ′′you′′}

<img width="547" alt="Screen Shot 2023-05-31 at 16 33 54" src="https://github.com/inomisay/Question-Answering-System/assets/98346164/36c40daa-0340-467c-aead-8990bbee1173">
<img width="547" alt="Screen Shot 2023-05-31 at 16 34 04" src="https://github.com/inomisay/Question-Answering-System/assets/98346164/fdc2fcd4-2052-4dd1-a84a-1668e6038299">

<img width="882" alt="Screen Shot 2023-05-31 at 16 33 25" src="https://github.com/inomisay/Question-Answering-System/assets/98346164/45d4f8b2-fbb4-4631-9670-3aadc4fc6b35">

**Notes:**
1. Your program must work correctly under all conditions. Try to control all possible errors.
2. You should use meaningful variable names, appropriate comments, and good prompting messages.
3. If you want, you may write your own *“procedures / functions”.*
