# CommandConsole
A command-based console. 
Made to practice command-variable interactions.

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
- ```set-[type]-[name]-[value]``` -> Set a new variable as 'string' or 'int' and add a name and value
- ```get-[variable name]``` -> get any existing variable

## Scripting
Scripting is done in a text file, and is basically a list of commands.
Per line should be one command, and the syntax is exactly the same as when executing the commands in the console itself.
This is mainly usefull when you are trying to run a set of commands again and again without typing them all-over.
There are also some commands specifically made for scripting (although they work in the console too):
- ```sleep``` allows you to specify a time in seconds that the console will just stop
- ```print``` allows you to print any text to the console
- ```set``` allows to set a new variable with a type (either 'string' or 'int') and assign a name and value
- ```get``` allows to get any existing variable and print it with type, name and value (Example: string testvariable = Hello World!)

## To-Do
- fix ifval command