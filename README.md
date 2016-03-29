# Primes Table

#### How to run it

Just open it on Visual Studio. Build Solution once. Set console as startup project and Run/Debug it.

If input number is less than 15 the prime table will be displayed in the console, otherwise it will create a csv file "primeTable.csv" just beside the exe file in the bin folder of the console project.


#### Some comments about the design and the implementation process

I Implemented it using TDD style. My approach was the following:

* First I started adding simple tests to test/design the prime genration numbers method. I started adding classes/methods as needed and adding logic/refactoring for each test to pass. I ended with a simple naive not optimized but functional prime generation algorithm.
* Once it was tested and working and I was satisfied with the initial implementation I moved the classes and methods to their own class library project and out of the test project.
* I started then to write tests and design the table generation. Same thought principle as in previous method.
* Once this was tested and implemented I started to think in a better way of generate prime numbers as it was clearly not efficient for long numbers. Didn't know much about it so I started to investigate. Found out about Sieve Theory and how it is useful specially for prime numbers generation ([Sieve Theory](https://en.wikipedia.org/wiki/Sieve_theory), [Generate Primes](https://en.wikipedia.org/wiki/Generating_primes)). I decided to use one of the simplest one but efficient enough for this task the [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) which basically means that if you know your limit you then start eliminating multiples starting with 2 until limit, then 3 etc. Then I realised that for that I needed to know the last value of the range, so started to find out and what is used is an approximation to the nth prime number that for numbers greater than 6 can be obtained by [n * (Log(n) + Log(Log(n)))]. So I wrote a decent algorithm for all that and it was a great improvement on performance.
* Finally I started to work on the actual display of the table. For this test I decided to do a simple console application. But to showcase some flexibility I created an interface for Rendering the table, and then 2 concrete implementations one to write to console and another to write to a csv file. I decided that best way to showcase was that program after reading input will decide that if is less than 15 it will do console rendering if not it will do csv file rendering. But it is extensible and will be easier for example to create another rendered to render file in sql, in binary, etc.


#### What I am pleased with

* I think It the prime generation and the table generation is quite efficient and it doesnt have to many lines of code.
* It has a good suit of tests using Nunit, and it has strong design due to TDD.
* The display of table is extensible and quite easier to change for another.
* It has good separation of concerns


#### What Would I do if I had more time

 * The prime generation algorithm could be better. I used one of the simplest sieve implementations. There are others more complex that can do things much more faster.
 * The table generation algorithm can be improved for example calculating table[i,j] cell is same as calculating table[j,i] cell so that can be improved to calculate once.
 * The display of data can definitely be improved. Now it little bit slow for more than 7000 and the file end being around 1GB with 10K. I did optimise it a little so it doesnt have any out of memory exception at least until 10K primes.
 * The Separation of concerns and SOLID principles could be done little bit better,, maybe separating the prime table generation to its own class, creating some interface for prime generation class and injecting it to new class.
 * I could have done more performance testing and also more testing in the UI, there is at the moment no tests on the file or console display methods.

#### Final comments

I did enjoy this excercice as even it seem simple, it has several things to consider. I learned lot of things about sieve theory and about prime numbers that I did not know before. And It also help me think in better design for extensibility, think on performance when I am coding and other things.


