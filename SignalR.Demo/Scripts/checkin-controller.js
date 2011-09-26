var checkinHub;
var map;
var markersArray = [];

function startGeoLocator()
{
	navigator.geolocation.getCurrentPosition(onGeoLocationObtained);
}

function onGeoLocationObtained(position)
{
	checkinHub.checkin(
		{
			Username: $('#username').val(),
			Latitude: position.coords.latitude,
			Longitude: position.coords.longitude
		});
}

function initialize()
{
	var myLatlng = new google.maps.LatLng(30,-40);

	var myOptions =
		{
			zoom: 3,
			mapTypeId: google.maps.MapTypeId.ROADMAP,
			center: myLatlng
		};

	map = new google.maps.Map(document.getElementById("map_canvas"),myOptions);
}

function clearMarkers()
{
	for (var i = 0;i < markersArray.length;i++)
	{
		markersArray[i].setMap(null);
	}
}

function drawMarkers()
{
	for (var i = 0;i < markersArray.length;i++)
	{
		var marker = new google.maps.Marker({
			position: markersArray[i].position,
			map: map,
			title: markersArray[i].title
		});
	}
}

function addMarkerToArray(marker)
{
	markersArray.push(marker);
}

$(function()
{
	checkinHub = $.connection.geoCheckinHub;

	checkinHub.showCheckins = function(messages)
	{
		clearMarkers();

		$(messages).each(function(i,item)
		{
			var myLatlng = new google.maps.LatLng(item.Latitude,item.Longitude);

			addMarkerToArray(new google.maps.Marker({
				position: myLatlng,
				map: map,
				title: item.Username
			}));
		});

		drawMarkers();
	};

	$('#checkin').click(function()
	{
		if ($('#username').val() != '')
		{
			startGeoLocator();
		}
		else
		{
			alert('Please provide a username');
		}
	});

	$.connection.hub.start(function() { checkinHub.getAllCheckins(); });

	initialize();
});