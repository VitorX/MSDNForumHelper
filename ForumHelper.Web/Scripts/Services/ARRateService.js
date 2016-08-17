angular.module('ForumHelperApp').factory('ARRate', function ($http) {

    this.request = function (beginDate,endDate,arType) {
        return {
            labels: ["Unanswered Threads", "Answered Threads"],
            data: [15, 45],
            beginDate: beginDate,
            endDate: endDate,
            type: arType
        }
    }

    return this;
   
})