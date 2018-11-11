var Deloitte;
(function (deloitte) {
    "use strict";

    deloitte.utils = new function () {

        this.arrayContainsAll = function (array, items) {
            for (var i = 0; i < items.length; i++) {
                var foundMatch = false;
                for (var j = 0; j < array.length; j++) {
                    if (array[j] == items[i]) {
                        foundMatch = true;
                        break;
                    }
                }
                if (!foundMatch) {
                    return false;
                }
            }
            return true;
        }

        this.arrayRemove = function (array, item) {
            for (var i = 0; i < array.length; i++) {
                if (array[i] == item) {
                    return array.splice(i, 1);
                }
            }
            return array;
        };

    };

})(Deloitte || (Deloitte = {}));