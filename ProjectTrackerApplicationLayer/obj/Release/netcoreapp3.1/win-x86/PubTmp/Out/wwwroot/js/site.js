// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/* For Select2*/
$(document).ready(function () {
	$('#Select2').select2({
		allowClear: true,
		maximumSelectionLength: 2,
		placeholder: 'Select Roles'
	})
	$('#MultipleMembers').select2({
		allowClear: true,
		minimumSelectionLength: 2,
		placeholder: 'Select team members'
	})
	$('#filesMultiple').select2({
		allowClear: true,
		maximumSelectionLength: 0,
	})

});
/* For Table*/
$(document).ready(function () {
	$('#ActivityTables').DataTable({
		paging: false,
		ordering: true,
		info: false,


	});
	$('#WorkActivity').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 3 },
			{ orderable: false, targets: 4 }
		],
		info: false,

	});
	$('#ProjectTable').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 2 },
			{ orderable: false, targets: 5 }
		],
		info: false,

	});
	$('#ManagerProject').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 3 },
			{ orderable: false, targets: 6 }
		],
		info: false,

	});
	$('#SprintTable').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 4 }
		],
		info: false,

	});
	$('#MissionTable').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 3 },
			{ orderable: false, targets: 4 }
		],
		info: false,

	});
	$('#WorkTable').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 4 }
		],
		info: false,

	});

	$('#UsersTable').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 5 },
			{ orderable: false, targets: 7 }
		],
		info: false,

	});
	$('#MemberTable').DataTable({
		paging: false,
		ordering: true,
		columnDefs: [
			{ orderable: false, targets: 6 }
		],
		info: false,

	});
});

		



