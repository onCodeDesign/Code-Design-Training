# This file contains some exercises for Dependency Injection and ServiceLocator demo app



#### 1. Implement option *3. List Movies*

#### 2. Implement option *4. Find Movies*

#### 3. Integrate the `ServiceLocator` into the app

 - Make one of the implementation get its dependencies through the static ServiceLocator.Current
 - Get the IServiceLocator through Dependency Injection in one of your classes

#### 4. Implement the console options as a set of commands registered into Unity Container
	
All the commands could implement an `ICommand` interface (you could use (or gent inspired from) the interface from the `System.Windows.Input`)

Implement a class `Menu` that finds all `ICommand` implementations and displays the menu with them. When a menu entry is picked, it will execute that command by calling the `Execute()` function.

The console app should discover all available commands, build the menu with them and then execute them based on the user input