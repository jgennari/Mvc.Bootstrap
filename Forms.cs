using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using System.IO;

namespace Mvc.Bootstrap
{
    public static class Forms
    {
        public static BootstrapForm BootstrapHorizontalForm(this HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return StyledForm(htmlHelper, formAction, method, htmlAttributes, "form-horizontal");
        }
        public static BootstrapForm BootstrapSearchForm(this HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return StyledForm(htmlHelper, formAction, method, htmlAttributes, "form-search");
        }
        public static BootstrapForm BootstrapVerticalForm(this HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return StyledForm(htmlHelper, formAction, method, htmlAttributes, "form-vertical");
        }
        public static BootstrapForm BootstrapInlineForm(this HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            return StyledForm(htmlHelper, formAction, method, htmlAttributes, "form-inline");
        }

        static BootstrapForm StyledForm(this HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes, string cssClass)
        {
            TagBuilder builder = new TagBuilder("fieldset");
            builder.AddCssClass(cssClass);
            builder.MergeAttributes<string, object>(htmlAttributes);
            builder.MergeAttribute("action", formAction);
            builder.MergeAttribute("method", HtmlHelper.GetFormMethodString(method), true);
            htmlHelper.ViewContext.Writer.Write(builder.ToString(TagRenderMode.StartTag));
            
            TagBuilder fieldset = new TagBuilder("fieldset");
            htmlHelper.ViewContext.Writer.Write(fieldset.ToString(TagRenderMode.StartTag));

            return new BootstrapForm(htmlHelper.ViewContext);
        }


        public class BootstrapForm : IDisposable
        {
            private readonly TextWriter _writer;
            public BootstrapForm(ViewContext viewContext)
            {
                _writer = viewContext.Writer;
            }

            public void Dispose()
            {
                this._writer.Write("</fieldset></form>");
            }
        }

    }
}
