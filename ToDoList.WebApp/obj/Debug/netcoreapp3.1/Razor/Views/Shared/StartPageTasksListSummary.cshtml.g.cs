#pragma checksum "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37579c333a1d3f80490bee40fe9f30df9241f0c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_StartPageTasksListSummary), @"mvc.1.0.view", @"/Views/Shared/StartPageTasksListSummary.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\_ViewImports.cshtml"
using ToDoList.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\_ViewImports.cshtml"
using ToDoList.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\_ViewImports.cshtml"
using ToDoList.WebApp.Models.Paging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
using Todo.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37579c333a1d3f80490bee40fe9f30df9241f0c3", @"/Views/Shared/StartPageTasksListSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff0249d22b4efe97e78c0b8de63431b6e0025e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_StartPageTasksListSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TodoList>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center text-white m-1\" style=\"width:500px; height:500px\">\r\n        <div class=\"card bg-primary\">\r\n            <div class=\"card-header\">\r\n                <h1>");
#nullable restore
#line 7 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <p>");
#nullable restore
#line 8 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
              Write(Model.Tasks.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" activities</p>\r\n            </div>\r\n            <div class=\"card-body text-secondary bg-white\">\r\n");
#nullable restore
#line 11 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
                 foreach (var task in @Model.Tasks)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4>");
#nullable restore
#line 13 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
                   Write(task.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 14 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"card-footer\">\r\n                <p>Contains ");
#nullable restore
#line 17 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Shared\StartPageTasksListSummary.cshtml"
                       Write(Model.Tasks.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" <strong class=\"text-danger\"> important.</strong></p>\r\n            </div>\r\n        </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TodoList> Html { get; private set; }
    }
}
#pragma warning restore 1591
