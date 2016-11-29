function log() {
    document.getElementById('results').innerText = '';

    Array.prototype.forEach.call(arguments, function (msg) {
        if (msg instanceof Error) {
            msg = "Error: " + msg.message;
        }
        else if (typeof msg !== 'string') {
            msg = JSON.stringify(msg, null, 2);
        }
        document.getElementById('results').innerHTML += msg + '\r\n';
    });
}

document.getElementById("login").addEventListener("click", login, false);
document.getElementById("api").addEventListener("click", api, false);
document.getElementById("logout").addEventListener("click", logout, false);

function login() {
    mgr.signinRedirect();
}

function logout() {
    mgr.signoutRedirect();
}

function api() {
    mgr.getUser().then(function (user) {
        if (user) {
            var url = "https://stg.mzoneweb.net/new-api.idsvr/Users/_.self";

            var xhr = new XMLHttpRequest();
            xhr.open("GET", url);
            xhr.onload = function () {
                log(xhr.status, JSON.parse(xhr.responseText));
            }
            xhr.setRequestHeader("Authorization", "Bearer " + user.access_token);
            xhr.send();
        }
        else {
            log("User not logged in");
        }
    });
}


// Identity server configuration
var config = {
    authority: "https://stg.mzoneweb.net/idsvr",
    client_id: "AA1436C5-B49B-444E-8291-D5BE3BDABCB5",
    redirect_uri: "http://localhost:5000/callback.html",
    post_logout_redirect_uri: "http://localhost:5000/",
    response_type: "id_token token",
    scope:"openid api"
};
var mgr = new Oidc.UserManager(config);

// If user not authenticated then redirect to sign-in page
mgr.getUser().then(function (user) {
    if (user) {
        log("User logged in", user.profile);
        window.localStorage.removeItem("deepLink");
    }
    else {
        // Save requested link and redirect to it after signed in
        window.localStorage.setItem("deepLink", window.location);
        mgr.signinRedirect();
    }
});
