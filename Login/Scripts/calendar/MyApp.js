var app = angular.module('myApp', ['ui.calendar', 'ui.bootstrap']);


app.controller('myNgController', ['$scope', '$http', 'uiCalendarConfig', function ($scope, $http, uiCalendarConfig) {

    $scope.SelectedEvent =null;
    var isFirstTime = true;

    $scope.events = [];

    $scope.convertToDate = function (stringDate) {
        var dateOut = new Date(stringDate);
        dateOut.setDate(dateOut.getDate() + 1);
        return dateOut;
    };

    $scope.EventsEasy = {
        color: 'lightblue',
        textColor: 'black',
        events: []
    };


    $scope.EventsMedium = {
        color: 'yellow',
        textColor: 'black',
        events: []
    };


    $scope.EventsHard = {
        color: 'red',
        textColor: 'black',
        events: []
    };


    $scope.eventSources = [$scope.EventsEasy, $scope.EventsMedium, $scope.EventsHard];

    //Load events from server
    //$http.get('/Calendar/GetEvents', {
    //    cache: true,
    //    params: {}
    //}).then(function (data) {
    //    $scope.events.slice(0, $scope.events.length);
    //    angular.forEach(data.data, function (value) {
    //        alert(new Date(value.StartAt) + "\n" + new Date(value.EndAt));
    //        $scope.events.push({
    //            title: value.Title,
    //            description: value.Description,
    //            start: new Date(value.StartAt),
    //            end: new Date(value.EndAt),
    //            allDay: value.IsFullDay,
    //            stick: true
    //        });
    //    });
    //});

    $http.get('/Calendar/GetEvents?type=Easy', {
        cache: true,
        params: {}
    }).then(function (data) {
        $scope.events.slice(0, $scope.events.length);
        angular.forEach(data.data, function (value) {
            //alert(new Date(value.StartAt) + "\n" + new Date(value.EndAt));
            $scope.EventsEasy.events.push({
                title: value.Title,
                description: value.Description,
                start: new Date(value.StartAt),
                end: new Date(value.EndAt),
                owner: value.Owner,
                building: value.Building,
                room: value.Room,
                id: value.ID,
                DidJoin: value.DidJoin,
                stick: true
            });
        });
    });

    $http.get('/Calendar/GetEvents?type=Medium', {
        cache: true,
        params: {}
    }).then(function (data) {
        $scope.events.slice(0, $scope.events.length);
        angular.forEach(data.data, function (value) {
            //alert(new Date(value.StartAt) + "\n" + new Date(value.EndAt));
            $scope.EventsMedium.events.push({
                title: value.Title,
                description: value.Description,
                start: new Date(value.StartAt),
                end: new Date(value.EndAt),
                allDay: value.IsFullDay,
                owner: value.Owner,
                building: value.Building,
                room: value.Room,
                id: value.ID,
                DidJoin: value.DidJoin,
                stick: true
            });
        });
    });

    $http.get('/Calendar/GetEvents?type=Hard', {
        cache: true,
        params: {}
    }).then(function (data) {
        $scope.events.slice(0, $scope.events.length);
        angular.forEach(data.data, function (value) {
            //alert(new Date(value.StartAt) + "\n" + new Date(value.EndAt));
            $scope.EventsHard.events.push({
                title: value.Title,
                description: value.Description,
                start: new Date(value.StartAt),
                end: new Date(value.EndAt),
                allDay: value.IsFullDay,
                owner: value.Owner,
                building: value.Building,
                room: value.Room,
                id: value.ID,
                DidJoin: value.DidJoin,
                stick: true
            });
        });
    });

    //configure calendar
    $scope.uiConfig = {
        calendar: {
            height: 750,
            editable: true,
            displayEventTime: true,
            header: {
                left: 'month basicWeek basicDay agendaWeek agendaDay',   
                //left: 'agendaWeek',
                center: 'title',
                right: 'today prev,next'
            },
            eventClick: function (event) {
                $scope.SelectedEvent = event;
            }
            //eventAfterAllRender: function () {
            //    if ($scope.EventsEasy.events.length > 0 && isFirstTime) {
            //        //Focus first event
            //        uiCalendarConfig.calendars.myCalendar.fullCalendar('gotoDate', $scope.events[0].start);
            //        isFirstTime = false;
            //    }
            //}
        }
    };

}]);