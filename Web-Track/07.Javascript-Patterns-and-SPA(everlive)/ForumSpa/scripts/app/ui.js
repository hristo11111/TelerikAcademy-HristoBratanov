var ui = (function () {

    function buildRegisterLoginForm() {
        var registerLoginForm = '<form id="register-login-form" action="#/user/register" method="post">' +
                                    '<header>' +
                                        '<h1 id="register-login-header">Register form</h1>' +
                                        '<ul>' +
                                            '<li id="register-btn"><a href="#/register-login">Register</a></li>' +
                                            '<li id="login-btn"><a href="#/register-login">Login</a></li>' +
                                        '</ul>' +
                                    '</header>' +
                                    '<div id="content">' +
                                        '<input type="text" id="user-name" placeholder="username" />' +
                                        '<input type="text" id="nick-name" placeholder="nickname"/>' +
                                        '<input type="password" id="password" placeholder="password"/>' +
                                    '</div>' +
                                    '<footer>' +
                                        '<input type="submit" value="Submit" />' +
                                    '</footer>' +
                                '</form>';

        return registerLoginForm;
    }

    function buildMyGamesMenu(sessionKey) {
        var html =
            '<div>' +
                '<h2>My games:</h2>' +
                '<div id="active-games"></div>' +
                '<form id="game-create-form" action="#/Game/create/' + sessionKey + '" method="post">' +
                    '<h3>Create game:</h3>' +
                    '<span>Title: </span>' +
                    '<input id="game-title" type="text"/>' +
                    '<input type="submit" value="Create game"/>' +
                '</form>'
            '</div>';
        return html;
    }

    function buildJoinGamesMenu() {
        var html =
            '<div>' +
                '<h2>Join games:</h2>' +
                '<div id="open-games"></div>' +
            '</div>';
        return html;
    }

    function buildFieldUI() {
        var html = 
            '<table id="field-table">' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
                '<tr>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td></td>' +
                '</tr>' +
            '</table>'

        return html;
    }

    return {
        myGamesUI: buildMyGamesMenu,
        joinGamesUI: buildJoinGamesMenu,
        fieldUI: buildFieldUI,
        registerLoginForm: buildRegisterLoginForm
    }
}());