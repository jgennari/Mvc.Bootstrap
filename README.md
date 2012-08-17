# Mvc.Bootstrap

> Mvc.Bootstrap is a set of helpers designed to accelerate web developement using .NET MVC and Twitter Bootstrap

### Usage

Form

    using(Html.BootstrapHorizontalForm(Url.Action("Action"), FormMethod.Post, new { id = "FormName" }))
    {
       ...
    }

Modal
    
    @using(Html.BootstrapBeginModal("Popup"))
    {
        @Html.BootstrapModalHeader("New Modal")
        using (Html.BootstrapBeginBody())
        {
        }
        using (Html.BootstrapBeginFooter())
        {
        }
    }