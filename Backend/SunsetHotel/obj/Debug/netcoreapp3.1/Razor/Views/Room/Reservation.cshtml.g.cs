#pragma checksum "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbe8a3756b6cd051803d6517b734699b450b2330"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Room_Reservation), @"mvc.1.0.view", @"/Views/Room/Reservation.cshtml")]
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
#line 1 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\_ViewImports.cshtml"
using SunsetHotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\_ViewImports.cshtml"
using SunsetHotel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\_ViewImports.cshtml"
using SunsetHotel.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbe8a3756b6cd051803d6517b734699b450b2330", @"/Views/Room/Reservation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc1cc186ba708d6887277c50d45e312042de428b", @"/Views/_ViewImports.cshtml")]
    public class Views_Room_Reservation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Room>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("reservation-form_sendemail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("reservation__form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-animate-in", new global::Microsoft.AspNetCore.Html.HtmlString("animateUp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
  
    ViewData["Title"] = "Reservation";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- CONTENT
  ================================================== -->
<!-- section header -->
<section class=""section__header"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <div class=""welcome__content"">
                    <h1 class=""welcome_content__title"">Reservation</h1>

                    <!-- Breadcrumbs -->
                    <ol class=""breadcrumb"">
                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b23308508", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                        <li class=\"active\">Reservation</li>\r\n                    </ol>\r\n\r\n                    <p class=\"welcome_content__desc\">");
#nullable restore
#line 22 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                                                Write(ViewBag.Setting.ReservationWelcomeContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div> <!-- .welcome__content -->
            </div>
        </div> <!-- / .row -->
    </div> <!-- / .container -->
    <div class=""home__bg reservation__bg""></div>
</section> <!-- / .section header -->
<!-- section reservation -->
<section class=""section__reservation"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-sm-5 col-sm-push-7 col-md-4 col-md-push-8"">
                <div class=""booking__details-body"">
                    <p class=""subheading"">Booking details</p>
                    <h2 class=""section__heading"">Selected room</h2>
                    <figure class=""room__details"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "bbe8a3756b6cd051803d6517b734699b450b233011048", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1471, "~/assets/img/", 1471, 13, true);
#nullable restore
#line 38 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
AddHtmlAttributeValue("", 1484, Model.RoomImages[0].ImageName, 1484, 30, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <figcaption>\r\n                            <h3>");
#nullable restore
#line 40 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <div class=\"room__price\">\r\n                                $");
#nullable restore
#line 42 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                            Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <small>/ night</small>\r\n                            </div>\r\n");
#nullable restore
#line 44 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                             if (Model.Desc.Length > 108)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p class=\"room__desc\">\r\n                                    ");
#nullable restore
#line 47 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                               Write(Model.Desc.Substring(0, 108));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ...\r\n                                </p>\r\n");
#nullable restore
#line 49 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p class=\"room__desc\">\r\n                                    ");
#nullable restore
#line 53 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                               Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n");
#nullable restore
#line 55 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </figcaption>
                    </figure> <!-- / .room__details -->
                </div> <!-- .booking__details-body -->
                <div class=""info__body"">
                    <p class=""info__title"">Information</p>
                    <ul class=""info__content"">
                        <li>
                            <p class=""info-text"">If you have some questions with booking please contact us.</p>
                        </li>
                        <li>
                            <i class=""icon ion-android-pin""></i>
                            <div class=""info-content"">
                                <div class=""title"">Address</div>
                                <div class=""description"">");
#nullable restore
#line 69 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                                                    Write(ViewBag.Setting.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </li>
                        <li>
                            <i class=""icon ion-android-call""></i>
                            <div class=""info-content"">
                                <div class=""title"">Phone / Fax</div>
                                <div class=""description"">");
#nullable restore
#line 76 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                                                    Write(ViewBag.Setting.PhoneNumber1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 76 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                                                                                    Write(ViewBag.Setting.PhoneNumber2);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </li>
                        <li>
                            <i class=""icon ion-android-mail""></i>
                            <div class=""info-content"">
                                <div class=""title"">E-mail</div>
                                <div class=""description"">");
#nullable restore
#line 83 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                                                    Write(ViewBag.Setting.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </li>
                    </ul> <!-- .info__content -->
                </div> <!-- / .info__body -->
            </div>
            <div class=""col-sm-7 col-sm-pull-5 col-md-8 col-md-pull-4"">
                <div class=""reservation__form-body"">
                    <p class=""subheading"">Booking form</p>
                    <h2 class=""section__heading"">Personal info</h2>
                    <p class=""section__subheading"">
                        ");
#nullable restore
#line 94 "C:\Users\Kanan Qarazada\Desktop\Full_Stack_Project\Backend\SunsetHotel\Views\Room\Reservation.cshtml"
                   Write(ViewBag.Setting.ReservationTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>

                    <!-- Alert message -->
                    <div class=""alert"" id=""form_reservation"" role=""alert""></div>

                    <!-- Please carefully read the README.pdf file in order to setup the PHP reservation form properly -->

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233019034", async() => {
                WriteLiteral(@"
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""check-in"" class=""sr-only"">Arrival date</label>
                                <input type=""date"" name=""check-in"" class=""form-control"" id=""check-in""
                                       value=""2017-04-09"">
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""check-out"" class=""sr-only"">Departure date</label>
                                <input type=""date"" name=""check-out"" class=""form-control"" id=""check-out""
                                       value=""2017-04-18"">
                                <span class=""help-block""></span>
                            </div>
                        </div>
               ");
                WriteLiteral(@"         <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""form-adults"" class=""sr-only"">Adults</label>
                                <select class=""form-control"" name=""form-adults"" id=""form-adults"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233020725", async() => {
                    WriteLiteral("Adults");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233022072", async() => {
                    WriteLiteral("1 Adult");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233023333", async() => {
                    WriteLiteral("2 Adults");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233024595", async() => {
                    WriteLiteral("3 Adults");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""form-children"" class=""sr-only"">Children</label>
                                <select class=""form-control"" name=""form-children"" id=""form-children"">
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233026357", async() => {
                    WriteLiteral("Children");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233027706", async() => {
                    WriteLiteral("1 Child");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233028967", async() => {
                    WriteLiteral("2 Children");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbe8a3756b6cd051803d6517b734699b450b233030231", async() => {
                    WriteLiteral("3 Children");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </select>
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""first-name"" class=""sr-only"">Full name</label>
                                <input type=""text"" name=""first-name"" class=""form-control"" id=""first-name""
                                       placeholder=""First Name"">
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""email"" class=""sr-only"">Email</label>
                                <input type=""email"" name=""email"" class=""form-control"" id=""email""
                                       plac");
                WriteLiteral(@"eholder=""Email"">
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""phone"" class=""sr-only"">Phone</label>
                                <input type=""tel"" name=""phone"" class=""form-control"" id=""phone"" placeholder=""Phone"">
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""address-line1"" class=""sr-only"">Address line </label>
                                <input type=""text"" name=""address-line1"" class=""form-control"" id=""address-line1""
                                       placeholder=""Address line"">
                                <spa");
                WriteLiteral(@"n class=""help-block""></span>
                            </div>
                        </div>

                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""city"" class=""sr-only"">City</label>
                                <input type=""text"" name=""city"" class=""form-control"" id=""city"" placeholder=""City"">
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12 col-md-6"">
                            <div class=""form-group"">
                                <label for=""country"" class=""sr-only"">Country</label>
                                <input type=""text"" name=""country"" class=""form-control"" id=""country""
                                       placeholder=""Country"">
                                <span class=""help-block""></span>
                            </div>
                   ");
                WriteLiteral(@"     </div>

                        <div class=""col-sm-12"">
                            <div class=""form-group"">
                                <label for=""requirements"" class=""sr-only"">Special requirements</label>
                                <textarea name=""requirements"" class=""form-control"" rows=""8"" id=""requirements""
                                          placeholder=""Special requirements""></textarea>
                                <span class=""help-block""></span>
                            </div>
                        </div>
                        <div class=""col-sm-12"">
                            <button type=""submit"" class=""btn btn-booking"">Book now by email</button>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <!-- .reservation__form -->\r\n                </div> <!-- .reservation__form-body -->\r\n            </div>\r\n        </div> <!-- / .row -->\r\n    </div> <!-- / .container -->\r\n</section> <!-- / .section reservation -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Room> Html { get; private set; }
    }
}
#pragma warning restore 1591
