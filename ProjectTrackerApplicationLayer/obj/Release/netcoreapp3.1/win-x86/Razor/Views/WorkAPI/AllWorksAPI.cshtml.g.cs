#pragma checksum "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\WorkAPI\AllWorksAPI.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3be03ac86ba50c01df1f95e2ac11b24a8547fc6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkAPI_AllWorksAPI), @"mvc.1.0.view", @"/Views/WorkAPI/AllWorksAPI.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3be03ac86ba50c01df1f95e2ac11b24a8547fc6c", @"/Views/WorkAPI/AllWorksAPI.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkAPI_AllWorksAPI : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"text-center\">All Works</h1>\r\n\r\n<br />\r\n<hr />\r\n\r\n<script>\r\n\t//$(document).ready(function () {\r\n\t//\talert(\"in function\");\r\n\t//\t$.ajax({\r\n\t//\t\turl: \'/WorkAPI/AllWorks?missionID=");
#nullable restore
#line 11 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\WorkAPI\AllWorksAPI.cshtml"
                                           Write(ViewBag.missionID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
	//		method: 'GET',
	//		dataType: 'json',
	//		success: function (works) {
	//			//$('#Table').append(
	//			//	'<table class=""table table-bordered table-hover cell-border"" id=""WorkTable"" width=""100%""' +
	//			//	'cellspacing=""0""> <thead><tr class=""font-weight-bolder"" > <th>In Project </th>' +
	//			//	'<th> Work Title </th> <th> Work Description </th> <th>Team Member</th> <th>Status </th>' +
	//			//	'<th>Attachment Submitted</th> <th> Team Leader Note </th> <th> Action </th></tr> </thead> <tbody>')
	//			debugger;
	//			for (var i = 0; i < works.length; i++) {
	//				$('#WorkAPI').append('<tr>' + '<td>' + works[i].projectName + '</td>' +
	//					'<td>' + works[i].workName + '</td>' + '<td>' + works[i].workDescription + '</td>' +
	//					'<td>' + works[i].memberName + '</td>' + '<td>' + works[i].workStatus + '</td>' +
	//					'<td>' + works[i].filesNames + '</td>' + '<td>' + works[i].teamLeaderNote + '</td>' +
	//					'<td> <a class=""btn bg-gradient-danger text-white"" onclick=""Deletefunc('");
            WriteLiteral(@" + works[i].workID + ')"">' +
	//					'Delete </a> <hr>' +
	//					'<a class=""btn bg-gradient-info text-white"" href=""/WorkAPI/EditWorkForm?workID=' + works[i].workID + '&missionID=' + works[i].missionID + '\"">' +
	//					'Edit </a> </td > </tr>')
	//			}

	//		},
	//		error: function () {
	//			alert('error:');
	//		}
	//	});

	//});
	$(document).ready(function () {
		$('#WorkAPI').DataTable({

			ajax: {
				""url"": '/WorkAPI/AllWorks?missionID=");
#nullable restore
#line 43 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\WorkAPI\AllWorksAPI.cshtml"
                                               Write(ViewBag.missionID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
				""type"": ""GET"",
				""dataType"": ""json"",
				""dataSrc"": """",
			},
			paging: false,
			ordering: true,
			columnDefs: [
				{ orderable: false, targets: 7 }
			],
			info: false,
			columns: [
				{
					""data"": ""projectName""
				},
				{ ""data"": ""workName"" },
				{ ""data"": ""workDescription"" },
				{ ""data"": ""memberName"" },
				{ ""data"": ""workStatus"" },
				{ ""data"": ""filesNames"" },
				{ ""data"": ""teamLeaderNote"" },
				{
					""render"": function (data, type, full, meta) { return '<a class=""btn bg-gradient-danger text-white"" onclick=""Deletefunc(' + full.workID+ ')"">Delete</a>'; },
				},
				{
					""render"": function (data, type, full, meta) { return '<a class=""btn bg-gradient-info text-white"" href=""/WorkAPI/EditWorkForm?workID=' + full.workID+'&missionID='+full.missionID+'"">Edit</a>'; },
				}


			],

		});
	});

	function Deletefunc(id) {
		$.ajax({
			url: '/WorkAPI/DeleteWork?workID=' + id,
			method: 'DELETE',
			success: function () {
				alert('record has bee");
            WriteLiteral("n deleted\');\r\n\t\t\t\tdocument.location.reload(true)\r\n\t\t\t},\r\n\t\t\terror: function (error) {\r\n\t\t\t\talert(\'error\');\r\n\t\t\t}\r\n\t\t});\r\n\t}\r\n\r\n\r\n\r\n</script>\r\n\r\n<div class=\"row mx-3\">\r\n\t<a class=\"btn bg-gradient-info text-white\"");
            BeginWriteAttribute("href", " href=\"", 2948, "\"", 3007, 2);
            WriteAttributeValue("", 2955, "/WorkAPI/NewWorkFormAPI?missionID=", 2955, 34, true);
#nullable restore
#line 96 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\WorkAPI\AllWorksAPI.cshtml"
WriteAttributeValue("", 2989, ViewBag.missionID, 2989, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Add Work</a>
</div>
<div class=""row justify-content-center"">
	<div class="" col-12"">
		<div class=""card mx-3 shadow mb-4"">

			<div class=""card-body"">
				<div class=""table-responsive"" id=""Table"">
					<table class=""table table-bordered table-hover cell-border"" id=""WorkAPI"" width=""100%"" cellspacing=""0"">
						<thead>
							<tr class=""font-weight-bolder"">
								<th>
									In Project
								</th>
								<th>
									Work Title
								</th>
								<th>
									Work Description
								</th>
								<th>
									Team Member
								</th>
								<th>
									Status
								</th>
								<th>
									Attachment Submitted
								</th>
								<th>
									Team Leader Note
								</th>
								<th>
									Delete
								</th>
								<th>
									Edit
								</th>

							</tr>
						</thead>
					</table>
				</div>
			</div>
		</div>
	</div>

</div>
");
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
