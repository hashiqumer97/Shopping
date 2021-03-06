#pragma checksum "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba0e7f9e571c18b564321fc231651fbd3d2c3cdd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_OrderItems), @"mvc.1.0.view", @"/Views/Orders/OrderItems.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\_ViewImports.cshtml"
using Shopping.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\_ViewImports.cshtml"
using Shopping;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\_ViewImports.cshtml"
using Shopping.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba0e7f9e571c18b564321fc231651fbd3d2c3cdd", @"/Views/Orders/OrderItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4282ea78104023bc0f6cbd9e36acd6e9672a16ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_OrderItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shopping.ViewModels.OrdersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/viewOrders.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
  
    ViewBag.Title = "Order Items";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba0e7f9e571c18b564321fc231651fbd3d2c3cdd4150", async() => {
                WriteLiteral(@"
    <h1 class=""text-center"">Order Items</h1>
    <div class=""text-center"">
        <table class=""table"" id=""orderitemstable"" title=""orderstable"" align=""center"">
            <thead>
                <tr>
                    <th>Order Item ID</th>
                    <th>Product ID</th>
                    <th>Order ID</th>
                    <th>Date</th>
                    <th>Unit Price</th>
                    <th>Quantity</th>
                    <th>Product Price</th>
                    <th>Action</th>

                </tr>
");
#nullable restore
#line 24 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
                 foreach (var items in Model.OrderLineItems)
                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td><p id=\"getorderitemid\">");
#nullable restore
#line 28 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
                                              Write(items.OrderItemId);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p></td>\r\n                        <td><p id=\"getproductid\"> ");
#nullable restore
#line 29 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
                                             Write(items.ProductId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p></td>\r\n                        <td><p id=\"getorderid\">");
#nullable restore
#line 30 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
                                          Write(items.OrderId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p></td>\r\n                        <td><input type=\"text\" id=\"getdate\"");
                BeginWriteAttribute("value", " value=\"", 1168, "\"", 1196, 1);
#nullable restore
#line 31 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
WriteAttributeValue("", 1176, items.OrderitemDate, 1176, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" /></td>\r\n                        <td><input type=\"text\" id=\"getunitprice\"");
                BeginWriteAttribute("value", " value=\"", 1297, "\"", 1330, 1);
#nullable restore
#line 32 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
WriteAttributeValue("", 1305, items.OrderitemUnitPrice, 1305, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" disabled /></td>\r\n                        <td><input type=\"text\" id=\"getquantity\"");
                BeginWriteAttribute("value", " value=\"", 1439, "\"", 1471, 1);
#nullable restore
#line 33 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
WriteAttributeValue("", 1447, items.OrderitemQuantity, 1447, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" oninput=\"calculate();\" /></td>\r\n                        <td><input type=\"text\" id=\"getproductprice\"");
                BeginWriteAttribute("value", " value=\"", 1598, "\"", 1634, 1);
#nullable restore
#line 34 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"
WriteAttributeValue("", 1606, items.OrderitemProductPrice, 1606, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"text-align:center\" disabled /></td>\r\n                        <td><input type=\"checkbox\"/></td>\r\n                    </tr>\r\n");
#nullable restore
#line 37 "C:\Users\Admin\source\repos\Shopping\Shopping\Views\Orders\OrderItems.cshtml"

                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </thead>
        </table>
        
    </div>
    <div class=""text-center"">
        <a role=""button"" id=""btnedit"" class=""btn btn-warning"" style=""align-items:center;color:white"" onclick=""updateOrder();"">Edit Order</a>
        <a role=""button"" id=""btndelete"" class=""btn btn-danger"" style=""align-items:center;color:white"" onclick=""deleteOrderLineRows();deleteOrder();"">Delete Order</a>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba0e7f9e571c18b564321fc231651fbd3d2c3cdd9726", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shopping.ViewModels.OrdersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
