# WebApiExample
A Simple Web API project in .Net 6 that contains examples for HTTP Filters


## Focus points

Class `MyBasicFilter` implements `IActionFilter`


Filter is then registered in `Program.cs`:

```
builder.Services.AddControllers(config =>
{
    config.Filters.Add(new MyBasicFilter());
});
```

`MyBasicFilter` implements 2 methods: 
- `public void OnActionExecuted(ActionExecutedContext context)` which runs **after** the Controller Method execution 
and 
- `public void OnActionExecuting(ActionExecutingContext context)` which runs **before** the actual controller method execution.
