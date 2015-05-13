# Mutility

A set of every day use utility classes providing following features:

- Argument validation including general assertion checks, null checks and others. Checkout Ensure class.
- Logging abstraction and NLog integration.

# Examples

```C#

public void SomeMethod(string strArg1, string strArg2, object objArg, DateTime dateArg, int intArg)
{
    Ensure.NotEmpty(strArg1);
    Ensure.NotNull(strArg).And(objArg);
    Ensure.That(dateArg > DateTime.Now).And(intArg != 0).OrThrow(new InvalidOperationException("Invalid data"));
    // Method body...
}
 
```
