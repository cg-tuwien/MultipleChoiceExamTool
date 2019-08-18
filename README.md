# MultipleChoiceExamTool
A tool to conduct multiple choice exams

Developed by Johannes Unterguggenberger at TU Wien   

**Technologies:**
* C# 
* WPF

**Requirements:**    
* Operating system: Windows 10 (most likely also 7 and 8)     
* .NET Framework 4.6.1 (probably also earlier versions)       
* Visual Studio 2017 or 2019 (probably also earlier versions)

## Input: CSV

The tool takes CSV files as input which have to provide exactly 8 columns, separated by semicolons (`;`).

*Example Input CSV:*
```
#Question;#Answer1;#Answer2;#Answer3;#Answer4;#Answer5;#Correct;#OptionalImage
What is your quest?;To seek the Holy Grail.;;;;I don't know;1;
What is your favorite color?;Blue.;Yellow.;Red.;Green.;None of these.;1;image_showing_the_colors.png
What is the air-speed velocity of an unladen swallow?;;What do you mean?;An African or European swallow?;;Huh? I don't know that.;23;
```
  
The first line contains the header, the actual questions start at the second line.       
There is a fixed number of possible answers, which is 5. To provide fewer answers, the respective entries can be left blank like so: `Question A;The Answer is 1; The Answer is 2;;;;1;` In this example, we only have two answers.

The syntax for the `#Correct` column is as follows: Concatenate every correct answer's 1-based index without separators.    
*Example 1:* `[...];123;[...]` => Answers 1, 2 and 3 are correct, 4 and 5 are wrong         
*Example 2:* `[...];5;[...]` => Answer 5 is correct, all others are wrong        
*Example 3:* `[...];14;[...]` => Answers 1 and 4 are correct, 2, 3 and 5 are wrong         
*Example 4:* `[...];;[...]` => There is no correct answer        
*Example 5:* `[...];12345;[...]` => All answers are correct        
*Example 5:* `[...];123456;[...]` => *Invalid input!*, will always be evaluated as a wrong answer by the tool      

The `#OptionalImage` column can be used to specify a relative path to an image that should be displayed with the respective question.

## Screenshot

![Alt text](/screenshot.png "MultiplChoiceExamTool Screenshot")

## Credits

Copyright (c) 2018 Johannes Unterguggenberger       
Developed at Vienna University of Technology         
License: MIT

#### Used Libraries:

*File Helpers*     
Copyright (c) 2003-2015 - Marcos Meli        
http://www.filehelpers.net/      
License: MIT
