# This file contains some exercises for Dependency Injection and ServiceLocator demo app

#### 1. Implement the console options as a set of commands registered into DI Container

All the commands could implement an `ICommand` interface. Example:
```
public interface ICommand
{
    void Execute();
    char KeyChar { get; }
    string MenuEntry { get; }
}
```

Build the menu by getting all the `ICommand` implementations through constructor DI. When a menu entry is picked, it will execute that command by calling the `Execute()` function.

#### 2. Create an abstraction for the console: `IConsole`

a) Why would we abstract the existent static Console class through IConsole? 

b) Register in the DIC the `IConsole` with the `AppConsoleImplementation` and refactor the code to use the `IConsole`

#### 3. Integrate the `ServiceLocator` into the app

 - Make one of the implementation get its dependencies through the static `ServiceLocator.Current` or through an injected `IServiceProvider` or `IServiceLocator`
 - Get the IServiceLocator through Dependency Injection in one of your classes

#### 4. Implement command *3. List Movies*

#### 5. Rewrite the `MoviesConsoleCreator`

a) Reimplement the `MoviesConsoleCreator` command to support the following functionality:
 - read more properties of a movie one by one. They UI will present the user the name of the property that she should enter
 - The Movie should have at least the following fields: `Title :string` and `Rating :int`
 - when all properties of a movie were read, ask the user if she wants to add a new movie

Use the following interfaces:

```
interface IEntityReader
{
    IEntityFieldsReader<T> BeginEntityRead<T>();
}

interface IEntityFieldsReader<T>
{
    IEnumerable<string> GetFields();
    void SetFieldValue(string value);
    T GetEntity();
}

interface IEntityRepository
{
    IEnumerable<Movie> GetAll();
    void Add(Movie movie);
}
```

b) Write unit tests that prove that the new `MoviesConsoleCreator` works


#### 6. Implement `IEntityReader` and `IEntityFieldsReader`

*Suggestion*: Use *Service Locator Pattern* to get and return the `IEntityFieldsReader<T>` implementations on the `IEntityReader<T>()` function.

#### 7. Make a generic implementation of  `IEntityFieldsReader<T>`

We may have a generic class that implements `IEntityFieldsReader<T>` for any T by using reflection. It should be registered to DI by using the open generic type.


#### 8. Implement option *4. Find Movies*

a) We could save the movies in an in-memory repository which has application lifetime.
The find movies could work on this one.

#### 9. Make a repository that can store any type of entity

Make a repository that supports any type of entity. We could add `MovieReview` entity beside the existent `Movie`.

The repository interface may be like:

```
interface IEntityRepository
{
    IEnumerable<T> GetAll<T>();
    void Add<T>(T entity);
}
```

We could have individual implementations for each type, because each we'd like to save each type in its own file, following a naming convention for the file name. We'd like to have:

```
interface IEntityRepository<T>
{
    IEnumerable<T> GetEntities();
    void Add(T entity);
}

class MovieRepository :  IEntityRepository<Movie>
{
    ...
}
```

*Suggestion*: the non-generic class that implements `IEntityRepository` could use the *Service Locator Pattern* to get the generic implementation for the specific `T` and forward the call to it for each function.



#### 10. Create and store Reviews for Movies

We should have the `MovieReview` entity:

```
class MovieReview
{
    public string MovieTitle { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
}
```

Use the generic implementations we have to implement a new command for creating Reviews for already added Movies


#### 11. Create Movies with Reviews

Create a new command that allows the user to create a new movie, and after she enters the values for all its properties, the application asks her if she wants to add reviews for the Movie she is currently adding.

If yes, then the reviews are added in the same session with the current movie that is being created.

*Optional:* At the end the user may have the possibility to Save or discard the Movie she just entered

You should use an implementation of the `IEntityRepository` (not the generic one) and the command should depend only on this interface not on the generic one (IEntityRepository<T>)