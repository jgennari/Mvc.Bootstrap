using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Mvc.Bootstrap
{
    public static class Modal
    {
        public static Panel BootstrapBeginModal(this HtmlHelper htmlHelper, string id)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("modal hide");
            builder.Attributes.Add("id", id);

            htmlHelper.ViewContext.Writer.Write(builder.ToString(TagRenderMode.StartTag));
            return new Panel(htmlHelper.ViewContext);
        }

        public static MvcHtmlString BootstrapModalHeader(this HtmlHelper htmlHelper, string text)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("modal-header");

            TagBuilder button = new TagBuilder("button");
            button.Attributes.Add("type", "button");
            button.AddCssClass("close");
            button.Attributes.Add("data-dismiss", "modal");
            button.InnerHtml += "x";
            builder.InnerHtml += button;

            TagBuilder h3 = new TagBuilder("h3");
            h3.InnerHtml += text;
            builder.InnerHtml += h3;

            return MvcHtmlString.Create(builder.ToString());
        }

        public static Panel BootstrapBeginBody(this HtmlHelper htmlHelper)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("modal-body");

            htmlHelper.ViewContext.Writer.Write(builder.ToString(TagRenderMode.StartTag));
            return new Panel(htmlHelper.ViewContext);
        }

        public static Panel BootstrapBeginFooter(this HtmlHelper htmlHelper)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("modal-footer");

            htmlHelper.ViewContext.Writer.Write(builder.ToString(TagRenderMode.StartTag));
            return new Panel(htmlHelper.ViewContext);
        }

        public class Panel : IDisposable
        {
            private readonly TextWriter _writer;
            public Panel(ViewContext viewContext)
            {
                _writer = viewContext.Writer;
            }

            public void Dispose()
            {
                this._writer.Write("</div>");
            }
        }
    }
}

