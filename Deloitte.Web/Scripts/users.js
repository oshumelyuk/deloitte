var Deloitte;
(function (deloitte) {
    "use strict";

    deloitte.selectTag = function (tag) {
        if (deloitte.addToSelectedTags(tag)) {
            deloitte.onTagsSelectionChanged();
        }
    };

    deloitte.onTagsSelectionChanged = function () {
        var userTagMap = deloitte.getUserTagMap();
        for (var i = 0; i < userTagMap.length; i++) {
            if (deloitte.utils.arrayContainsAll(userTagMap[i], deloitte.selectedTags)) {
                $('#usersGrid tbody tr:eq(' + i + ')').addClass("visible");
            } else {
                $('#usersGrid tbody tr:eq(' + i + ')').removeClass("visible");
            }
        }
        if (!deloitte.selectedTags || deloitte.selectedTags.length == 0) {
            $('#userTags').parent().hide();
        } else {
            $('#userTags').parent().show();
        }
    };

    deloitte.addToSelectedTags = function (tag) {
        if (deloitte.selectedTags.indexOf(tag) >= 0) {
            //do nothing if tag is already added;
            return false;
        }
        deloitte.selectedTags.push(tag);
        var element = $("<li id='tag" + tag + "'></li>");
        element.append($("<span>#" + tag + "</span>"))
        element.append($("<a href='javascript:void(0)' class='remove-link' onclick='Deloitte.unselectTag(\""+ tag + "\")'>x</a>"))
        $('#userTags').append(element);
        return true;
    };

    deloitte.unselectTag = function (tag) {
        if (deloitte.selectedTags.indexOf(tag) < 0) {
            //do nothing if tag wasn't added
            return false;
        }
        deloitte.utils.arrayRemove(deloitte.selectedTags, tag);
        $('#userTags #tag' + tag).remove();
        deloitte.onTagsSelectionChanged();
        return true;
    };

    deloitte.getUserTagMap = function () {
        if (deloitte.users) {
            return deloitte.users;
        }

        var users = [];
        $("#usersGrid tbody tr").each(function (index) {
            var tagsCell = $(this).find('td:last')[0];
            var allTags = deloitte.extractTagsFromCell(tagsCell);
            users.push(allTags);
        });
        deloitte.users = users;
        return deloitte.users;
    };

    deloitte.extractTagsFromCell = function (cell) {
        var tags = cell.innerText.split(' ');
        for (var i = 0; i < tags.length; i++) {
            tags[i] = tags[i].substr(1, tags[i].length - 1);
        }
        return tags;
    };

    deloitte.selectedTags = [];

})(Deloitte || (Deloitte = {}));