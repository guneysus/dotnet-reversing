compiling simple programs
=========================

```csharp
// App.cs
public class App {
    public static void Main () {
        System.Console.WriteLine("Hello World");
    }
}
```

```shell
csc /debug:full App.cs

objdump -FD -M intel --section=.text .\App.exe > app.text.dump

objdump -FD -M intel --section=.rsrc .\App.exe > app.rsrc.dump

ildasm.exe .\App.exe /OUT=App.il

objdump.exe -D -M intel .\App.exe > 1.dump

```