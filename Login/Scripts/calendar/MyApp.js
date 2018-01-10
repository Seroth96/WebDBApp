var app = angular.module('myApp', ['ui.calendar', 'ui.bootstrap']);
app.controller('myNgController', ['$scope', '$http', 'uiCalendarConfig', function ($scope, $http, uiCalendarConfig) {

    $scope.SelectedEvent =null;
    var isFirstTime = true;

    $scope.events = [];
    $scope.eventSources = [$scope.events];   

    //Load events from server
    $http.get('/Calendar/GetEvents', {
        cache: true,
        params: {}
    }).then(function (data) {
        $scope.events.slice(0, $scope.events.length);
        angular.forEach(data.data, function (value) {
           // alert(new Date(value.StartAt) + "\n" + new Date(value.EndAt));
            $scope.events.push({
                title: value.Title,
                description: value.Description,
                start: new Date(value.StartAt),
                end: new Date(value.EndAt),
                allDay: value.IsFullDay,
                stick: true
            });
        });
    });

    //configure calendar
    $scope.uiConfig = {
        calendar: {
            height: 450,
            editable: true,
            displayEventTime: false,
            header: {
                left: 'month basicWeek basicDay agendaWeek agendaDay',                
                center: 'title',
                right: 'today prev,next'
            },
            eventClick: function (event) {
                $scope.SelectedEvent = event;
            },
            eventAfterAllRender: function () {
                if ($scope.events.length > 0 && isFirstTime) {
                    //Focus first event
                    uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
                    isFirstTime = false;
                }
            }
        }
    };

}]);