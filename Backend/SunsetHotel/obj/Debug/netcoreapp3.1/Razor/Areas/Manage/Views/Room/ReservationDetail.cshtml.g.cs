#pragma checksum "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cb5a0bd38bceec0aa11f81f1069cdf4718520e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Room_ReservationDetail), @"mvc.1.0.view", @"/Areas/Manage/Views/Room/ReservationDetail.cshtml")]
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
#line 1 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\_ViewImports.cshtml"
using SunsetHotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\_ViewImports.cshtml"
using SunsetHotel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\_ViewImports.cshtml"
using SunsetHotel.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cb5a0bd38bceec0aa11f81f1069cdf4718520e0", @"/Areas/Manage/Views/Room/ReservationDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f093b1a0b311fac9cc4e22a09fcc54b45452af94", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Room_ReservationDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Reservation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "accept", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success waves-effect waves-light order-accept"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "reject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger waves-effect waves-light order-reject"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
  
    ViewData["Title"] = "ReservationDetail";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""main-content"">

    <div class=""page-content"">
        <div class=""container-fluid"">

            <!-- start page title -->
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""page-title-box d-sm-flex align-items-center justify-content-between"">
                        <h4 class=""mb-sm-0"">Reservation Details</h4>
                        <div class=""page-title-right"">
                            <ol class=""breadcrumb m-0"">
                                <li class=""breadcrumb-item""><a href=""javascript: void(0);"">Tables</a></li>
                                <li class=""breadcrumb-item active"">Reservation Details</li>
                            </ol>
                        </div>

                    </div>
                </div>
            </div>
            <!-- end page title -->

            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""c");
            WriteLiteral(@"ard-body"">
                            <div class=""table-responsive"">
                                <table class=""table table-editable table-nowrap align-middle table-edits"">
                                    <tbody>
                                        <tr>
                                            <td data-field=""User"" style=""width: 20%"">User:</td>
                                            <td data-field=""v"">");
#nullable restore
#line 37 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                          Write(Model.appUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 37 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                    Write(Model.appUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 37 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                                           Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""Address"" style=""width: 20%"">Address:</td>
                                            <td data-field=""");
#nullable restore
#line 41 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 41 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                        Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 41 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                      Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 41 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                                      Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 41 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                                                       Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 41 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                                                                     Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""Logo Part 1"" style=""width: 20%"">Check-in:</td>
                                            <td data-field=""");
#nullable restore
#line 45 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.CheckIn.ToString("MM-dd-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 45 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                              Write(Model.CheckIn.ToString("MM-dd-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""Check-out"" style=""width: 20%"">Check-out:</td>
                                            <td data-field=""");
#nullable restore
#line 49 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.CheckOut.ToString("MM-dd-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 49 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                                               Write(Model.CheckOut.ToString("MM-dd-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""User note"" style=""width: 20%"">User note:</td>
                                            <td data-field=""");
#nullable restore
#line 53 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.SpecialReq);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 53 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                          Write(Model.SpecialReq);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""Adult Count"" style=""width: 20%"">Adult Count:</td>
                                            <td data-field=""");
#nullable restore
#line 57 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.AdultCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 57 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                          Write(Model.AdultCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""Child Count"" style=""width: 20%"">Child Count:</td>
                                            <td data-field=""");
#nullable restore
#line 61 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.ChildCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 61 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                          Write(Model.ChildCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                        </tr>
                                        <tr>
                                            <td data-field=""Room Code"" style=""width: 20%"">Room Code:</td>
                                            <td data-field=""");
#nullable restore
#line 65 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                       Write(Model.room.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 65 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                         Write(Model.room.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <td data-field=\"Status\" style=\"width: 20%\">Status:</td>\r\n");
#nullable restore
#line 69 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                             if (Model.Status == null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td data-field=\"Status\"><span class=\"badge rounded-pill bg-warning\">Pending</span></td>\r\n");
#nullable restore
#line 72 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                            }
                                            else if (Model.Status == true)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td data-field=\"Status\"><span class=\"badge rounded-pill bg-success\">Accepted</span></td>\r\n");
#nullable restore
#line 76 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td data-field=\"Status\"><span class=\"badge rounded-pill bg-danger\">Rejected</span></td>\r\n");
#nullable restore
#line 80 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tr>\r\n");
#nullable restore
#line 82 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                         if (Model.AdminNote != null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td data-field=\"Admin note\" style=\"width: 20%\">Admin note:</td>\r\n                                                <td data-field=\"");
#nullable restore
#line 86 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                           Write(Model.AdminNote);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 86 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                                             Write(Model.AdminNote);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 88 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n");
#nullable restore
#line 91 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                 if (Model.Status == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cb5a0bd38bceec0aa11f81f1069cdf4718520e020578", async() => {
                WriteLiteral(@"
                                        <div style=""margin-bottom:30px"" class=""form-group col-6"">
                                            <label>Admin Note</label>
                                            <textarea id=""note"" type=""text"" class=""form-control""></textarea>
                                            <span class=""text-danger"" id=""note-error""></span>
                                        </div>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cb5a0bd38bceec0aa11f81f1069cdf4718520e022401", async() => {
                WriteLiteral("Accept");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 100 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                             WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cb5a0bd38bceec0aa11f81f1069cdf4718520e024734", async() => {
                WriteLiteral("Reject");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 101 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                                             WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 102 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 6660, "\"", 6679, 1);
#nullable restore
#line 103 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Areas\Manage\Views\Room\ReservationDetail.cshtml"
WriteAttributeValue("", 6668, ViewBag.Id, 6668, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""RoomId""/>
                            </div>
                        </div>
                    </div>
                </div> <!-- end col -->
            </div> <!-- end row -->
        </div> <!-- container-fluid -->
    </div>
    <!-- End Page-content -->
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
    $(document).ready(function () {
        var ROOMID = document.getElementById(""RoomId"").value
        $(document).on(""click"", "".order-accept"", function (e) {
            e.preventDefault();
            var note = $(""#note"").val();
            var url = $(this).attr(""href"") + ""?note="" + note;
            fetch(url)
                .then(response => response.json())
                .then(data => {
                    if (data.status == 402) {
                        window.location.href = ""/manage/dashboard/error""
                    } else {
                        window.location.href = `/manage/room/reservation/${ROOMID}`;
                    }
                });
        })
        $(document).on(""click"", "".order-reject"", function (e) {
            e.preventDefault();
            var note = $(""#note"").val();
            if (note == """")
            {
                $(""#note-error"").text(""Note is required!"")
            }
            else {
                var url =");
                WriteLiteral(@" $(this).attr(""href"") + ""?note="" + note;
                fetch(url)
                    .then(response => response.json())
                    .then(data => {
                        if (data.status == 400) {
                            $(""#note-error"").text(""Note is required!"")
                        }
                        else if (data.status == 402)
                        {
                            window.location.href = ""/manage/dashboard/error""
                        }
                        else {
                            location.reload();
                        }
                    });
            }

        })
    })
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Reservation> Html { get; private set; }
    }
}
#pragma warning restore 1591
