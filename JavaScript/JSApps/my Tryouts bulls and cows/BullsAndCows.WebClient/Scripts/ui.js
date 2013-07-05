var ui = (function () {
    function buildLoginForm() {
        var html =
            '<div id="login-wrapper">' +
                '<form>' +
                    '<label for="tb-input-username">User name: </label>' +
                    '<input type"text" id="tb-input-username" />' +
                    '<label for="tb-input-password">Password: </label>' +
                    '<input type"text" id="tb-input-password" />' +
                    '<label for="tb-input-nickname">Nickname: </label>' +
                    '<input type"text" id="tb-input-nickname" />' +
                    '<br />' +
                    '<button id="btn-login">Login</button>' +
                    '<button id="btn-register">Register</button>' +
                '</form>' +
            '</div>'

        return html;
    }

    function buildLoggedHtml() {
        var html =
            '<div id="logged-wrapper">' +
                'Player: ' + localStorage.getItem("nickname") +
                '<button id="btn-logout">Logout</button>'
            '</div>'

        return html;
    }

    function appendOpenGames(games) {
        var html =
            '<div id="all-open-games">' +
                '<h2>Open games: </h2>' +
                '<ul>';
        for (var i = 0; i < games.length; i++) {
            var li = '<li data-game-id="' + games[i].id + '">' +
                '<a href="#">' +
                games[i].title +
                '</a>'
                '</li>'
            html += li;
        }

        html += '</ul></div>';

        return html;
    }

    function appendActiveGames(games) {
        var html =
            '<div id="all-active-games">' +
                '<h2>Active games: </h2>' +
                '<ul>';
        for (var i = 0; i < games.length; i++) {
            var li =
                    '<li data-game-id="' + games[i].id + '">' +
                        '<strong>Title: </strong>' + games[i].title +
                        ' <strong>Status: </strong>' + games[i].status +
                    '</li>'
            html += li;
        }

        html += '</ul></div>';

        return html;
    }

    return {
        loginForm: buildLoginForm,
        loggedHtml: buildLoggedHtml,
        openGamesAttachment: appendOpenGames,
        myActiveGameAttachment: appendActiveGames,
    }

}());