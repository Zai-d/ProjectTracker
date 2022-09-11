#pragma checksum "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3118ce51bed7039c1a48fb88ce17c37656dfcd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashBoard_MemberDashBoard), @"mvc.1.0.view", @"/Views/DashBoard/MemberDashBoard.cshtml")]
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
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3118ce51bed7039c1a48fb88ce17c37656dfcd7", @"/Views/DashBoard/MemberDashBoard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    public class Views_DashBoard_MemberDashBoard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<h2 class=""text-center text-gray-800"">Projects <i class=""fa-solid fa-folder-closed""></i></h2>
<br />
<div class=""row"">
	<div class=""col-lg-3 ""></div>
	<div class=""col-lg-6 mb-4"">
		<div class=""card shadow-lg mb-4"">
			<div class=""card-header py-3"">
				<h6 class=""m-0 font-weight-bold text-info"">Projects</h6>
			</div>
			<div class=""card-body"">
");
#nullable restore
#line 12 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                 foreach (var project in (List<Project>)ViewBag.Projects)
				{

					var sprints = project.Sprints;
					double completedSprints = 0;
					double percentage = 0;
					if (sprints.Count != 0)
					{
						foreach (var sprint in sprints)
						{
							if (sprint.StatusID == 4)
							{
								completedSprints++;
							}
						}
						percentage = (completedSprints / (double)sprints.Count) * 100;
						percentage = Math.Round(percentage, 2);
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<h4 class=\"small font-weight-bold\">\r\n\t\t\t\t\t\t<a class=\"text-dark\"");
            BeginWriteAttribute("href", " href=\"", 947, "\"", 1007, 2);
            WriteAttributeValue("", 954, "/Sprint/AllSprintsMember?projectID=", 954, 35, true);
#nullable restore
#line 31 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue("", 989, project.ProjectID, 989, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 32 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                       Write(project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t<span class=\"float-right\">");
#nullable restore
#line 34 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                                             Write(percentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n\t\t\t\t\t</h4>\r\n\t\t\t\t\t<div class=\"progress mb-4\">\r\n\t\t\t\t\t\t<div class=\"progress-bar bg-info\" role=\"progressbar\"");
            BeginWriteAttribute("style", " style=\"", 1202, "\"", 1229, 3);
            WriteAttributeValue("", 1210, "width:", 1210, 6, true);
#nullable restore
#line 37 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue(" ", 1216, percentage, 1217, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1228, "%", 1228, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("aria-valuenow", "\r\n\t\t\t\t\t\t aria-valuenow=\"", 1230, "\"", 1265, 1);
#nullable restore
#line 38 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue("", 1254, percentage, 1254, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\" aria-valuemax=\"100\"></div>\r\n\t\t\t\t\t</div>\r\n");
#nullable restore
#line 40 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n<div class=\"row justify-content-center\">\r\n\r\n");
#nullable restore
#line 47 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
     foreach (var work in (List<Work>)ViewBag.Works)
	{
		string dropdown = string.Concat(work.Name.Where(c => !char.IsWhiteSpace(c)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<div class=\"card col-3 mx-3 mb-5\" style=\"background:none; border:none;\">\r\n\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 1632, "\"", 1649, 2);
            WriteAttributeValue("", 1639, "#", 1639, 1, true);
#nullable restore
#line 51 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue("", 1640, dropdown, 1640, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"d-block border-bottom-0 card-header\" style=\"margin-left:-15px; margin-right:-15px; background-color:rgba(0,0,0,0.30)\" data-toggle=\"collapse\"\r\n\t\t   role=\"button\" aria-expanded=\"true\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1839, "\"", 1864, 1);
#nullable restore
#line 52 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue("", 1855, dropdown, 1855, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t<h6 class=\"text-center font-weight-bolder text-info\">");
#nullable restore
#line 53 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                                                                Write(work.Mission.Sprint.Project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\t\t\t</a>\r\n\t\t\t<div class=\"collapse show\"");
            BeginWriteAttribute("id", " id=\"", 2003, "\"", 2017, 1);
#nullable restore
#line 55 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue("", 2008, dropdown, 2008, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t<div class=\"p-3 shadow-lg \" style=\"margin-left:-15px; margin-right:-15px; background-color:#F8F9FC; \">\r\n\r\n\t\t\t\t\t<h6 class=\"text-center font-weight-bold text-info \">Sprint: ");
#nullable restore
#line 58 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                                                                           Write(work.Mission.Sprint.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\t\t\t\t\t<hr>\r\n\r\n\t\t\t\t\t<div class=\"card mb-4\">\r\n\t\t\t\t\t\t<div class=\"card-header py-3\">\r\n\t\t\t\t\t\t\t<h6 class=\"m-0 font-weight-bold text-info\">");
#nullable restore
#line 63 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                                                                  Write(work.Mission.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t<div class=\"card-body\">\r\n");
            WriteLiteral("\t\t\t\t\t\t\t\t<h5><a class=\"text-uppercase\"");
            BeginWriteAttribute("href", " href=\"", 2477, "\"", 2528, 2);
            WriteAttributeValue("", 2484, "/Work/MembersWorks?missionID=", 2484, 29, true);
#nullable restore
#line 67 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
WriteAttributeValue("", 2513, work.MissionID, 2513, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 67 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                                                                                                             Write(work.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n\t\t\t\t\t\t\t\t<br />\r\n\t\t\t\t\t\t\t\t<a class=\"text-danger\">\r\n\t\t\t\t\t\t\t\t\tDeadline:\r\n\t\t\t\t\t\t\t\t\t");
#nullable restore
#line 71 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
                               Write(work.Mission.Sprint.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t\t\t<br />\r\n");
#nullable restore
#line 74 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
								switch (work.StatusID)
								{
									case 1:

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a>Work in progress</a>\r\n");
#nullable restore
#line 78 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
										break;
									case 2:

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a>Work approved</a>\r\n");
#nullable restore
#line 81 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
										break;
									case 3:

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a>Work rejected waiting edit</a>\r\n");
#nullable restore
#line 84 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
										break;
									case 4:

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a>Work completed waiting team leader reply</a>\r\n");
#nullable restore
#line 87 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
										break;
									case 5:

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<a>Work cancelled</a>\r\n");
#nullable restore
#line 90 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
										break;
								}
							

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
#nullable restore
#line 98 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\MemberDashBoard.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591