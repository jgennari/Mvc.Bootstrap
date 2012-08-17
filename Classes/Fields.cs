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
    public static class Fields
    {

        public static MvcHtmlString BootstrapLabel(this HtmlHelper htmlHelper, string label, string labelfor)
        {
            TagBuilder builder = new TagBuilder("label");
            builder.AddCssClass("control-label");
            if (!string.IsNullOrEmpty(labelfor))
                builder.Attributes.Add("for", labelfor);

            builder.InnerHtml += label;

            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString BootstrapTextbox(this HtmlHelper htmlHelper, MvcHtmlString htmlTextBox, string prepend, string append)
        {
            TagBuilder builder = new TagBuilder("div");

            if (!string.IsNullOrEmpty(prepend))
            {
                builder.AddCssClass("input-prepend");
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("add-on");
                span.InnerHtml += prepend;
                builder.InnerHtml += span;
            }

            builder.InnerHtml += htmlTextBox;

            if (!string.IsNullOrEmpty(append))
            {
                builder.AddCssClass("input-append");
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("add-on");
                span.InnerHtml += append;
                builder.InnerHtml += span;
            }

            return MvcHtmlString.Create(builder.ToString());
        }
        public static MvcHtmlString BootstrapControlGroup(this HtmlHelper htmlHelper, MvcHtmlString htmlLabel, MvcHtmlString htmlEditor, MvcHtmlString htmlValidator)
        {
            return BootstrapControlGroup(htmlHelper, htmlLabel, htmlEditor, htmlValidator, null);
        }
        public static MvcHtmlString BootstrapControlGroup(this HtmlHelper htmlHelper, MvcHtmlString htmlLabel, MvcHtmlString htmlEditor, MvcHtmlString htmlValidator, MvcHtmlString htmlHelpText)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("control-group");
            builder.InnerHtml += htmlLabel;

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("controls");
            div.InnerHtml += htmlEditor;

            div.InnerHtml += htmlValidator;
            
            if (htmlHelpText != null && !string.IsNullOrEmpty(htmlHelpText.ToString()))
            {
                TagBuilder p = new TagBuilder("p");
                p.AddCssClass("help-block");
                p.InnerHtml += htmlHelpText;
                div.InnerHtml += p;
            }

            builder.InnerHtml += div;

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
