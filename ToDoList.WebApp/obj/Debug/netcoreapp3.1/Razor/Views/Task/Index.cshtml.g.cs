#pragma checksum "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Task\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "750431664523ee003b15de728bac97fadfc259d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_Index), @"mvc.1.0.view", @"/Views/Task/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"750431664523ee003b15de728bac97fadfc259d1", @"/Views/Task/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff0249d22b4efe97e78c0b8de63431b6e0025e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Task_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Todo.Domain.Entities.TodoTask>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Task\Index.cshtml"
 foreach(var t in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 6 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Task\Index.cshtml"
   Write(t.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>");
#nullable restore
#line 7 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Task\Index.cshtml"
  Write(t.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 8 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Task\Index.cshtml"
  Write(t.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 9 "D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\ToDoList.WebApp\Views\Task\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Todo.Domain.Entities.TodoTask>> Html { get; private set; }
    }
}
#pragma warning restore 1591
