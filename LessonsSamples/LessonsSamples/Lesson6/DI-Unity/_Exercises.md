# This file contains some exercises for Dependency Injection and ServiceLocator demo app



#### 1. Implement option *3. List Movies*

#### 2. Implement option *4. Find Movies*

#### 3. Integrate the `ServiceLocator` into the app

 - Make one of the implementation get its dependencies through the static ServiceLocator.Current
 - Get the IServiceLocator through Dependency Injection in one of your classes

#### 4. Create an abstraction for the console: `IConsole`

a) Why would we abstract the existent static Console class through IConsole? 

b) Why would we make an static caller to it that uses ServiceLocator to wrap the IConsole instance?


#### 5. Implement the console options as a set of commands registered into DI Container


All the commands could implement an `ICommand` interface (you could use (or gent inspired from) the interface from the `System.Windows.Input`)

Implement a class `Menu` that finds all `ICommand` implementations and displays the menu with them. When a menu entry is picked, it will execute that command by calling the `Execute()` function.

The console app should discover all available commands, build the menu with them and then execute them based on the user input

#### 6. Have more Movie Catalogs

Each *Moview Catalog* is stored in its own file and the name of the file is the name of the catalog.

*3. List Movies*  should first show the name of all available catalogs, and the user should type the catalog name that she wants to be listed

Sugestion: add `void Open(string catalogName)` and `string Create()` methods to `ITextStorage` to implement this.

#### 7. Add Rating to a movie

Implment a command for adding a rating to a movie

The user will type the name of the movie and then the rating. The rating will be stored on the same line with the movie name by appending the text *| Rating: xxxxx* 


This function may be added to the `Console` class for reading a user's input

```
public string AskInput(string message)
{
	Console.WriteLine();
	Console.WriteLine(message);

	return Console.ReadLine();
}
```