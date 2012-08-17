using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace Mvc.Bootstrap
{
    public enum BootstrapButtonType
    {
        Default,
        Primary,
        Info,
        Success,
        Warning,
        Danger,
        Inverse
    }

    public static class Buttons
    {
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string url, string text, BootstrapButtonType? type, BootstrapIcon? icon)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.AddCssClass("btn");

            if (!string.IsNullOrEmpty(url))
                builder.Attributes.Add("href", url);

            if (type.HasValue)
                builder.AddCssClass(type.Value.ToClass());

            builder.InnerHtml += string.Concat(icon.HasValue ? htmlHelper.BootstrapIconWhite(icon.Value).ToString() : "", " ", text);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static string ToClass(this BootstrapButtonType type)
        {
            switch (type)
            {
                case BootstrapButtonType.Primary:
                    return "btn-primary";
                case BootstrapButtonType.Info:
                    return "btn-success";
                case BootstrapButtonType.Success:
                    return "btn-success";
                case BootstrapButtonType.Warning:
                    return "btn-warning";
                case BootstrapButtonType.Danger:
                    return "btn-danger";
                case BootstrapButtonType.Inverse:
                    return "btn-inverse";
            }
            return "";
        }
    }
}
