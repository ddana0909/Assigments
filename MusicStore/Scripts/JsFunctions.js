function SubmitDisplayOptions(sortField, sortOrder) {
	$("#SortField").val(sortField);
	$("#SortOrder").val(sortOrder);
	$('form').submit();
}


function ShowOrderAlbums(url) {
	$.get(url, function (data) {
		$("#albums").html(data);
		$("#albums").dialog({ modal: true, width: 850, title: 'Albums' });
		//$("#albums").dialog("open");

	});
}