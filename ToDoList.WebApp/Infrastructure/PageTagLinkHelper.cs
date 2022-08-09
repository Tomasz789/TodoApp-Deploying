using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ToDoList.WebApp.Models.Paging;

namespace ToDoList.WebApp.Infrastructure
{
    [HtmlTargetElement("div", Attributes ="page-model")]
    public class PageTagLinkHelper : TagHelper
    {
        private IUrlHelperFactory urlHelper;

        public PageTagLinkHelper(IUrlHelperFactory urlHelper)
        {
            this.urlHelper = urlHelper;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string PageAction { get; set; }

        public bool PageClassEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string tagName = "div";
            var helper = urlHelper.GetUrlHelper(ViewContext);
            var result = new TagBuilder(tagName);

            for (int i = 1; i <= PagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");

                tag.Attributes["href"] = helper.Action(PageAction, new { taskListPage = i });

                if (PageClassEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PagingInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}
