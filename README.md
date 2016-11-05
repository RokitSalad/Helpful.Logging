# Helpful.Logging
Contains a log4net wrapper and a logging context for automatically adding values to log entries, such as correlation id or process id. 

```c#
this.GetLogger().Info("a leg entry", new Exception());
```
The object.GetLogger() extension method can be used anywhere to get a wrapper for a log4net logger. This logger can be used in the usual way. Any log messages will be wrapped in an object listing all tracing info.

```c#
LoggingContext.Set("some-key", "some value");
```
The LoggingContext is static and can be used from anywhere in your code if you want to add new items or access existing items. For example, if you're consuming an event which also contained a correlation id, you could add this directly to the LoggingContext. The LoggingContext values will persist as you move from thread to thread so you should be safe with async code.

##Install
Install-Package Helpful.Logging

##Note
This is tightly coupled to log4net - if you don't use this, it's no use to you.