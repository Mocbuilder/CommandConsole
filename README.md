# CommandConsole
A command-based console. 
It is basically a command parser with extra features (scripting, permanent variables, etc...).

## Syntax
The syntax is really simple. First, all commands are uncapitalised. Second, if a command takes a variable, it is added with a ```-``` and then the variable, with no spaces. Command-specific examples are in the 'Commands' section.

## Commands
All available commands are:
- ```help``` -> Lists all available commands
- ```setcolor-[Any valid 8-Bit color]``` -> Sets the font color of the console
- ```joke [-ten]``` -> Get a random joke, or optionally ten random jokes.
- ```ip [-v4] [-v6]``` -> Get either the IPv4 or IPv6 addresses.
- ```ping-[Any valid IPv4 address]``` -> Pings the specified IP address
- ```sys- [hw -> Get hardware information] [os -> Get Operating System information] [net -> Get .Net Framework information] [programs -> Get all installed programs (from HKEY_LOCAL_MACHINE)]``` -> Get system information
- ```hacker-[Any valid 8-bit color]``` -> Makes you a Master haxxor, in any color you want
- ```clear``` -> Clears the console
- ```exit``` -> Quit the application
- ```script-[Valid file path to a text file]``` -> Run a script of commands
- ```sleep-[any valid number]``` -> wait for specified time in seconds. Mainly used in scripting
- ```print-[Text to be printed or 'var']-[variable name]``` -> Prints specified text or, if that is var-[any existing variable], prints the value of the variable
- ```add-[type]-[name]-[value]``` -> Add a new variable as 'string' 'int' or 'bool' and add a name and value
- ```get-[variable name]``` -> get any existing variable
- ```calc-[type of calculation: add, sub, div, mul]-[first number]-[second number]``` -> Do some simple calculations with two numbers
- ```rm-[Name of a existing variable]``` -> Remove any existing variable by name
- ```setvalue-[Name of existing variable]-[New value]``` -> Set a new value to an already existing variable. New value must be of the same type as the old value
- ```setname-[Name of a existing variable]-[New name of that variable]``` -> Set the name of any existing variable to a new name
- ```prcs``` -> List all currently running processes
- ```kill-[Name of any running process]``` -> Terminates the specified process. Could need Admin priviliges to execute properly
- ```read-[Type of new variable]-[Name of new variable]-[Message to be printed before the input]``` -> Creates a new variable and puts the next userinput as value, while printing a message to the user
- ```alias-[Command you want to alias]-[New command]``` -> Set the keyword for any command

## Scripting
Scripting is done in a text file, and is basically a list of commands.
Per line should be one command, and the syntax is exactly the same as when executing the commands in the console itself.
This is mainly usefull when you are trying to run a sequence of commands again and again without typing them all-over.
Comments are line based, which means that a comment is always one full line. They are initiated with "//".
An example script is provided in the "ExampleScript.txt" file.

## To-Do
- Let variables be able to be used in commands that take any parameters (maybe use ```Framework.Getvariable()``` ?)
- Nested Error messages are fixed, but ```Framework.GetVariable()``` is used alone and inside other methods, and when used inside it nests the error messages, probably applys to ```Framework.DeleteVariable()``` too
- think of more QoL improvments and scripting Commands

## Credits
Idea, Design and Programming			Mocbuilder (Mocbuilder Coding Creations) aka Me

Base-Code of the hacker-command			CollegeCode (https://www.youtube.com/watch?v=eWceJNkxbdU)

Special Thanks to rmoc81 for helping me with the programming.