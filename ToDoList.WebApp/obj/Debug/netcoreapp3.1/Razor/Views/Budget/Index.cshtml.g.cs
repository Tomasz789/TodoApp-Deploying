#pragma checksum "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34bdd1e4c46e6e898ad4e1b5997a14f9fd3ef1a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Budget_Index), @"mvc.1.0.view", @"/Views/Budget/Index.cshtml")]
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
#line 1 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
using ToDoList.WebApp.Models.ViewModels.BudgetViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34bdd1e4c46e6e898ad4e1b5997a14f9fd3ef1a8", @"/Views/Budget/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fff0249d22b4efe97e78c0b8de63431b6e0025e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Budget_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BudgetSummaryViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "AddExpense", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "AddIncome", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Budget", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("report"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"d-flex d-inline-flex m-2 align-content-center\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34bdd1e4c46e6e898ad4e1b5997a14f9fd3ef1a86582", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 6 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new ExpenseViewModel();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34bdd1e4c46e6e898ad4e1b5997a14f9fd3ef1a88172", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 7 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new IncomeViewModel();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        <h1>Budget summary (PLN)</h1>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34bdd1e4c46e6e898ad4e1b5997a14f9fd3ef1a89829", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "34bdd1e4c46e6e898ad4e1b5997a14f9fd3ef1a810099", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <br />
        <h2>Total incomes</h2>
        <table class=""table table-striped col-12 text-center"">
            <thead>
                <tr>
                    <th>Week</th>
                    <th>Month</th>
                    <th>Year</th>
                </tr>
            </thead>
            <tr>
                <td>");
#nullable restore
#line 25 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
               Write(Model.TotalIncomesCurrentWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
               Write(Model.TotalIncomesCurrentMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
               Write(Model.TotalIncomesCurrentYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
            </tr>
        </table>

        <h2>Total expenses</h2>
        <table class=""table table-striped col-12 text-center"">
            <thead>
                <tr>
                    <th>Week</th>
                    <th>Month</th>
                    <th>Year</th>
                </tr>
            </thead>
            <tr>
                <td>");
#nullable restore
#line 41 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
               Write(Model.TotalExpensesCurrentWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 42 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
               Write(Model.TotalExpensesCurrentMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
               Write(Model.TotalExpensesCurrentYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
            </tr>
        </table>
        <div id=""budgetPieChart"" style=""width:500px; height:500px""></div>
        <div id=""budgetDonutChart"" style=""width:500px; height:500px""></div>
        <div id=""linearChart"" style=""width:500px; height:500px""></div>
   </div>
</div>

<script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
<script type=""text/javascript"">
        google.charts.load('current', {'packages':['corechart']});
        google.charts.load('current',{'packages':['line']});
        google.charts.setOnLoadCallback(drawChart);

        function drawChart(){
            var data = google.visualization.arrayToDataTable([
                ['Budget', 'Price'],
                ['Incomes',  parseInt(");
#nullable restore
#line 61 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                                 Write(Model.TotalIncomesCurrentMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral(")], \r\n                [\'Expenses\',parseInt(");
#nullable restore
#line 62 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                                Write(Model.TotalExpensesCurrentMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")], 
            ]
        );

        var options = {title: 'Incomes and Expenses', width:'90%', height:'100%', chartArea: {width: '500px', height: '500px'}};
        var chart = new google.visualization.PieChart(document.getElementById('budgetPieChart'));
        chart.draw(data, options);
    }

    function drawDonutChartForWeek(){
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Budget');
            data.addColumn('number', 'Value');
            data.addRows([
                ['Incomes', parseInt(");
#nullable restore
#line 76 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                                Write(Model.TotalIncomesCurrentWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral(")],\r\n                [\'Expenses\', parseInt(");
#nullable restore
#line 77 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                                 Write(Model.TotalExpensesCurrentWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")]
            ]);

            var donutChartOpts = {
            'title':'Incomes and Expenses - this week',
            'width':'500px',
            'height':'500px',
         };

        var donutChart = new google.visualization.PieChart(document.getElementById('budgetDonutChart'));
        donutChart.draw(data, donutChartOpts);
     }
     function drawLinearChart(){
             var data = new google.visualization.DataTable();
             data.addColumn('string','Month');
             data.addColumn('number', 'Income value PLN');
            // data.addColumn('number', 'Expense value PLN');

             data.addRows([
                 ['Jan', ");
#nullable restore
#line 96 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 1).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Feb\', ");
#nullable restore
#line 97 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 2).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Mar\', ");
#nullable restore
#line 98 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 3).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Apr\', ");
#nullable restore
#line 99 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 4).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'May\', ");
#nullable restore
#line 100 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 5).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Jun\', ");
#nullable restore
#line 101 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 6).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Jul\', ");
#nullable restore
#line 102 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 7).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Aug\', ");
#nullable restore
#line 103 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 8).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                 [\'Sep\', ");
#nullable restore
#line 104 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                    Write(Model.Incomes.Where(x => x.CreatedAt.Month == 9).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                /* [\'Oct\', ");
#nullable restore
#line 105 "D:\Projekt\aspnet-core-final-project\ToDoList.WebApp\Views\Budget\Index.cshtml"
                      Write(Model.Incomes.Where(x => x.CreatedAt.Month == 10).Sum(x => x.IncomeValue));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]*/
             ]);
           var opts = {
                   chart:{
                       title: 'Annual incomes and expenses',
                       
                   },
                   width: 500,
                   height: 500
               
           };
           var chart = new google.charts.Line(document.getElementById('linearChart'));
           chart.draw(data, google.charts.Line.convertOptions(opts));

       }
     google.charts.setOnLoadCallback(drawDonutChartForWeek);
     google.charts.setOnLoadCallback(drawLinearChart);
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BudgetSummaryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
