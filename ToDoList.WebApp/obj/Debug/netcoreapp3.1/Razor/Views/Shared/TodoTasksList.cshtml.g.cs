#pragma checksum "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Shared\TodoTasksList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd863570e98fb05cb907dea7b637ba3bd6916e63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_TodoTasksList), @"mvc.1.0.view", @"/Views/Shared/TodoTasksList.cshtml")]
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
#line 1 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\_ViewImports.cshtml"
using ToDoList.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\_ViewImports.cshtml"
using ToDoList.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\_ViewImports.cshtml"
using ToDoList.WebApp.Models.Paging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Shared\TodoTasksList.cshtml"
using Todo.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd863570e98fb05cb907dea7b637ba3bd6916e63", @"/Views/Shared/TodoTasksList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff0249d22b4efe97e78c0b8de63431b6e0025e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_TodoTasksList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TodoTask>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card col-6 m-2\">\r\n    <div class=\"card-body col-5\">\r\n        <p>");
#nullable restore
#line 6 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Shared\TodoTasksList.cshtml"
      Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"card col-1 bg-danger\"><p>");
#nullable restore
#line 8 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Shared\TodoTasksList.cshtml"
                                    Write(Model.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TodoTask> Html { get; private set; }
    }
}
#pragma warning restore 1591
