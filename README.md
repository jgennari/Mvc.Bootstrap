# Mvc.Bootstrap

> Mvc.Bootstrap is a set of helpers designed to accelerate web developement using .NET MVC and Twitter Bootstrap

### Usage

Forms

    using(Html.BootstrapHorizontalForm(Url.Action("Action"), FormMethod.Post, new { id = "FormName" }))
    {
       ...
    }